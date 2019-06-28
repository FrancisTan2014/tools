using Francis.ToolBox.Entities;
using Francis.ToolBox.Common.Exceptions;

namespace Francis.ToolBox.SqlProviders
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
