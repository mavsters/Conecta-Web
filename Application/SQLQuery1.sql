IF EXISTS(SELECT * FROM sys.database_principals WHERE name = 'AdminConecta')
  DROP USER [AdminConecta]
  DROP LOGIN [AdminConecta]
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'AdminConecta')
  CREATE LOGIN [AdminConecta] WITH PASSWORD=N'Abcdefg@'
  ALTER LOGIN [AdminConecta] ENABLE;
  ALTER ROLE [mattasur-conecta-db] ADD MEMBER [AdminConecta];
GO




