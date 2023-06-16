using System.Data;
using Snowsharp.Client.Models.Enums;

namespace Snowsharp.Client.Models.Assets;

public class RoleInheritance : ISnowflakeAsset
{
    public RoleInheritance(ISnowflakePrincipal childRole, ISnowflakePrincipal parentPrincipal)
    {
        ChildRole = childRole;
        ParentPrincipal = parentPrincipal;
    }

    public ISnowflakePrincipal ChildRole { get; init; }
    public ISnowflakePrincipal ParentPrincipal { get; init; }
    public string GetCreateStatement()
    {
        SnowflakePrincipal childRoleType;
        SnowflakePrincipal parentPrincipalType;
        var grantStatement = "GRANT";
        switch (ChildRole)
        {
            case Role principal:
                childRoleType = SnowflakePrincipal.Role;
                grantStatement += $" ROLE {principal.GetIdentifier()} TO";
                break;
            case DatabaseRole principal:
                childRoleType = SnowflakePrincipal.DatabaseRole;
                grantStatement += $" DATABASE ROLE {principal.GetIdentifier()} TO";
                break;
            default:
                throw new NotImplementedException("GetIdentifier is not implemented for this interface type");
        }
        switch (ParentPrincipal)
        {
            case Role principal:
                parentPrincipalType = SnowflakePrincipal.Role;
                grantStatement += $" ROLE {principal.GetIdentifier()};";
                break;
            case DatabaseRole principal:
                parentPrincipalType = SnowflakePrincipal.DatabaseRole;
                grantStatement += $" DATABASE ROLE {principal.GetIdentifier()};";
                break;
            default:
                throw new NotImplementedException("GetIdentifier is not implemented for this interface type");
        }
        return parentPrincipalType switch
        {
            SnowflakePrincipal.DatabaseRole when childRoleType == SnowflakePrincipal.Role => throw new ConstraintException("Account roles cannot be granted to database roles"),
            SnowflakePrincipal.DatabaseRole when childRoleType == SnowflakePrincipal.DatabaseRole && ((DatabaseRole)ChildRole).DatabaseName != ((DatabaseRole)ParentPrincipal).DatabaseName => throw new ConstraintException("Can only grant database roles to other database roles in the same database"),
            _ => grantStatement,
        };
    }

    public string GetDeleteStatement()
    {
        var revokeStatement = "REVOKE";
        revokeStatement += ChildRole switch
        {
            Role principal => $" ROLE {principal.GetIdentifier()} FROM",
            DatabaseRole principal => $" DATABASE ROLE {principal.GetIdentifier()} FROM",
            _ => throw new NotImplementedException("GetIdentifier is not implemented for this interface type"),
        };
        revokeStatement += ParentPrincipal switch
        {
            Role principal => $" ROLE {principal.GetIdentifier()};",
            DatabaseRole principal => $" DATABASE ROLE {principal.GetIdentifier()};",
            _ => throw new NotImplementedException("GetIdentifier is not implemented for this interface type"),
        };
        return revokeStatement;
    }
}