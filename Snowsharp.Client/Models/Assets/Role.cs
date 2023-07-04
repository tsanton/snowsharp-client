using System.Text;
using Snowsharp.Client.Models.Enums;

namespace Snowsharp.Client.Models.Assets;

public class Role : ISnowflakeAsset, ISnowflakePrincipal
{
    public Role(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public string Comment { get; init; } = "{\"COMMENT\": \"SNOWSHARP TEST ROLE\"}";
    public ISnowflakePrincipal? Owner { get; init; }
    public List<ClassificationTag> Tags { get; init; } = new();
    public string GetCreateStatement()
    {
        var ownerType = Owner switch
        {
            Role => SnowflakePrincipal.Role,
            _ => throw new NotImplementedException("Ownership is not implementer for this interface type"),
        };
        var sb = new StringBuilder();
        sb.Append($"CREATE OR REPLACE ROLE {GetIdentifier()}");
        sb.Append(' ').Append("COMMENT = ").Append($"'{Comment}'").AppendLine(";");
        sb.Append($"GRANT OWNERSHIP ON ROLE {GetIdentifier()} TO {ownerType.GetSnowflakeType()} {Owner.GetIdentifier()}");
        foreach (var tag in Tags)
        {
            var val = tag.TagValue ?? "";
            sb.AppendLine($"ALTER ROLE {GetIdentifier()} SET TAG {tag.GetIdentifier()} = '{val}';");
        }
        return sb.ToString();
    }

    public string GetDeleteStatement()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format("DROP ROLE IF EXISTS {0};", GetIdentifier());
    }

    public string GetIdentifier()
    {
        return Name;
    }
}