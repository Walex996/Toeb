﻿/*
	Target database:	Alabagbe
	Target instance:	SILVEREDGE
	Generated date:		2/23/2018 4:45:19 PM
	Generated on:		SILVEREDGE
	Package version:	(undefined)
	Migration version:	(n/a)
	Baseline version:	(n/a)
	ReadyRoll version:	1.14.12.4663
	Migrations pending:	4

	IMPORTANT! "SQLCMD Mode" must be activated prior to execution (under the Query menu in SSMS).

	BEFORE EXECUTING THIS SCRIPT, WE STRONGLY RECOMMEND YOU TAKE A BACKUP OF YOUR DATABASE.

	This SQLCMD script is designed to be executed through MSBuild (via the .sqlproj Deploy target) however 
	it can also be run manually using SQL Management Studio. 

	It was generated by the ReadyRoll build task and contains logic to deploy the database, ensuring that 
	each of the incremental migrations is executed a single time only in alphabetical (filename) 
	order. If any errors occur within those scripts, the deployment will be aborted and the transaction
	rolled-back.

	NOTE: Automatic transaction management is provided for incremental migrations, so you don't need to
		  add any special BEGIN TRAN/COMMIT/ROLLBACK logic in those script files. 
		  However if you require transaction handling in your Pre/Post-Deployment scripts, you will
		  need to add this logic to the source .sql files yourself.
*/

----====================================================================================================================
---- SQLCMD Variables

:setvar DatabaseName "Alabagbe"
:setvar ReleaseVersion ""
:setvar ForceDeployWithoutBaseline "False"
:setvar DeployPath "C:\Users\Seyi\Documents\ProjectsEstate\Toeb\Toeb.Database\"
:setvar DefaultFilePrefix "Alabagbe"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultBackupPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\"
----====================================================================================================================

:on error exit -- Instructs SQLCMD to abort execution as soon as an erroneous batch is encountered

:setvar PackageVersion "(undefined)"

GO
:setvar IsSqlCmdEnabled "True"
GO


GO

SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;
SET XACT_ABORT ON; -- Abort the current batch immediately if a statement raises a run-time error and rollback any open transaction(s)

IF N'$(IsSqlCmdEnabled)' <> N'True' -- Is SQLCMD mode not enabled within the execution context (eg. SSMS)
	BEGIN
		IF IS_SRVROLEMEMBER(N'sysadmin') = 1
			BEGIN -- User is sysadmin; abort execution by disconnect the script from the database server
				RAISERROR(N'This script must be run in SQLCMD Mode (under the Query menu in SSMS). Aborting connection to suppress subsequent errors.', 20, 127, N'UNKNOWN') WITH LOG;
			END
		ELSE
			BEGIN -- User is not sysadmin; abort execution by switching off statement execution (script will continue to the end without performing any actual deployment work)
				RAISERROR(N'This script must be run in SQLCMD Mode (under the Query menu in SSMS). Script execution has been halted.', 16, 127, N'UNKNOWN') WITH NOWAIT;
			END
	END
GO
IF @@ERROR != 0
	BEGIN
		SET NOEXEC ON; -- SQLCMD is NOT enabled so prevent any further statements from executing
	END
GO
-- Beyond this point, no further explicit error handling is required because it can be assumed that SQLCMD mode is enabled

IF SERVERPROPERTY('EngineEdition') = 5 AND DB_NAME() != N'$(DatabaseName)'
  RAISERROR(N'Azure SQL Database does not support switching between databases. Connect to [$(DatabaseName)] and then re-run the script.', 16, 127);

-- As this script has been generated for a specific server instance/database combination, stop execution if there is a mismatch
IF (@@SERVERNAME != 'SILVEREDGE' OR '$(DatabaseName)' != 'Alabagbe')
BEGIN
	RAISERROR(N'This script should only be executed on the following server/instance: [SILVEREDGE] (Database: [Alabagbe]). Halting deployment.', 16, 127, N'UNKNOWN') WITH NOWAIT;
	RETURN;
