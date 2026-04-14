# EF Core Relationships Configuration Guide

## Overview
EF Core supports three main relationship types: **1:1 (One-to-One)**, **1:N (One-to-Many)**, และ **N:N (Many-to-Many)**

---

## 1. One-to-One (1:1) Relationship

### Scenario
Parent entity มีคู่ที่ไม่ซ้ำกัน เช่น **User** 1 คน มี **Profile** 1 อัน

### Entity Definition
```csharp
public class User
{
    public int UserId { get; set; }
    public string? Name { get; set; }
    
    // Navigation property
    public UserProfile? UserProfile { get; set; }
}

public class UserProfile
{
    public int UserProfileId { get; set; }
    [Column("USER_ID")]
    public int UserId { get; set; }  // Foreign Key
    public string? Bio { get; set; }
    
    // Navigation property
    public User? User { get; set; }
}
```

### Configuration (IEntityTypeConfiguration)

**Option 1: Configure from Principal (User)**
```csharp
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.UserProfile)
               .WithOne(p => p.User)
               .HasForeignKey<UserProfile>(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
```

**Option 2: Configure from Dependent (UserProfile)**
```csharp
public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasOne(p => p.User)
               .WithOne(u => u.UserProfile)
               .HasForeignKey<UserProfile>(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
```

---

## 2. One-to-Many (1:N) Relationship

### Scenario
Parent entity มีหลาย child entities เช่น **CarsDetailReq** 1 อัน มี **CarsDetailBooking** หลายอัน

### Entity Definition
```csharp
public class CarsDetailReq : BaseEntityWithId
{
    [Column("DOC_NO")]
    public string? DocNo { get; set; }
    
    // Navigation property (One)
    public ICollection<CarsDetailBooking> CarsDetailBookings { get; set; } = [];
}

public class CarsDetailBooking : BaseEntityWithId
{
    [Column("ITEM_NO")]
    public int? ItemNo { get; set; }
    
    [Column("CARS_DETAIL_REQ_ID")]
    public int? CarsDetailReqId { get; set; }  // Foreign Key
    
    // Navigation property (Many)
    public CarsDetailReq? CarsDetailReq { get; set; }
    public ICollection<CarsDetailTraveler> CarsDetailTravelers { get; set; } = [];
}
```

### Configuration (IEntityTypeConfiguration)

**Option 1: Configure from Principal (CarsDetailReq)**
```csharp
public class CarsDetailReqConfiguration : IEntityTypeConfiguration<CarsDetailReq>
{
    public void Configure(EntityTypeBuilder<CarsDetailReq> builder)
    {
        builder.HasMany(r => r.CarsDetailBookings)     // Req มีหลาย Booking
               .WithOne(b => b.CarsDetailReq)           // Booking มี Req เดียว
               .HasForeignKey(b => b.CarsDetailReqId)   // Explicit FK
               .OnDelete(DeleteBehavior.Cascade);       // Cascade delete
    }
}
```

**Option 2: Configure from Dependent (CarsDetailBooking)**
```csharp
public class CarsDetailBookingConfiguration : IEntityTypeConfiguration<CarsDetailBooking>
{
    public void Configure(EntityTypeBuilder<CarsDetailBooking> builder)
    {
        builder.HasOne(b => b.CarsDetailReq)           // Booking มี Req เดียว
               .WithMany(r => r.CarsDetailBookings)    // Req มีหลาย Booking
               .HasForeignKey(b => b.CarsDetailReqId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
```

**Option 3: Shadow Foreign Key (โดยไม่มี explicit FK property)**
```csharp
public class CarsDetailReqConfiguration : IEntityTypeConfiguration<CarsDetailReq>
{
    public void Configure(EntityTypeBuilder<CarsDetailReq> builder)
    {
        builder.HasMany(r => r.CarsDetailBookings)
               .WithOne(b => b.CarsDetailReq)
               .HasForeignKey("CarsDetailReqId")  // Shadow FK (string name)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
```

---

## 3. Many-to-Many (N:N) Relationship

### Scenario
**Students** และ **Courses** — นักเรียน 1 คนลงทะเบียนได้หลายวิชา วิชาหนึ่งมีนักเรียนหลายคน

### Entity Definition (ตัวอย่าง)
```csharp
public class Student
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    
    // Navigation property
    public ICollection<Course> Courses { get; set; } = [];
}

public class Course
{
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
    
    // Navigation property
    public ICollection<Student> Students { get; set; } = [];
}
```

### Configuration (ใช้ junction table โดยอัตโนมัติ)

**Option 1: EF Core 6+ (Payload-less N:N)**
```csharp
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasMany(s => s.Courses)
               .WithMany(c => c.Students)
               .UsingEntity(
                   "StudentCourse",  // Junction table name
                   l => l.HasOne(typeof(Course))
                         .WithMany()
                         .HasForeignKey("CourseId"),
                   r => r.HasOne(typeof(Student))
                         .WithMany()
                         .HasForeignKey("StudentId"),
                   j =>
                   {
                       j.HasKey("StudentId", "CourseId");
                       j.ToTable("STUDENT_COURSE");
                   }
               );
    }
}
```

