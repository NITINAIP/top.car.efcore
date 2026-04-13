### README

#### Project Overview
ไฟล์นี้เป็น **Specification README** สำหรับโปรเจค **.NET 8 API** ที่ออกแบบตาม **Clean Architecture** ใช้ **EF Core** สำหรับ data access และ **AutoMapper** (หรือ mapper ที่ทีมเลือก) สำหรับ mapping ระหว่าง DTO/Domain. มุ่งเน้นความสามารถในการสเกล, ความทนทาน, และความสามารถในการดูแลรักษาในระดับ enterprise.

---

### Tech Stack
- **Runtime**: .NET 8  
- **Architecture**: Clean Architecture (Domain, Application, Infrastructure, API)  
- **ORM**: EF Core (latest compatible with .NET 8)  
- **Mapper**: AutoMapper หรือ Mapster (ตามทีมเลือก)  
- **DI**: Built-in Microsoft DI  
- **Container**: Docker (multi-stage builds)  
- **Orchestration**: Kubernetes (optional)  
- **Messaging**: RabbitMQ / Kafka / Azure Service Bus (ตามความต้องการ)  
- **Cache**: Redis  
- **Observability**: OpenTelemetry, Prometheus, Grafana, Application Insights (optional)  
- **CI/CD**: GitHub Actions / Azure DevOps  
- **Testing**: xUnit, FluentAssertions, integration tests, contract tests

---

### Solution Structure
| **Project** | **Responsibility** | **Example folders** |
|---|---:|---|
| **Domain** | Entities, Value Objects, Domain Events, Interfaces | Entities; ValueObjects; Events |
| **Application** | Use cases, DTOs, Interfaces, Validators, Mapping profiles | Features; DTOs; Interfaces; Mappings |
| **Infrastructure** | EF Core DbContext, Repositories, External integrations | Persistence; Repositories; Services |
| **API** | Controllers/Minimal APIs, DI registration, Middleware | Controllers; Middlewares; Program.cs |
| **Tests** | Unit tests, Integration tests, Contract tests | Unit; Integration; Fixtures |

---

### Getting Started
**Prerequisites**
- .NET 8 SDK  
- Docker  
- Database (Postgres / SQL Server) or local dev DB (SQLite for tests)  

**Quick commands**
```bash
# restore and build
dotnet restore
dotnet build

# run API locally
cd src/Api
dotnet run

# run migrations
cd src/Infrastructure
dotnet ef migrations add InitialCreate -p Infrastructure -s Api
dotnet ef database update -p Infrastructure -s Api

# docker build
docker build -t myapp/api:dev -f src/Api/Dockerfile .

# run tests
dotnet test
```

**Dockerfile guidance**
- ใช้ multi-stage build
- ใช้ `dotnet publish -c Release -o /app/publish`
- ใช้ slim runtime image เช่น `mcr.microsoft.com/dotnet/aspnet:8.0-alpine` ถ้า compatible

---

### Development Guidelines
#### Clean Architecture Rules
- **Dependencies point inward**: Infrastructure → Application → Domain. API depends on Application only.  
- **No framework types in Domain**: Domain project must not reference EF Core, ASP.NET types, or external libs.  
- **Use interfaces for external concerns**: Repositories, email, file storage ให้เป็น interface ใน Application/Domain แล้ว implement ใน Infrastructure.

#### EF Core Best Practices
- **DbContext per bounded context** or single context with clear aggregates.  
- **Use AsNoTracking()** สำหรับ read-only queries.  
- **Projection**: เลือกเฉพาะฟิลด์ที่ต้องการด้วย `Select` เพื่อลด payload.  
- **Avoid N+1**: ใช้ `Include` หรือ explicit joins; ตรวจสอบด้วย logging SQL.  
- **Migrations**: เก็บ migrations ใน Infrastructure; ใช้ migration scripts ใน CI/CD.  
- **Retry policy**: ใช้ transient retry (e.g., `EnableRetryOnFailure`) และ circuit breaker สำหรับ DB calls.

