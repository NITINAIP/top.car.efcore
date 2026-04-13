$sqlPath = 'd:\project\thaioil\top-car-service\sql-script.sql'
$entitiesDir = 'd:\project\thaioil\top-car-service\top.car.service.Domain\Entities'

function To-PascalCase([string]$name) {
    $parts = $name -split '_'
    $out = @()
    foreach ($p in $parts) {
        if ([string]::IsNullOrWhiteSpace($p)) { continue }
        $lp = $p.ToLower()
        $out += ($lp.Substring(0,1).ToUpper() + $lp.Substring(1))
    }
    return ($out -join '')
}

function Get-Type([string]$sqlType, [bool]$isNotNull, [bool]$isPk) {
    if ($sqlType -eq 'INTEGER') {
        if ($isNotNull -or $isPk) { return 'int' }
        return 'int?'
    }
    return 'string?'
}

$auditCols = @('CREATED_DATE','CREATED_BY','UPDATED_DATE','UPDATED_BY','CREATE_DATE','USER_CREATE','UPDATE_DATE','USER_UPDATE')
$sql = Get-Content -Raw -Path $sqlPath

$tables = [regex]::Matches(
    $sql,
    'CREATE\s+TABLE\s+"(?<table>[^"]+)"\s*\((?<body>.*?)\)\s*;',
    [System.Text.RegularExpressions.RegexOptions]::Singleline
)

foreach ($tm in $tables) {
    $tableName = $tm.Groups['table'].Value
    $body = $tm.Groups['body'].Value
    $className = To-PascalCase $tableName

    $colMatches = [regex]::Matches(
        $body,
        '"(?<col>[^"]+)"\s+(?<type>INTEGER|TEXT)(?<rest>[^,\r\n]*)',
        [System.Text.RegularExpressions.RegexOptions]::IgnoreCase
    )

    $columns = @()
    foreach ($cm in $colMatches) {
        $col = $cm.Groups['col'].Value
        $type = $cm.Groups['type'].Value.ToUpper()
        $rest = $cm.Groups['rest'].Value
        $isPk = $rest -match 'PRIMARY\s+KEY'
        $isNotNull = $rest -match 'NOT\s+NULL'

        $columns += [pscustomobject]@{
            Name = $col
            Type = $type
            IsPk = $isPk
            IsNotNull = $isNotNull
        }
    }

    $pk = $columns | Where-Object { $_.IsPk } | Select-Object -First 1

    $baseClass = 'BaseEntity'
    if ($null -ne $pk) {
        if ($pk.Type -eq 'INTEGER') { $baseClass = 'BaseEntityWithId' }
        elseif ($pk.Type -eq 'TEXT') { $baseClass = 'BaseEntityWithString' }
    }

    $out = New-Object System.Collections.Generic.List[string]
    $out.Add('using System.ComponentModel.DataAnnotations.Schema;')
    $out.Add('')
    $out.Add('namespace top.car.service.Domain.Entities;')
    $out.Add(('[Table("{0}")]' -f $tableName))
    $out.Add(('public class {0} : {1}' -f $className, $baseClass))
    $out.Add('{')

    if ($null -ne $pk -and ($baseClass -eq 'BaseEntityWithId' -or $baseClass -eq 'BaseEntityWithString') -and $pk.Name -ne 'ID') {
        $out.Add(('    [Column("{0}")]' -f $pk.Name))
        if ($baseClass -eq 'BaseEntityWithId') {
            $out.Add('    public override int Id { get; set; }')
        } else {
            $out.Add('    public override string Id { get; set; } = "";')
        }
    }

    foreach ($c in $columns) {
        if ($auditCols -contains $c.Name) { continue }

        if ($null -ne $pk -and ($baseClass -eq 'BaseEntityWithId' -or $baseClass -eq 'BaseEntityWithString')) {
            if ($c.Name -eq 'ID' -or $c.Name -eq $pk.Name) { continue }
        }

        $propName = To-PascalCase $c.Name
        $propType = Get-Type $c.Type $c.IsNotNull $c.IsPk

        $out.Add(('    [Column("{0}")]' -f $c.Name))
        $out.Add(('    public {0} {1} {{ get; set; }}' -f $propType, $propName))
    }

    $out.Add('}')

    $filePath = Join-Path $entitiesDir ($className + '.cs')
    Set-Content -Path $filePath -Value ($out -join "`r`n") -Encoding UTF8
}

# remove accidental bad filename from previous runs
$junk = Join-Path $entitiesDir '.cs'
if (Test-Path $junk) { Remove-Item $junk -Force }

Write-Output ("Generated entities: " + $tables.Count)
