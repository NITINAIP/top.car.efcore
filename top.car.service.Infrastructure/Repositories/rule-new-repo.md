Repository Generation Rules (Simple + Strict)

1. Input Source
- อ่านรายชื่อ Entity จากโฟลเดอร์ Entities
- ใช้เฉพาะไฟล์ entity จริง
- ข้ามไฟล์ BaseEntity, BaseEntityWithId, BaseEntityWithString, BaseEntityWithUuid

2. Interface Naming + Location
- สร้างไฟล์ที่ Repositories
- ชื่อไฟล์: I{EntityName}Repo.cs
- ชื่อ interface: I{EntityName}Repo
- โครงสร้าง:
  using top.car.service.Domain.Entities;
  using top.car.service.Domain.Interface.Repositories;

  public interface I{EntityName}Repo : IRepositoryRead<{EntityName}>, IRepositoryWrite<{EntityName}> { }

3. Repository Class Naming + Location
- สร้างไฟล์ที่ Repositories
- ชื่อไฟล์: {EntityName}Repo.cs
- ชื่อ class: {EntityName}Repo
- โครงสร้าง:
  using top.car.service.Domain.Entities;
  using top.car.service.Infrastructure.Data;
  using top.car.service.Infrastructure.Repositories.Abstractions;

  public class {EntityName}Repo(AppDbContext context) : Repository<{EntityName}>(context), I{EntityName}Repo
  {
  }

4. Update ICarServiceRepositoryManager
- ไฟล์: ICarServiceRepositoryManager.cs
- เพิ่ม property ต่อ entity:
  I{EntityName}Repo {EntityName}Repo { get; }

5. Update CarServiceRepositoryManager
- ไฟล์: CarServiceRepositoryManager.cs
- เพิ่ม property ต่อ entity:
  public I{EntityName}Repo {EntityName}Repo => new {EntityName}Repo(_context);

6. Existing File Behavior
- ถ้าไฟล์ interface/repo มีอยู่แล้ว: ไม่ overwrite
- ถ้ายังไม่มี: สร้างใหม่
- ถ้า property ใน manager มีอยู่แล้ว: ไม่เพิ่มซ้ำ

7. Required Usings
- Interface file ต้องมี:
  using top.car.service.Domain.Entities;
  using top.car.service.Domain.Interface.Repositories;
- Repo file ต้องมี:
  using top.car.service.Domain.Entities;
  using top.car.service.Infrastructure.Data;
  using top.car.service.Infrastructure.Repositories.Abstractions;

8. Validation Checklist
- ทุก entity มี I{EntityName}Repo
- ทุก entity มี {EntityName}Repo
- ICarServiceRepositoryManager มี property ครบทุก repo
- CarServiceRepositoryManager มี implementation ครบทุก repo
- โปรเจกต์ต้องไม่มี compile error หลัง generate

Example with CarsMtCarcomp

Interface:
public interface ICarsMtCarcompRepo : IRepositoryRead<CarsMtCarcomp>, IRepositoryWrite<CarsMtCarcomp> { }

Repo class:
public class CarsMtCarcompRepo(AppDbContext context) : Repository<CarsMtCarcomp>(context), ICarsMtCarcompRepo
{
}

Manager interface:
ICarsMtCarcompRepo CarsMtCarcompRepo { get; }

Manager implementation:
public ICarsMtCarcompRepo CarsMtCarcompRepo => new CarsMtCarcompRepo(_context);
