namespace Snowsharp.Client.Models.Describables;

public interface ISnowflakeDescribable
{
    public string GetDescribeStatement();

    public bool IsProcedure();
}
