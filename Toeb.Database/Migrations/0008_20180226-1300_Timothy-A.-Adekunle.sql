-- <Migration ID="53692d0d-7496-4ffc-95aa-30cb702e33f2" />
GO

PRINT N'Altering [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD
[Password] [nvarchar] (50) NULL
GO
