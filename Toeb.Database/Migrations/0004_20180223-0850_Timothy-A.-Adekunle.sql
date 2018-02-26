-- <Migration ID="1da6e69d-b6da-4da0-8ca0-80789fe62a2c" />
GO

PRINT N'Altering [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD
[HouseNumber] [int] NOT NULL CONSTRAINT [DF_Building_HouseNumber] DEFAULT ((0))
GO
