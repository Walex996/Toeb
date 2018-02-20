-- <Migration ID="22c9e783-7df4-4ef2-a562-29ca34962ce9" />
GO

PRINT N'Dropping foreign keys from [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] DROP CONSTRAINT [FK_Building_Estate]
GO
ALTER TABLE [dbo].[Building] DROP CONSTRAINT [FK_Building_User]
GO
PRINT N'Dropping foreign keys from [dbo].[Complaint]'
GO
ALTER TABLE [dbo].[Complaint] DROP CONSTRAINT [FK_Complaint_Building]
GO
ALTER TABLE [dbo].[Complaint] DROP CONSTRAINT [FK_Complaint_User]
GO
PRINT N'Dropping foreign keys from [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] DROP CONSTRAINT [FK_ServiceCharge_Building]
GO
ALTER TABLE [dbo].[ServiceCharge] DROP CONSTRAINT [FK_ServiceCharge_User]
GO
PRINT N'Dropping foreign keys from [dbo].[Estate]'
GO
ALTER TABLE [dbo].[Estate] DROP CONSTRAINT [FK_Estate_User]
GO
PRINT N'Dropping foreign keys from [dbo].[Event]'
GO
ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_User]
GO
PRINT N'Dropping constraints from [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] DROP CONSTRAINT [PK_Building]
GO
PRINT N'Dropping constraints from [dbo].[Estate]'
GO
ALTER TABLE [dbo].[Estate] DROP CONSTRAINT [PK_Estate]
GO
PRINT N'Dropping constraints from [dbo].[Event]'
GO
ALTER TABLE [dbo].[Event] DROP CONSTRAINT [PK_Event]
GO
PRINT N'Dropping constraints from [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] DROP CONSTRAINT [PK_ServiceCharge]
GO
PRINT N'Dropping constraints from [dbo].[User]'
GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [PK_User]
GO
PRINT N'Rebuilding [dbo].[User]'
GO
CREATE TABLE [dbo].[RG_Recovery_1_User]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (50) NOT NULL,
[LastName] [nvarchar] (50) NOT NULL,
[Role] [int] NOT NULL,
[CreatedAt] [datetime] NOT NULL,
[EmailAddress] [nvarchar] (100) NOT NULL,
[PhoneNumber] [nvarchar] (50) NOT NULL,
[StateOfOriginId] [int] NOT NULL,
[NextOfKinId] [int] NOT NULL,
[Gender] [int] NOT NULL
)
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_1_User] ON
GO
INSERT INTO [dbo].[RG_Recovery_1_User]([Id], [FirstName], [LastName], [Role], [CreatedAt]) SELECT [Id], [FirstName], [LastName], [Role], [CreatedAt] FROM [dbo].[User]
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_1_User] OFF
GO
DECLARE @idVal BIGINT
SELECT @idVal = IDENT_CURRENT(N'[dbo].[User]')
IF @idVal IS NOT NULL
    DBCC CHECKIDENT(N'[dbo].[RG_Recovery_1_User]', RESEED, @idVal)
GO
DROP TABLE [dbo].[User]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_1_User]', N'User', N'OBJECT'
GO
PRINT N'Creating primary key [PK_User] on [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[AccountDetail]'
GO
CREATE TABLE [dbo].[AccountDetail]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AccountName] [nvarchar] (100) NOT NULL,
[AccountType] [int] NOT NULL,
[AccountNumber] [nvarchar] (50) NOT NULL,
[BankName] [nvarchar] (100) NOT NULL,
[EstateOwnerId] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_AccountDetails] on [dbo].[AccountDetail]'
GO
ALTER TABLE [dbo].[AccountDetail] ADD CONSTRAINT [PK_AccountDetails] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Rebuilding [dbo].[Estate]'
GO
CREATE TABLE [dbo].[RG_Recovery_2_Estate]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[Name] [nvarchar] (100) NOT NULL,
[Address] [nvarchar] (max) NOT NULL,
[City] [nvarchar] (50) NOT NULL,
[StateId] [int] NOT NULL,
[SubscriptionId] [int] NOT NULL,
[LgaId] [int] NULL
)
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_2_Estate] ON
GO
INSERT INTO [dbo].[RG_Recovery_2_Estate]([Id], [UserId], [Name], [Address]) SELECT [Id], [UserId], [Name], [Location] FROM [dbo].[Estate]
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_2_Estate] OFF
GO
DECLARE @idVal BIGINT
SELECT @idVal = IDENT_CURRENT(N'[dbo].[Estate]')
IF @idVal IS NOT NULL
    DBCC CHECKIDENT(N'[dbo].[RG_Recovery_2_Estate]', RESEED, @idVal)
