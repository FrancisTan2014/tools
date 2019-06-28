using Francis.ToolBox.Api.Entities;
using Francis.ToolBox.Api.Exceptions;

namespace Francis.ToolBox.Api.SqlProviders
{
    public class SqlProviderFactory : ISqlProviderFactory
    {
        public ISqlProvider Create(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.Mysql:
                    return new MysqlSqlProvider();
                case DatabaseType.Sqlserver:
                case DatabaseType.Oracle:
                default:
                    throw new UnsupportedDbTypeException();
            }
        }
    }
}
