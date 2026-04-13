$entitiesDir = 'd:\project\thaioil\top-car-service\top.car.service.Domain\Entities'
$domainRepoDir = 'd:\project\thaioil\top-car-service\top.car.service.Domain\interface\Repositories'
$infraRepoDir = 'd:\project\thaioil\top-car-service\top.car.service.Infrastructure\Repositories'

$baseEntities = @('BaseEntity','BaseEntityWithId','BaseEntityWithString','BaseEntityWithUuid')
$entities = Get-ChildItem -Path $entitiesDir -Filter '*.cs' |
  Where-Object { $baseEntities -notcontains $_.BaseName } |
  Select-Object -ExpandProperty BaseName

foreach ($e in $entities) {
  $iName = "I${e}Repo"
  $iFile = Join-Path $domainRepoDir ("$iName.cs")
  if (-not (Test-Path $iFile)) {
    $iContent = @"
using top.car.service.Domain.Entities;
using top.car.service.Domain.Interface.Repositories;

public interface $iName : IRepositoryRead<$e>, IRepositoryWrite<$e> { }
"@
    Set-Content -Path $iFile -Value $iContent -Encoding UTF8
  }

  $rName = "${e}Repo"
  $rFile = Join-Path $infraRepoDir ("$rName.cs")
  if (-not (Test-Path $rFile)) {
    $rContent = @"
using top.car.service.Domain.Entities;
using top.car.service.Infrastructure.Data;
using top.car.service.Infrastructure.Repositories.Abstractions;

public class $rName(AppDbContext context) : Repository<$e>(context), $iName
{

}
"@
    Set-Content -Path $rFile -Value $rContent -Encoding UTF8
  }
}

$entitiesSorted = $entities | Sort-Object

# Update ICarServiceRepositoryManager.cs
$mgrInterfacePath = 'd:\project\thaioil\top-car-service\top.car.service.Domain\interface\Repositories\ICarServiceRepositoryManager.cs'
$mgrInterface = @()
$mgrInterface += 'namespace top.car.service.Domain.Interface.Repositories;'
$mgrInterface += 'public interface ICarServiceRepositoryManager : IRepository'
$mgrInterface += '{'
foreach ($e in $entitiesSorted) {
  $mgrInterface += "    I${e}Repo ${e}Repo { get; }"
}
$mgrInterface += '}'
Set-Content -Path $mgrInterfacePath -Value ($mgrInterface -join "`r`n") -Encoding UTF8

# Update CarServiceRepositoryManager.cs
$mgrImplPath = 'd:\project\thaioil\top-car-service\top.car.service.Infrastructure\Repositories\CarServiceRepositoryManager.cs'
$mgrImpl = @()
$mgrImpl += 'using top.car.service.Domain.Interface.Repositories;'
$mgrImpl += 'using top.car.service.Infrastructure.Data;'
$mgrImpl += 'using top.car.service.Infrastructure.Repositories.Abstractions;'
$mgrImpl += ''
$mgrImpl += 'namespace top.car.service.Infrastructure.Repositories;'
$mgrImpl += ''
$mgrImpl += 'public class CarServiceRepositoryManager(AppDbContext context) : RepositoryManager(context), ICarServiceRepositoryManager'
$mgrImpl += '{'
$mgrImpl += '    private readonly AppDbContext _context = context;'
$mgrImpl += ''
foreach ($e in $entitiesSorted) {
  $mgrImpl += "    public I${e}Repo ${e}Repo => new ${e}Repo(_context);"
}
$mgrImpl += '}'
Set-Content -Path $mgrImplPath -Value ($mgrImpl -join "`r`n") -Encoding UTF8

Write-Output ("Entities: " + $entities.Count)
Write-Output 'Repository interfaces and classes generated/updated.'
