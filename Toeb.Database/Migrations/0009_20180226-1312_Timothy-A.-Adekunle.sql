-- <Migration ID="b2b3a159-7400-4407-83ff-a12047d22620" />
GO

PRINT N'Altering [dbo].[Event]'
GO
EXEC sp_rename N'[dbo].[Event].[EventName]', N'Name', N'COLUMN'
GO
