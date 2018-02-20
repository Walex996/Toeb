-- <Migration ID="00cbb90b-7259-4cf5-baeb-c23950e28294" />
GO

PRINT N'Creating [dbo].[Estate]'
GO
CREATE TABLE [dbo].[Estate]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[Name] [nvarchar] (100) NOT NULL,
[Location] [nvarchar] (max) NOT NULL
)
GO
PRINT N'Creating primary key [PK_Estate] on [dbo].[Estate]'
GO
ALTER TABLE [dbo].[Estate] ADD CONSTRAINT [PK_Estate] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Building]'
GO
CREATE TABLE [dbo].[Building]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[EstateId] [int] NOT NULL,
[NumberOfFlat] [int] NOT NULL,
[NumberOfTenant] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Building] on [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[User]'
GO
CREATE TABLE [dbo].[User]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (50) NOT NULL,
[LastName] [nvarchar] (50) NOT NULL,
[Role] [int] NOT NULL,
[CreatedAt] [datetime] NOT NULL
)
GO
PRINT N'Creating primary key [PK_User] on [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Complaint]'
GO
CREATE TABLE [dbo].[Complaint]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[BuildingId] [int] NOT NULL,
[Title] [nvarchar] (max) NOT NULL,
[Content] [text] NOT NULL,
[Date] [datetime] NOT NULL,
[Status] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Complaint] on [dbo].[Complaint]'
GO
ALTER TABLE [dbo].[Complaint] ADD CONSTRAINT [PK_Complaint] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Event]'
GO
CREATE TABLE [dbo].[Event]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[EventName] [nvarchar] (50) NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL,
[InviteType] [text] NOT NULL,
[Occurence] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Event] on [dbo].[Event]'
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[ServiceCharge]'
GO
CREATE TABLE [dbo].[ServiceCharge]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) NOT NULL,
[Amount] [decimal] (18, 2) NOT NULL,
[AccountNumber] [nvarchar] (50) NOT NULL,
[AccountName] [nvarchar] (100) NOT NULL,
[AccountType] [int] NOT NULL,
[IsCompulsory] [bit] NOT NULL,
[Date] [datetime] NOT NULL,
[TotalAmountPaid] [decimal] (18, 2) NOT NULL,
[UserId] [int] NOT NULL,
[BuildingId] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_ServiceCharge] on [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [PK_ServiceCharge] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Structure]'
GO
CREATE TABLE [dbo].[Structure]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Type] [nvarchar] (50) NOT NULL,
[NumberOfFlat] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Structure] on [dbo].[Structure]'
GO
ALTER TABLE [dbo].[Structure] ADD CONSTRAINT [PK_Structure] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Subscription]'
GO
CREATE TABLE [dbo].[Subscription]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) NOT NULL,
[Price] [decimal] (18, 2) NOT NULL,
[TenantLimit] [int] NOT NULL,
[Duration] [int] NOT NULL,
[DateCreated] [datetime] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Subscription] on [dbo].[Subscription]'
GO
ALTER TABLE [dbo].[Subscription] ADD CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Complaint]'
GO
ALTER TABLE [dbo].[Complaint] ADD CONSTRAINT [FK_Complaint_Building] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[Complaint] ADD CONSTRAINT [FK_Complaint_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [FK_ServiceCharge_Building] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [FK_ServiceCharge_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [FK_Building_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [FK_Building_Estate] FOREIGN KEY ([EstateId]) REFERENCES [dbo].[Estate] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Estate]'
GO
ALTER TABLE [dbo].[Estate] ADD CONSTRAINT [FK_Estate_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Event]'
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [FK_Event_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
