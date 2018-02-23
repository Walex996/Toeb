-- <Migration ID="02030ceb-7be4-47d2-b01a-2b9ab7f18791" />
GO

PRINT N'Altering [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] ADD
[BuildingIds] [nvarchar] (max) NULL
GO