#### Mapping
- **Centralize mapping profiles** ใน Application project.  
- **Map DTO ↔ Domain**; หลีกเลี่ยง mapping logic ใน controller.  
- **Validate mappings** ใน unit tests (AutoMapper `AssertConfigurationIsValid()`).

#### Async and Performance
- **ใช้ async/await ทุกชั้นที่เป็น I/O** (DB, HTTP, messaging).  
- **Timeouts and CancellationToken**: ทุก handler/controller รับ `CancellationToken`.  
- **Bulk operations**: ใช้ batch inserts/updates เมื่อจำเป็น.

#### Resiliency
- ใช้ **Polly** สำหรับ Retry, Circuit Breaker, Bulkhead.  
- Rate limiting ที่ API Gateway; Backpressure ผ่าน messaging queue.

---

### Testing CI CD Observability Security Deployment
#### Testing
- **Unit tests**: Domain logic, Application handlers.  
- **Integration tests**: ใช้ Testcontainers หรือ in-memory DB สำหรับ EF Core.  
- **Contract tests**: ถ้ามี microservices ให้ใช้ contract testing (Pact หรืออื่นๆ).  
- **Performance tests**: k6 หรือ JMeter ใน pipeline ก่อน major release.

#### CI/CD
- Pipeline stages: Build → Unit tests → Static analysis → Integration tests → Publish artifact → Deploy to staging → Canary/Blue-Green → Promote to prod.  
- **Secrets**: เก็บใน secret store (Azure Key Vault / Kubernetes Secrets).  
- **Migrations**: Run migrations as part of deployment job with safety checks.

#### Observability
- **Tracing**: OpenTelemetry instrumentation across API, Application, Infrastructure.  
- **Logging**: Structured logs (Serilog) ส่งไปยัง centralized store.  
- **Metrics**: Expose Prometheus metrics; dashboard ใน Grafana.  
- **Alerts**: SLO-based alerts (latency, error rate, saturation).

#### Security
- **Auth**: OAuth2 / OpenID Connect (IdentityServer / Azure AD).  
- **Tokens**: JWT short-lived tokens; validate scopes/roles in Application layer.  
- **Input validation**: FluentValidation หรือ manual validators in Application.  
- **Secrets and keys**: Never commit to repo. Use secret manager.  
- **Network**: mTLS for service-to-service if required; use API Gateway for ingress protection.

---

### Checklist Before Release
- [ ] Solution layered correctly and projects have correct references  
- [ ] EF Core migrations created and tested in staging  
- [ ] Mapping profiles validated and covered by tests  
- [ ] All I/O methods are async and accept CancellationToken  
- [ ] Circuit breaker and retry policies configured for external calls  
- [ ] Logging, tracing, and metrics enabled and visible in staging  
- [ ] Security review completed (auth, input validation, secrets)  
- [ ] CI/CD pipeline with canary or blue-green deployment configured  
- [ ] Load test passed for expected traffic profile

---

### Example Minimal Program.cs Pattern
```csharp
var builder = WebApplication.CreateBuilder(args);

// Application and Infrastructure DI
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableRetryOnFailure());

// OpenTelemetry, Logging, etc.

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();
```

---

ถ้าต้องการ ผมสามารถ:
- สร้าง **template README** ที่ปรับให้ตรงกับ cloud provider (Azure/AWS/GCP) ที่ทีมใช้  
- ให้ **ตัวอย่างไฟล์ Dockerfile**, `docker-compose.yml`, และ **Kubernetes manifest** แบบเริ่มต้น  
- สร้าง **checklist PR template** และ **issue template** สำหรับ repo

ผมจะสร้างไฟล์ตัวอย่างเหล่านั้นให้ต่อถ้าคุณบอกว่าใช้ **cloud ไหน** และต้องการ **AutoMapper หรือ Mapster** เป็น mapper.