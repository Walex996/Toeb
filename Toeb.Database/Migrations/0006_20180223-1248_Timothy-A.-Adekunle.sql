-- <Migration ID="9fa1aec5-055a-4955-92d1-f14ec92a8f34" />
GO

PRINT N'Altering [dbo].[AccountDetail]'
GO
EXEC sp_rename N'[dbo].[AccountDetail].[AccountName]', N'Name', N'COLUMN'
GO