END
GO







------------------------------------------------------------------------------------------------------------------------
------------------------------------------       PRE-DEPLOYMENT SCRIPTS       ------------------------------------------
------------------------------------------------------------------------------------------------------------------------

SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

PRINT '----- executing pre-deployment script "Pre-Deployment\01_Create_Database.sql" -----';

------------------------- BEGIN PRE-DEPLOYMENT SCRIPT: "Pre-Deployment\01_Create_Database.sql" ---------------------------
GO
IF (DB_ID(N'$(DatabaseName)') IS NULL)
BEGIN
	PRINT N'Creating $(DatabaseName)...';
END
GO
IF (DB_ID(N'$(DatabaseName)') IS NULL)
BEGIN
	CREATE DATABASE [$(DatabaseName)]; -- MODIFY THIS STATEMENT TO SPECIFY A COLLATION FOR YOUR DATABASE
END

GO
-------------------------- END PRE-DEPLOYMENT SCRIPT: "Pre-Deployment\01_Create_Database.sql" ----------------------------









------------------------------------------------------------------------------------------------------------------------
------------------------------------------       INCREMENTAL MIGRATIONS       ------------------------------------------
------------------------------------------------------------------------------------------------------------------------

SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;

SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

GO
IF DB_ID('$(DatabaseName)') IS NULL
  PRINT 'Creating [$(DatabaseName)]...';

GO
IF DB_ID('$(DatabaseName)') IS NULL
  CREATE DATABASE [$(DatabaseName)];

GO
SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;

SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

GO
PRINT '# Beginning transaction';

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

GO
IF DB_ID('$(DatabaseName)') IS NULL
  RAISERROR ('The database [$(DatabaseName)] could not be found. Please ensure that there is a Pre-Deployment script within your project that contains a CREATE DATABASE statement (e.g. Pre-Deployment\01_Create_Database.sql).', 16, 127);

GO
IF DB_NAME() != '$(DatabaseName)'
  USE [$(DatabaseName)];

GO
SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;

SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

GO
IF DB_NAME() != '$(DatabaseName)'
  USE [$(DatabaseName)];

GO
IF EXISTS (SELECT 1 FROM [$(DatabaseName)].[dbo].[__MigrationLogCurrent] WHERE [migration_id] = CAST ('1da6e69d-b6da-4da0-8ca0-80789fe62a2c' AS UNIQUEIDENTIFIER))
  BEGIN
    IF @@TRANCOUNT > 0
      ROLLBACK;
    RAISERROR ('This script "Migrations\0004_20180223-0850_Timothy-A.-Adekunle.sql" has already been executed within the "$(DatabaseName)" database on this server. Halting deployment.', 16, 127);
    RETURN;
  END

GO
PRINT '

***** EXECUTING MIGRATION "Migrations\0004_20180223-0850_Timothy-A.-Adekunle.sql", ID: {1da6e69d-b6da-4da0-8ca0-80789fe62a2c} *****';

GO


----------------- BEGIN INCREMENTAL MIGRATION: "Migrations\0004_20180223-0850_Timothy-A.-Adekunle.sql" -------------------
GO
-- <Migration ID="1da6e69d-b6da-4da0-8ca0-80789fe62a2c" />
GO

PRINT N'Altering [dbo].[Building]'
GO
ALTER TABLE [dbo].[Building] ADD
[HouseNumber] [int] NOT NULL CONSTRAINT [DF_Building_HouseNumber] DEFAULT ((0))
GO

------------------ END INCREMENTAL MIGRATION: "Migrations\0004_20180223-0850_Timothy-A.-Adekunle.sql" --------------------


GO
IF @@TRANCOUNT <> 1
  BEGIN
    DECLARE @ErrorMessage AS NVARCHAR (4000);
    SET @ErrorMessage = 'This migration "Migrations\0004_20180223-0850_Timothy-A.-Adekunle.sql" has left the transaction in an invalid or closed state (@@TRANCOUNT=' + CAST (@@TRANCOUNT AS NVARCHAR (10)) + '). Please ensure exactly 1 transaction is open by the end of the migration script.  Rolling-back any pending transactions.';
    RAISERROR (@ErrorMessage, 16, 127);
    RETURN;
  END

