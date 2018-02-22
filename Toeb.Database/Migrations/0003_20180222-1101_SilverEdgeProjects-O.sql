-- <Migration ID="39a58db0-57ee-4dcc-b8b0-f02518892285" />
GO

PRINT N'Altering [dbo].[State]'
GO
EXEC sp_rename N'[dbo].[State].[StateName]', N'Name', N'COLUMN'
GO
