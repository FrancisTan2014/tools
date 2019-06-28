using Francis.ToolBox.Common.Exceptions;
using Francis.ToolBox.Entities;
using Francis.ToolBox.Services.Extenssions;
using SmartSql;
using SmartSql.DataSource;

namespace Francis.ToolBox.Factories
{
    public class SmartSqlBuilderFactory
    {
        private string GetDbProviderName(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.Mysql: return DbProvider.MYSQL;
                case DatabaseType.Sqlserver: return DbProvider.SQLSERVER;
                case DatabaseType.Oracle: return DbProvider.ORACLE;
                default: throw new UnknownDbTypeException();
            }
        }

        public SmartSqlBuilder Create(Connection connection)
        {
            var alias = connection.Name;
            var builder = SmartSqlContainer.Instance.GetSmartSql(alias);
            if (builder != null)
            {
                return builder;
            }
            var providerName = GetDbProviderName(connection.DbType);
            var connectionString = connection.BuildConnectionString();
            return new SmartSqlBuilder()
                .UseDataSource(providerName, connectionString)
                .UseAlias(alias)
                .Build();
        }
    }
}