INSERT [$(DatabaseName)].[dbo].[__MigrationLog] ([migration_id], [script_checksum], [script_filename], [complete_dt], [applied_by], [deployed], [version], [package_version], [release_version])
VALUES                                         (CAST ('1da6e69d-b6da-4da0-8ca0-80789fe62a2c' AS UNIQUEIDENTIFIER), '853C5BC0A255FC1B50EE64324AD87E1752B47935E77DD6E3BDF8D801CF6D31CF', '0004_20180223-0850_Timothy-A.-Adekunle.sql', SYSDATETIME(), SYSTEM_USER, 1, NULL, '$(PackageVersion)', CASE '$(ReleaseVersion)' WHEN '' THEN NULL ELSE '$(ReleaseVersion)' END);

PRINT '***** FINISHED EXECUTING MIGRATION "Migrations\0004_20180223-0850_Timothy-A.-Adekunle.sql", ID: {1da6e69d-b6da-4da0-8ca0-80789fe62a2c} *****
';

GO
SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;

SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

GO
IF DB_NAME() != '$(DatabaseName)'
  USE [$(DatabaseName)];

GO
IF EXISTS (SELECT 1 FROM [$(DatabaseName)].[dbo].[__MigrationLogCurrent] WHERE [migration_id] = CAST ('02030ceb-7be4-47d2-b01a-2b9ab7f18791' AS UNIQUEIDENTIFIER))
  BEGIN
    IF @@TRANCOUNT > 0
      ROLLBACK;
    RAISERROR ('This script "Migrations\0005_20180223-1002_Timothy-A.-Adekunle.sql" has already been executed within the "$(DatabaseName)" database on this server. Halting deployment.', 16, 127);
    RETURN;
  END

GO
PRINT '

***** EXECUTING MIGRATION "Migrations\0005_20180223-1002_Timothy-A.-Adekunle.sql", ID: {02030ceb-7be4-47d2-b01a-2b9ab7f18791} *****';

GO


----------------- BEGIN INCREMENTAL MIGRATION: "Migrations\0005_20180223-1002_Timothy-A.-Adekunle.sql" -------------------
GO
-- <Migration ID="02030ceb-7be4-47d2-b01a-2b9ab7f18791" />
GO

PRINT N'Altering [dbo].[ServiceCharge]'
GO
ALTER TABLE [dbo].[ServiceCharge] ADD
[BuildingIds] [nvarchar] (max) NULL
GO

------------------ END INCREMENTAL MIGRATION: "Migrations\0005_20180223-1002_Timothy-A.-Adekunle.sql" --------------------


GO
IF @@TRANCOUNT <> 1
  BEGIN
    DECLARE @ErrorMessage AS NVARCHAR (4000);
    SET @ErrorMessage = 'This migration "Migrations\0005_20180223-1002_Timothy-A.-Adekunle.sql" has left the transaction in an invalid or closed state (@@TRANCOUNT=' + CAST (@@TRANCOUNT AS NVARCHAR (10)) + '). Please ensure exactly 1 transaction is open by the end of the migration script.  Rolling-back any pending transactions.';
    RAISERROR (@ErrorMessage, 16, 127);
    RETURN;
  END

INSERT [$(DatabaseName)].[dbo].[__MigrationLog] ([migration_id], [script_checksum], [script_filename], [complete_dt], [applied_by], [deployed], [version], [package_version], [release_version])
VALUES                                         (CAST ('02030ceb-7be4-47d2-b01a-2b9ab7f18791' AS UNIQUEIDENTIFIER), '020864EE8ED2CB318E293863479A572D10B0C934E18503E9A5AE027ACBC6AD62', '0005_20180223-1002_Timothy-A.-Adekunle.sql', SYSDATETIME(), SYSTEM_USER, 1, NULL, '$(PackageVersion)', CASE '$(ReleaseVersion)' WHEN '' THEN NULL ELSE '$(ReleaseVersion)' END);