GO
DROP TABLE [dbo].[Estate]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_2_Estate]', N'Estate', N'OBJECT'
GO
PRINT N'Creating primary key [PK_Estate] on [dbo].[Estate]'
GO
ALTER TABLE [dbo].[Estate] ADD CONSTRAINT [PK_Estate] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Rebuilding [dbo].[Building]'
GO
CREATE TABLE [dbo].[RG_Recovery_3_Building]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[EstateId] [int] NOT NULL,
[NumberOfFlat] [int] NOT NULL,
[NumberOfTenant] [int] NOT NULL,
[StructureId] [int] NOT NULL
)
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_3_Building] ON
GO
INSERT INTO [dbo].[RG_Recovery_3_Building]([Id], [UserId], [EstateId], [NumberOfFlat], [NumberOfTenant]) SELECT [Id], [UserId], [EstateId], [NumberOfFlat], [NumberOfTenant] FROM [dbo].[Building]
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_3_Building] OFF
GO
DECLARE @idVal BIGINT
SELECT @idVal = IDENT_CURRENT(N'[dbo].[Building]')
IF @idVal IS NOT NULL
    DBCC CHECKIDENT(N'[dbo].[RG_Recovery_3_Building]', RESEED, @idVal)
GO
DROP TABLE [dbo].[Building]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_3_Building]', N'Building', N'OBJECT'
GO
PRINT N'Creating primary key [PK_Building] on [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Altering [dbo].[Complaint]'
GO
EXEC sp_rename N'[dbo].[Complaint].[UserId]', N'TenantId', N'COLUMN'
GO
PRINT N'Creating [dbo].[State]'
GO
CREATE TABLE [dbo].[State]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[StateName] [nvarchar] (50) NOT NULL
)
GO
PRINT N'Creating primary key [PK_State] on [dbo].[State]'
GO
ALTER TABLE [dbo].[State] ADD CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Rebuilding [dbo].[Event]'
GO
CREATE TABLE [dbo].[RG_Recovery_4_Event]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[UserId] [int] NOT NULL,
[EventName] [nvarchar] (50) NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL,
[InviteType] [text] NOT NULL,
[Occurence] [int] NOT NULL,
[EstateId] [int] NOT NULL
)
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_4_Event] ON
GO
INSERT INTO [dbo].[RG_Recovery_4_Event]([Id], [UserId], [EventName], [StartDate], [EndDate], [InviteType], [Occurence]) SELECT [Id], [UserId], [EventName], [StartDate], [EndDate], [InviteType], [Occurence] FROM [dbo].[Event]
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_4_Event] OFF
GO
DECLARE @idVal BIGINT
SELECT @idVal = IDENT_CURRENT(N'[dbo].[Event]')
IF @idVal IS NOT NULL
    DBCC CHECKIDENT(N'[dbo].[RG_Recovery_4_Event]', RESEED, @idVal)
GO
DROP TABLE [dbo].[Event]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_4_Event]', N'Event', N'OBJECT'
GO
PRINT N'Creating primary key [PK_Event] on [dbo].[Event]'
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Rebuilding [dbo].[ServiceCharge]'
GO
CREATE TABLE [dbo].[RG_Recovery_5_ServiceCharge]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) NOT NULL,
[Amount] [decimal] (18, 2) NOT NULL,
[IsCompulsory] [bit] NOT NULL,
[DateCreated] [datetime] NOT NULL,
[TotalAmountPaid] [decimal] (18, 2) NULL,
[EstateOwnerId] [int] NOT NULL,
[BuildingId] [int] NOT NULL,
[AccountId] [int] NOT NULL,
[DueDay] [int] NOT NULL,
[DueMonth] [int] NOT NULL
)
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_5_ServiceCharge] ON
GO
INSERT INTO [dbo].[RG_Recovery_5_ServiceCharge]([Id], [Name], [Amount], [IsCompulsory], [DateCreated], [TotalAmountPaid], [EstateOwnerId], [BuildingId], [AccountId]) SELECT [Id], [Name], [Amount], [IsCompulsory], [Date], [TotalAmountPaid], [UserId], [BuildingId], [AccountType] FROM [dbo].[ServiceCharge]
GO
SET IDENTITY_INSERT [dbo].[RG_Recovery_5_ServiceCharge] OFF
GO
DECLARE @idVal BIGINT
SELECT @idVal = IDENT_CURRENT(N'[dbo].[ServiceCharge]')
IF @idVal IS NOT NULL
    DBCC CHECKIDENT(N'[dbo].[RG_Recovery_5_ServiceCharge]', RESEED, @idVal)
