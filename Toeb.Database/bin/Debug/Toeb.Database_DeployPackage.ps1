# Variable validation
function Get-SqlScalarValue($variableName, $ConnectionString, $scalarQuery)  {    Try    {      $SqlConnection = New-Object System.Data.SqlClient.SqlConnection;      $SqlConnection.ConnectionString = $ConnectionString;      $SqlConnection.Open();        $SqlCmd = New-Object System.Data.SqlClient.SqlCommand;      $SqlCmd.CommandText = $scalarQuery;      $SqlCmd.Connection = $sqlConnection;         $scalarValue = [string]$SqlCmd.ExecuteScalar();       if ($scalarValue -eq '') { Write-Warning "Could not determine a value for $variableName variable. An empty string will be supplied to the deployment."; };              $SqlConnection.Close();            return $scalarValue;    }    Catch    {      Write-Warning "Could not retrieve a value for $variableName : $_ " ;      return "";    }  }
function Get-ScriptDirectory {$Invocation = (Get-Variable MyInvocation -Scope 1).Value; Split-Path $Invocation.MyCommand.Path }
Try {
if ($ReleaseVersion -eq $null) { $ReleaseVersion = ''; if ($OctopusEnvironmentName -eq $null) { $Host.UI.WriteWarningLine("As the ReleaseVersion variable is not set, the [__MigrationLog].[release_version] column will be set to NULL for any pending migrations.") } }
if ($OctopusReleaseNumber -ne $null) { $ReleaseVersion = $OctopusReleaseNumber }
if ($DeployPath -eq $null) { $DeployPath = (Get-ScriptDirectory).TrimEnd('\') + '\' }
if ($SkipOctopusVariableValidation -ne $null) { $SkipVariableValidation = $SkipOctopusVariableValidation }
if ($UseSqlCmdVariableDefaults -eq $null) { $UseSqlCmdVariableDefaults = "true" }
if ($UseSqlCmdVariableDefaults -eq "true")
{
Write-Output 'If you require that all SqlCmd variable values be passed in explicitly, specify UseSqlCmdVariableDefaults=False.'
if ($DatabaseName -eq $null) { Write-Output 'Using default value for DatabaseName variable: Alabagbe'; $DatabaseName='Alabagbe' }
if ($ForceDeployWithoutBaseline -eq $null) { Write-Output 'Using default value for ForceDeployWithoutBaseline variable: False'; $ForceDeployWithoutBaseline = 'False' }
}
if ($DatabaseServer -eq $null) { Throw 'DatabaseServer variable was not provided.' }
if ($DatabaseName -eq $null) { Throw 'DatabaseName variable was not provided.' }
if ($ForceDeployWithoutBaseline -eq $null) { Throw 'ForceDeployWithoutBaseline variable was not provided.' }
if ($UseWindowsAuth -eq $null) { $UseWindowsAuth = $true }
if ($UseWindowsAuth -eq $true) { 'Using Windows Authentication'; $SqlCmdAuth = '-E'; $ConnectionString = 'Data Source=' + $DatabaseServer + ';Integrated Security=SSPI'; } else { if ($DatabaseUserName -eq $null) { Throw 'As SQL Server Authentication is to be used, please specify values for the DatabaseUserName and DatabasePassword variables. Alternately, specify UseWindowsAuth=True to use Windows Authentication instead.' }; if ($DatabasePassword -eq $null) { Throw 'If a DatabaseUserName is specified, the DatabasePassword variable must also be provided.' }; 'Using SQL Server Authentication'; $SqlCmdAuth = '-U "' + $DatabaseUserName.Replace('"', '""') + '" '; $env:SQLCMDPASSWORD=$DatabasePassword; $ConnectionString = 'Data Source=' + $DatabaseServer + ';User Id=' + $DatabaseUserName + ';Password=' + $DatabasePassword;};
if ($DefaultFilePrefix -eq $null) { Write-Output 'Using default value for DefaultFilePrefix variable: Alabagbe'; $DefaultFilePrefix='Alabagbe' }
if ($DefaultDataPath -eq $null) { $DefaultDataPath = Get-SqlScalarValue "DefaultDataPath" $ConnectionString "declare @DefaultPath nvarchar(512);  exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultData', @DefaultPath output;    if (@DefaultPath is null)  begin    set @DefaultPath = (select F.physical_name from sys.master_files F where F.database_id=db_id('master') and F.type = 0);    select @DefaultPath=substring(@DefaultPath, 1, len(@DefaultPath) - charindex('\', reverse(@DefaultPath)));  end    select isnull(@DefaultPath + '\', '') DefaultData"; Write-Output 'Using default value for DefaultDataPath variable:' $DefaultDataPath; }
if ($DefaultLogPath -eq $null) { $DefaultLogPath = Get-SqlScalarValue "DefaultLogPath" $ConnectionString "declare @DefaultPath nvarchar(512);  exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultLog', @DefaultPath output;    if (@DefaultPath is null)  begin    set @DefaultPath = (select F.physical_name from sys.master_files F where F.database_id=db_id('master') and F.type = 1);    select @DefaultPath=substring(@DefaultPath, 1, len(@DefaultPath) - charindex('\', reverse(@DefaultPath)));  end    select isnull(@DefaultPath + '\', '') DefaultData"; Write-Output 'Using default value for DefaultLogPath variable:' $DefaultLogPath; }
if ($DefaultBackupPath -eq $null) { $DefaultBackupPath = Get-SqlScalarValue "DefaultBackupPath" $ConnectionString "declare @DefaultBackup nvarchar(512);  exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'BackupDirectory', @DefaultBackup output;  select isnull(@DefaultBackup + '\', '') DefaultBackup;"; Write-Output 'Using default value for DefaultBackupPath variable:' $DefaultBackupPath; }
Write-Output "Starting '$DatabaseName' Database Deployment to '$DatabaseServer'"
$SqlCmdVarArguments = 'DatabaseName="' + $DatabaseName.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' ReleaseVersion="' + $ReleaseVersion.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' DeployPath="' + $DeployPath.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' ForceDeployWithoutBaseline="' + $ForceDeployWithoutBaseline.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' DefaultFilePrefix="' + $DefaultFilePrefix.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' DefaultDataPath="' + $DefaultDataPath.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' DefaultLogPath="' + $DefaultLogPath.Replace('"', '""') + '"'
$SqlCmdVarArguments += ' DefaultBackupPath="' + $DefaultBackupPath.Replace('"', '""') + '"'
$SqlCmdBase = 'sqlcmd.exe -b -S "' + $DatabaseServer + '" -v ' + $SqlCmdVarArguments
$SqlCmd = $SqlCmdBase
$SqlCmd = $SqlCmd + ' -i "' + (Get-ScriptDirectory) + '\Toeb.Database_Package.sql"'
$SqlCmdWithAuth = $SqlCmd + ' ' + $SqlCmdAuth
Write-Output $SqlCmdWithAuth
} Catch {
$Host.UI.WriteErrorLine("A validation error occurred: $_ ");
$Host.UI.WriteErrorLine("To bypass variable validation, pass this property value to MSBuild: SkipVariableValidation=True");
if ($OctopusEnvironmentName -ne $null) { [Environment]::Exit(1) };
Throw;
}
# SQLCMD package deployment
Try
{
cmd /Q /C $SqlCmdWithAuth;
if ($lastexitcode) { Throw 'sqlcmd.exe exited with a non-zero exit code.' }
}
Catch
{
$Host.UI.WriteErrorLine("A deployment error occurred: $_ ");
if ($OctopusEnvironmentName -ne $null) 	{ [Environment]::Exit(1); };
Throw;
}
