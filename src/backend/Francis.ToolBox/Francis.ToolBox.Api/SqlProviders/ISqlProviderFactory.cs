using Francis.ToolBox.Api.Entities;

namespace Francis.ToolBox.Api.SqlProviders
{
    public interface ISqlProviderFactory
    {
        ISqlProvider Create(DatabaseType dbType);
    }
}
