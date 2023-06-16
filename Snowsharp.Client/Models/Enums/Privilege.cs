using System.Text.Json.Serialization;
using Snowsharp.Client.Converters;

namespace Snowsharp.Client.Models.Enums;


// https://github.com/Snowflake-Labs/terraform-provider-snowflake/blob/e1227159be50bf26841acead8730dad516a96ebc/pkg/resources/privileges.go#L73
[JsonConverter(typeof(JsonStringEnumConverter<Privilege>))]
public enum Privilege
{
    [JsonPropertyName("SELECT")] Select,
    [JsonPropertyName("INSERT")] Insert,
    [JsonPropertyName("UPDATE")] Update,
    [JsonPropertyName("DELETE")] Delete,
    [JsonPropertyName("TRUNCATE")] Truncate,
    [JsonPropertyName("REFERENCES")] References,
    [JsonPropertyName("REBUILD")] Rebuild,
    [JsonPropertyName("CREATE SCHEMA")] CreateSchema,
    [JsonPropertyName("IMPORTED PRIVILEGES")] ImportedPrivileges,
    [JsonPropertyName("MODIFY")] Modify,
    [JsonPropertyName("OPERATE")] Operate,
    [JsonPropertyName("MONITOR")] Monitor,
    [JsonPropertyName("OWNERSHIP")] Ownership,
    [JsonPropertyName("READ")] Read,
    [JsonPropertyName("REFERENCE_USAGE")] ReferenceUsage,
    [JsonPropertyName("USAGE")] Usage,
    [JsonPropertyName("WRITE")] Write,
    [JsonPropertyName("CREATE TABLE")] CreateTable,
    [JsonPropertyName("CREATE TAG")] CreateTag,
    [JsonPropertyName("CREATE VIEW")] CreateView,
    [JsonPropertyName("CREATE FILE FORMAT")] CreateFileFormat,
    [JsonPropertyName("CREATE STAGE")] CreateStage,
    [JsonPropertyName("CREATE PIPE")] CreatePipe,
    [JsonPropertyName("CREATE STREAM")] CreateStream,
    [JsonPropertyName("CREATE TASK")] CreateTask,
    [JsonPropertyName("CREATE SEQUENCE")] CreateSequence,
    [JsonPropertyName("CREATE FUNCTION")] CreateFunction,
    [JsonPropertyName("CREATE PROCEDURE")] CreateProcedure,
    [JsonPropertyName("CREATE EXTERNAL TABLE")] CreateExternalTable,
    [JsonPropertyName("CREATE MATERIALIZED VIEW")] CreateMaterializedView,
    [JsonPropertyName("CREATE ROW ACCESS POLICY")] CreateRowAccessPolicy,
    [JsonPropertyName("CREATE TEMPORARY TABLE")] CreateTemporaryTable,
    [JsonPropertyName("CREATE MASKING POLICY")] CreateMaskingPolicy,
    [JsonPropertyName("CREATE NETWORK POLICY")] CreateNetworkPolicy,
    [JsonPropertyName("CREATE DATA EXCHANGE LISTING")] CreateDataExchangeListing,
    [JsonPropertyName("CREATE ACCOUNT")] CreateAccount,
    [JsonPropertyName("CREATE SHARE")] CreateShare,
    [JsonPropertyName("IMPORT SHARE")] ImportShare,
    [JsonPropertyName("OVERRIDE SHARE RESTRICTIONS")] OverrideShareRestrictions,
    [JsonPropertyName("ADD SEARCH OPTIMIZATION")] AddSearchOptimization,
    [JsonPropertyName("APPLY MASKING POLICY")] ApplyMaskingPolicy,
    [JsonPropertyName("APPLY ROW ACCESS POLICY")] ApplyRowAccessPolicy,
    [JsonPropertyName("APPLY TAG")] ApplyTag,
    [JsonPropertyName("APPLY")] Apply,
    [JsonPropertyName("ATTACH POLICY")] AttachPolicy,
    [JsonPropertyName("CREATE ROLE")] CreateRole,
    [JsonPropertyName("CREATE USER")] CreateUser,
    [JsonPropertyName("CREATE WAREHOUSE")] CreateWarehouse,
    [JsonPropertyName("CREATE DATABASE")] CreateDatabase,
    [JsonPropertyName("CREATE DATABASE ROLE")] CreateDatabaseRole,
    [JsonPropertyName("CREATE INTEGRATION")] CreateIntegration,
    [JsonPropertyName("MANAGE GRANTS")] ManageGrants,
    [JsonPropertyName("MONITOR USAGE")] MonitorUsage,
    [JsonPropertyName("MONITOR EXECUTION")] MonitorExecution,
    [JsonPropertyName("EXECUTE TASK")] ExecuteTask,
    [JsonPropertyName("EXECUTE MANAGED TASK")] ExecuteManagedTask,
    [JsonPropertyName("MANAGE ORGANIZATION SUPPORT CASES")] OrganizationSupportCases,
    [JsonPropertyName("MANAGE ACCOUNT SUPPORT CASES")] AccountSupportCases,
    [JsonPropertyName("MANAGE USER SUPPORT CASES")] UserSupportCases,
}