GO
DROP TABLE [dbo].[ServiceCharge]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_5_ServiceCharge]', N'ServiceCharge', N'OBJECT'
GO
PRINT N'Creating primary key [PK_ServiceCharge] on [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [PK_ServiceCharge] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Tenant]'
GO
CREATE TABLE [dbo].[Tenant]
(
[UserId] [int] NOT NULL,
[BuildingId] [int] NOT NULL,
[EstateId] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK_Tenant] on [dbo].[Tenant]'
GO
ALTER TABLE [dbo].[Tenant] ADD CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED  ([UserId])
GO
PRINT N'Creating [dbo].[NextOfKin]'
GO
CREATE TABLE [dbo].[NextOfKin]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[FullName] [nvarchar] (100) NOT NULL,
[Gender] [int] NOT NULL,
[PhoneNumber] [nvarchar] (50) NOT NULL,
[EmailAddress] [nvarchar] (50) NOT NULL,
[Relationship] [nvarchar] (50) NOT NULL
)
GO
PRINT N'Creating primary key [PK_NextOfKin] on [dbo].[NextOfKin]'
GO
ALTER TABLE [dbo].[NextOfKin] ADD CONSTRAINT [PK_NextOfKin] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [FK_ServiceCharge_AccountDetail] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[AccountDetail] ([Id])
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [FK_ServiceCharge_Building] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[ServiceCharge] ADD CONSTRAINT [FK_ServiceCharge_User] FOREIGN KEY ([EstateOwnerId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[AccountDetail]'
GO
ALTER TABLE [dbo].[AccountDetail] ADD CONSTRAINT [FK_AccountDetail_User] FOREIGN KEY ([EstateOwnerId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [FK_Building_Estate] FOREIGN KEY ([EstateId]) REFERENCES [dbo].[Estate] ([Id])
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [FK_Building_Structure] FOREIGN KEY ([StructureId]) REFERENCES [dbo].[Structure] ([Id])
GO
ALTER TABLE [dbo].[Building] ADD CONSTRAINT [FK_Building_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Complaint]'
GO
ALTER TABLE [dbo].[Complaint] ADD CONSTRAINT [FK_Complaint_Building] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[Complaint] ADD CONSTRAINT [FK_Complaint_User] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Tenant]'
GO
ALTER TABLE [dbo].[Tenant] ADD CONSTRAINT [FK_Tenant_Building] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id])
GO
ALTER TABLE [dbo].[Tenant] ADD CONSTRAINT [FK_Tenant_Estate] FOREIGN KEY ([EstateId]) REFERENCES [dbo].[Estate] ([Id])
GO
ALTER TABLE [dbo].[Tenant] ADD CONSTRAINT [FK_Tenant_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Estate]'
GO
ALTER TABLE [dbo].[Estate] ADD CONSTRAINT [FK_Estate_State] FOREIGN KEY ([StateId]) REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Estate] ADD CONSTRAINT [FK_Estate_Subscription] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscription] ([Id])
GO
ALTER TABLE [dbo].[Estate] ADD CONSTRAINT [FK_Estate_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Event]'
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [FK_Event_Estate] FOREIGN KEY ([EstateId]) REFERENCES [dbo].[Estate] ([Id])
GO
ALTER TABLE [dbo].[Event] ADD CONSTRAINT [FK_Event_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_NextOfKin] FOREIGN KEY ([NextOfKinId]) REFERENCES [dbo].[NextOfKin] ([Id])
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_State] FOREIGN KEY ([StateOfOriginId]) REFERENCES [dbo].[State] ([Id])
GO
