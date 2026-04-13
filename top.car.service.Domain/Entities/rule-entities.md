## Goal
Generate C# entity classes from table definitions in sql-script.sql.

## Namespace
Use:
namespace top.car.service.Domain.Entities;

## Class Naming
- Convert table name to PascalCase.
- Examples:
  - BZ_MASTER_GL -> BzMasterGl
  - CARS_APPROVER_DETAIL -> CarsApproverDetail
  - CARS_WF_PROCESS -> CarsWfProcess

## Base Class Rule
- If table has PRIMARY KEY and key type is TEXT:
  - inherit BaseEntityWithString
- If table has PRIMARY KEY and key type is INTEGER:
  - inherit BaseEntityWithId
- If table has no PRIMARY KEY:
  - inherit BaseEntity

## Primary Key Rule
- If primary key column name is ID and class inherits BaseEntityWithId or BaseEntityWithString:
  - do not generate property Id again
- If primary key column name is not ID:
  - override Id and map with [Column("REAL_PK_COLUMN")]
- Examples:
  - GL_NO TEXT PRIMARY KEY -> public override string Id { get; set; } = "";
  - EMPLOYEEID TEXT PRIMARY KEY -> public override string Id { get; set; } = "";
  - ID INTEGER PRIMARY KEY AUTOINCREMENT -> use inherited Id from BaseEntityWithId

## Property Naming
- Convert column name to PascalCase.
- Examples:
  - GL_DESC -> GlDesc
  - CREATED_DATE -> CreatedDate
  - USERSTATUS -> UserStatus
  - REPORTTOEMAIL -> ReportToEmail

## Attribute Rule
- Every class must have:
  - [Table("TABLE_NAME")]
- Every generated property must have:
  - [Column("COLUMN_NAME")]

## Type Mapping
- TEXT -> string?
- INTEGER -> int?
- INTEGER PRIMARY KEY -> int
- TEXT PRIMARY KEY -> string

## BaseEntity Audit Columns
These columns already exist in BaseEntity and must not be generated again:
- CREATED_DATE
- CREATED_BY
- UPDATED_DATE
- UPDATED_BY
- CREATE_DATE
- USER_CREATE
- UPDATE_DATE
- USER_UPDATE

## Output Example

Table:
CREATE TABLE "BZ_MASTER_GL" (
  "GL_NO" TEXT PRIMARY KEY,
  "GL_DESC" TEXT,
  "TOKEN" TEXT,
  "USERSTATUS" INTEGER,
  "CREATED_DATE" TEXT DEFAULT CURRENT_TIMESTAMP,
  "CREATED_BY" TEXT,
  "UPDATED_DATE" TEXT,
  "UPDATED_BY" TEXT
);

Expected entity:
using System.ComponentModel.DataAnnotations.Schema;

namespace top.car.service.Domain.Entities;

[Table("BZ_MASTER_GL")]
public class BzMasterGl : BaseEntityWithString
{
    [Column("GL_NO")]
    public override string Id { get; set; } = "";

    [Column("GL_DESC")]
    public string? GlDesc { get; set; }

    [Column("TOKEN")]
    public string? Token { get; set; }

    [Column("USERSTATUS")]
    public int? UserStatus { get; set; }
}