PRINT '***** FINISHED EXECUTING MIGRATION "Migrations\0005_20180223-1002_Timothy-A.-Adekunle.sql", ID: {02030ceb-7be4-47d2-b01a-2b9ab7f18791} *****
';

GO
SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;

SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

GO
IF DB_NAME() != '$(DatabaseName)'
  USE [$(DatabaseName)];

GO
IF EXISTS (SELECT 1 FROM [$(DatabaseName)].[dbo].[__MigrationLogCurrent] WHERE [migration_id] = CAST ('9fa1aec5-055a-4955-92d1-f14ec92a8f34' AS UNIQUEIDENTIFIER))
  BEGIN
    IF @@TRANCOUNT > 0
      ROLLBACK;
    RAISERROR ('This script "Migrations\0006_20180223-1248_Timothy-A.-Adekunle.sql" has already been executed within the "$(DatabaseName)" database on this server. Halting deployment.', 16, 127);
    RETURN;
  END

GO
PRINT '

***** EXECUTING MIGRATION "Migrations\0006_20180223-1248_Timothy-A.-Adekunle.sql", ID: {9fa1aec5-055a-4955-92d1-f14ec92a8f34} *****';

GO


----------------- BEGIN INCREMENTAL MIGRATION: "Migrations\0006_20180223-1248_Timothy-A.-Adekunle.sql" -------------------
GO
-- <Migration ID="9fa1aec5-055a-4955-92d1-f14ec92a8f34" />
GO

PRINT N'Altering [dbo].[AccountDetail]'
GO
EXEC sp_rename N'[dbo].[AccountDetail].[AccountName]', N'Name', N'COLUMN'
GO

------------------ END INCREMENTAL MIGRATION: "Migrations\0006_20180223-1248_Timothy-A.-Adekunle.sql" --------------------


GO
IF @@TRANCOUNT <> 1
  BEGIN
    DECLARE @ErrorMessage AS NVARCHAR (4000);
    SET @ErrorMessage = 'This migration "Migrations\0006_20180223-1248_Timothy-A.-Adekunle.sql" has left the transaction in an invalid or closed state (@@TRANCOUNT=' + CAST (@@TRANCOUNT AS NVARCHAR (10)) + '). Please ensure exactly 1 transaction is open by the end of the migration script.  Rolling-back any pending transactions.';
    RAISERROR (@ErrorMessage, 16, 127);
    RETURN;
  END

INSERT [$(DatabaseName)].[dbo].[__MigrationLog] ([migration_id], [script_checksum], [script_filename], [complete_dt], [applied_by], [deployed], [version], [package_version], [release_version])
VALUES                                         (CAST ('9fa1aec5-055a-4955-92d1-f14ec92a8f34' AS UNIQUEIDENTIFIER), 'ADEB6DCC814D53E683DDC5E060EB00B8B66B9B52F566BD7108E19D00CBFC1C4B', '0006_20180223-1248_Timothy-A.-Adekunle.sql', SYSDATETIME(), SYSTEM_USER, 1, NULL, '$(PackageVersion)', CASE '$(ReleaseVersion)' WHEN '' THEN NULL ELSE '$(ReleaseVersion)' END);

PRINT '***** FINISHED EXECUTING MIGRATION "Migrations\0006_20180223-1248_Timothy-A.-Adekunle.sql", ID: {9fa1aec5-055a-4955-92d1-f14ec92a8f34} *****
';

GO
SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;

SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

GO
IF DB_NAME() != '$(DatabaseName)'
  USE [$(DatabaseName)];

