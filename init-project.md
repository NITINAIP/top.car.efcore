
## init project
dotnet new sln -n top.car.service
dotnet new classlib -n top.car.service.Domain -f net8.0
dotnet new classlib -n top.car.service.Application -f net8.0
dotnet new classlib -n top.car.service.Infrastructure -f net8.0
dotnet new webapi -n top.car.service.API -f net8.0
dotnet new xunit -n top.car.service.Tests -f net8.0

## Add Projects to the Solution
dotnet sln add top.car.service.Domain
dotnet sln add top.car.service.Application
dotnet sln add top.car.service.Infrastructure
dotnet sln add top.car.service.API
dotnet sln add top.car.service.Tests 

## Setting Project References...
dotnet add top.car.service.API reference top.car.service.Application
dotnet add top.car.service.API reference top.car.service.Infrastructure
dotnet add top.car.service.Infrastructure reference top.car.service.Domain
dotnet add top.car.service.Application reference top.car.service.Domain
dotnet add top.car.service.Tests reference top.car.service.Application