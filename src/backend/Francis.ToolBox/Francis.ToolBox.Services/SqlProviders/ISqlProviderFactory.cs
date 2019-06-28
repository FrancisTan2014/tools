using Francis.ToolBox.Entities;

namespace Francis.ToolBox.SqlProviders
{
    public interface ISqlProviderFactory
    {
        ISqlProvider Create(DatabaseType dbType);
    }
}