**Option 2: N:N with Payload (with datetime, status, etc.)**

สร้าง entity กลาง:
```csharp
public class StudentCourse
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    
    [Column("ENROLLED_DATE")]
    public DateTime EnrolledDate { get; set; }
    
    [Column("STATUS")]
    public string? Status { get; set; }
    
    // Navigation properties
    public Student? Student { get; set; }
    public Course? Course { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    
    public ICollection<StudentCourse> StudentCourses { get; set; } = [];
}

public class Course
{
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
    
    public ICollection<StudentCourse> StudentCourses { get; set; } = [];
}
```

Configuration:
```csharp
public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });
        builder.ToTable("STUDENT_COURSE");
        
        builder.HasOne(sc => sc.Student)
               .WithMany(s => s.StudentCourses)
               .HasForeignKey(sc => sc.StudentId)
               .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(sc => sc.Course)
               .WithMany(c => c.StudentCourses)
               .HasForeignKey(sc => sc.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
```

---

## 4. Self-Referencing Relationship (Hierarchical)

### Scenario
Entity สามารถอ้างอิงตัวเองได้ เช่น **Employee** สามารถมี **Manager** (ซึ่งเป็น Employee คนอื่น)

### Entity Definition
```csharp
public class Employee
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    
    [Column("MANAGER_ID")]
    public int? ManagerId { get; set; }  // Foreign Key to self
    
    // Navigation properties
    public Employee? Manager { get; set; }
    public ICollection<Employee> Subordinates { get; set; } = [];
}
```

### Configuration
```csharp
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasOne(e => e.Manager)
               .WithMany(e => e.Subordinates)
               .HasForeignKey(e => e.ManagerId)
               .OnDelete(DeleteBehavior.Restrict);  // Prevent cycles
    }
}
```

---

## 5. Delete Behaviors

| Behavior | คำอธิบาย | EF Core | Database |
|----------|---------|--------|----------|
| **Cascade** | ลบ parent → ลบ child ด้วย | ✅ | ✅ (ต้องมี FK constraint) |
| **Restrict** | ห้ามลบ parent ถ้ามี child | ✅ | ⚠️ (partial) |
| **SetNull** | ลบ parent → set child FK เป็น NULL | ✅ | ✅ (ต้องมี FK constraint) |
| **NoAction** | ไม่ทำอะไร (default database behavior) | ❌ | ✅ |

```csharp
.OnDelete(DeleteBehavior.Cascade);      // ลบตัวแม่ ลบตัวลูกด้วย
.OnDelete(DeleteBehavior.Restrict);     // ห้ามลบตัวแม่
.OnDelete(DeleteBehavior.SetNull);      // ลบตัวแม่ → FK = null
.OnDelete(DeleteBehavior.NoAction);     // ปล่อยให้ database ดูแล
```

### ⚠️ Important: Fluent API vs Database Constraints

**ถ้าสถานการณ์:** ใน Fluent API มี relation ไว้ แต่ **database ไม่มี FK constraint**

**ผลลัพธ์:**
- ✅ **Navigation properties ทำงาน** - เช่น `req.CarsDetailBookings` สามารถก access ได้
- ✅ **EF Core checks FK in memory** - EF จะตรวจสอบ FK ขณะเก็บข้อมูล (change tracking)
- ❌ **Database-level integrity ไม่มี** - Database จะไม่บังคับ FK constraint ที่ query level
- ⚠️ **DeleteBehavior ทำงานต่างกัน:**
  - `Cascade`: EF Core ทำ delete ให้ child ใน memory, แต่ **database ไม่รู้** → data orphaned ได้
  - `Restrict`: EF ป้องกันการ delete เมื่อมี child ระดับ EF Core เท่านั้น
  - `SetNull`: EF ทำให้ FK = null, แต่ database ไม่รู้

**ตัวอย่าง:**
```sql
-- DB ไม่มี FK constraint
CREATE TABLE CARS_DETAIL_BOOKING (
    ID INT PRIMARY KEY,
    ITEM_NO INT,
    CARS_DETAIL_REQ_ID INT  -- ไม่มี FOREIGN KEY ที่นี่
);
```

```csharp
// EF Config มี relation
builder.HasMany(r => r.CarsDetailBookings)
       .WithOne(b => b.CarsDetailReq)
       .HasForeignKey(b => b.CarsDetailReqId)
       .OnDelete(DeleteBehavior.Cascade);  // ← ข้อมูลอาจไม่ delete ใน DB

// ใน code: EF จะ delete child
var req = context.CarsDetailReqs.Find(1);
context.CarsDetailReqs.Remove(req);  // EF ลบ booking ด้วย
await context.SaveChangesAsync();    // ✅ child ลบใน application
                                     // ⚠️ บาง DB อาจยังเหลือข้อมูล
```

