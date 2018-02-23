-- <Migration ID="d501ecf2-7acf-4409-9034-96abe60aa20b" />
GO

PRINT N'Altering [dbo].[AccountDetail]'
GO
EXEC sp_rename N'[dbo].[AccountDetail].[AccountType]', N'Type', N'COLUMN'
GO
EXEC sp_rename N'[dbo].[AccountDetail].[AccountNumber]', N'Number', N'COLUMN'
GO