GO
IF EXISTS (SELECT 1 FROM [$(DatabaseName)].[dbo].[__MigrationLogCurrent] WHERE [migration_id] = CAST ('d501ecf2-7acf-4409-9034-96abe60aa20b' AS UNIQUEIDENTIFIER))
  BEGIN
    IF @@TRANCOUNT > 0
      ROLLBACK;
    RAISERROR ('This script "Migrations\0007_20180223-1305_Timothy-A.-Adekunle.sql" has already been executed within the "$(DatabaseName)" database on this server. Halting deployment.', 16, 127);
    RETURN;
  END

GO
PRINT '

***** EXECUTING MIGRATION "Migrations\0007_20180223-1305_Timothy-A.-Adekunle.sql", ID: {d501ecf2-7acf-4409-9034-96abe60aa20b} *****';

GO


----------------- BEGIN INCREMENTAL MIGRATION: "Migrations\0007_20180223-1305_Timothy-A.-Adekunle.sql" -------------------
GO
-- <Migration ID="d501ecf2-7acf-4409-9034-96abe60aa20b" />
GO

PRINT N'Altering [dbo].[AccountDetail]'
GO
EXEC sp_rename N'[dbo].[AccountDetail].[AccountType]', N'Type', N'COLUMN'
GO
EXEC sp_rename N'[dbo].[AccountDetail].[AccountNumber]', N'Number', N'COLUMN'
GO

------------------ END INCREMENTAL MIGRATION: "Migrations\0007_20180223-1305_Timothy-A.-Adekunle.sql" --------------------


GO
IF @@TRANCOUNT <> 1
  BEGIN
    DECLARE @ErrorMessage AS NVARCHAR (4000);
    SET @ErrorMessage = 'This migration "Migrations\0007_20180223-1305_Timothy-A.-Adekunle.sql" has left the transaction in an invalid or closed state (@@TRANCOUNT=' + CAST (@@TRANCOUNT AS NVARCHAR (10)) + '). Please ensure exactly 1 transaction is open by the end of the migration script.  Rolling-back any pending transactions.';
    RAISERROR (@ErrorMessage, 16, 127);
    RETURN;
  END

INSERT [$(DatabaseName)].[dbo].[__MigrationLog] ([migration_id], [script_checksum], [script_filename], [complete_dt], [applied_by], [deployed], [version], [package_version], [release_version])
VALUES                                         (CAST ('d501ecf2-7acf-4409-9034-96abe60aa20b' AS UNIQUEIDENTIFIER), 'DC03D1900EAD2EB8C6EE81727EB2DF2ED282308BEB41CAF85F1B4B4C6D008B9A', '0007_20180223-1305_Timothy-A.-Adekunle.sql', SYSDATETIME(), SYSTEM_USER, 1, NULL, '$(PackageVersion)', CASE '$(ReleaseVersion)' WHEN '' THEN NULL ELSE '$(ReleaseVersion)' END);

PRINT '***** FINISHED EXECUTING MIGRATION "Migrations\0007_20180223-1305_Timothy-A.-Adekunle.sql", ID: {d501ecf2-7acf-4409-9034-96abe60aa20b} *****
';

GO
PRINT '# Committing transaction';

COMMIT TRANSACTION;

GO
PRINT '4 migration(s) deployed successfully';

GO

GO







------------------------------------------------------------------------------------------------------------------------
------------------------------------------       POST-DEPLOYMENT SCRIPTS      ------------------------------------------
------------------------------------------------------------------------------------------------------------------------


SET IMPLICIT_TRANSACTIONS, NUMERIC_ROUNDABORT OFF;
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NOCOUNT, QUOTED_IDENTIFIER ON;

IF DB_NAME() != '$(DatabaseName)'
    USE [$(DatabaseName)];

PRINT '----- executing post-deployment script "Post-Deployment\01_Finalize_Deployment.sql" -----';

---------------------- BEGIN POST-DEPLOYMENT SCRIPT: "Post-Deployment\01_Finalize_Deployment.sql" ------------------------
GO
/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

GO
----------------------- END POST-DEPLOYMENT SCRIPT: "Post-Deployment\01_Finalize_Deployment.sql" -------------------------






SET NOEXEC OFF; -- Resume statement execution if an error occurred within the script pre-amble