### ✅ Best Practice
**ถ้าใช้ EF Core relation, ต้องมี FK constraint ใน database ด้วย:**

```sql
CREATE TABLE CARS_DETAIL_BOOKING (
    ID INT PRIMARY KEY,
    ITEM_NO INT,
    CARS_DETAIL_REQ_ID INT NOT NULL,
    FOREIGN KEY (CARS_DETAIL_REQ_ID) 
        REFERENCES CARS_DETAIL_REQ(ID) 
        ON DELETE CASCADE  -- ← สำคัญ!
);
```

**Sync ระหว่าง EF Config และ Database:**
```csharp
// ✅ ถูก
public class CarsDetailReqConfiguration : IEntityTypeConfiguration<CarsDetailReq>
{
    public void Configure(EntityTypeBuilder<CarsDetailReq> builder)
    {
        builder.HasMany(r => r.CarsDetailBookings)
               .WithOne(b => b.CarsDetailReq)
               .HasForeignKey(b => b.CarsDetailReqId)
               .OnDelete(DeleteBehavior.Cascade);  // ตรงกับ DB constraint
    }
}
```

หรือใช้ **EF Core Migrations** ให้สร้าง DB structure ให้:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 6. Using FluentAPI vs Data Annotations

### Data Annotations (Minimal)
```csharp
public class Book
{
    public int BookId { get; set; }
    
    [ForeignKey("AuthorId")]
    public Author? Author { get; set; }
    
    public int AuthorId { get; set; }
}

public class Author
{
    public int AuthorId { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}
```

### Fluent API (Recommended - More Control)
```csharp
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasOne(b => b.Author)
               .WithMany(a => a.Books)
               .HasForeignKey(b => b.AuthorId)
               .HasConstraintName("FK_Book_Author")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
```

### Mix Both (NOT Recommended)
❌ หลีกเลี่ยงการ mix annotations กับ fluent API เพราะ confusing

---

## 7. Navigation Property Loading Strategies

### Eager Loading (โหลดข้อมูลทั้งหมดในครั้งเดียว)
```csharp
var req = await context.CarsDetailReqs
    .Include(r => r.CarsDetailBookings)  // โหลด Booking ทั้งหมด
    .FirstOrDefaultAsync(r => r.Id == id);
```

### Explicit Loading (โหลดแยกส่วน)
```csharp
var req = await context.CarsDetailReqs.FirstOrDefaultAsync(r => r.Id == id);
await context.Entry(req)
    .Collection(r => r.CarsDetailBookings)
    .LoadAsync();
```

### Lazy Loading (ต้องเปิดใช้ใน DbContext)
```csharp
// ต้อง Install: Microsoft.EntityFrameworkCore.Proxies
services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies()
           .UseSqlite(connectionString));

// แล้วใช้แบบนี้ได้
var req = context.CarsDetailReqs.FirstOrDefault(r => r.Id == id);
var bookings = req.CarsDetailBookings;  // Lazy load อัตโนมัติ
```

---

## 8. Best Practices

1. ✅ **ใช้ Fluent API** ใน `IEntityTypeConfiguration` classes
2. ✅ **กำหนด FK explicitly** (อย่าพึ่ง shadow FK ถ้าต้อง query หรือ map)
3. ✅ **ใช้ Include() อย่างรู้เรื่อง** เพื่อลด N+1 query problem
4. ✅ **Set OnDelete behavior** ตั้งแต่ design
5. ✅ **ตั้งชื่อ table/column ชัดเจน** ใน `[Table]` และ `[Column]` attributes
6. ❌ **หลีกเลี่ยง circular references** โดยไม่ระบุ OnDelete behavior
7. ❌ **อย่าลืม register configuration** ใน AppDbContext (`ApplyConfigurationsFromAssembly`)

---

## 9. Example: Full Setup in DbContext

```csharp
public class AppDbContext : DbContext
{
    public DbSet<CarsDetailReq> CarsDetailReqs => Set<CarsDetailReq>();
    public DbSet<CarsDetailBooking> CarsDetailBookings => Set<CarsDetailBooking>();
    public DbSet<CarsDetailTraveler> CarsDetailTravelers => Set<CarsDetailTraveler>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Apply all IEntityTypeConfiguration<T> classes automatically
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
```

---

## 10. Reference Links

- [EF Core - Model Relationships](https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
- [EF Core - Foreign Keys](https://learn.microsoft.com/en-us/ef/core/modeling/relationships/foreign-and-principal-keys)
- [EF Core - Delete Behaviors](https://learn.microsoft.com/en-us/ef/core/saving/cascade-delete)
- [EF Core - Lazy Loading](https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy)
