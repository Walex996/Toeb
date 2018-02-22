-- <Migration ID="342b093c-0e49-4dca-a1e8-eefdd28c1849" />
GO

PRINT N'Altering [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD
[HouseNumber] [int] NOT NULL CONSTRAINT [DF_Building_HouseNumber] DEFAULT ((0))
GO
