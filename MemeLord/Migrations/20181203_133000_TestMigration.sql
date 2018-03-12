CREATE TABLE dbo.TestTable (
  Id int IDENTITY,
  Name varchar(50) NOT NULL,
  Age int NOT NULL,
  CONSTRAINT PK_TestTable_Id PRIMARY KEY CLUSTERED (Id)
)