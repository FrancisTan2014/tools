using Francis.ToolBox.Api.Entities;
using Francis.ToolBox.Api.Exceptions;
using Francis.ToolBox.Api.Factories;
using Francis.ToolBox.Api.SqlProviders;
using SmartSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Francis.ToolBox.Api.Services
{
    public class DatabaseService
    {
        private readonly SmartSqlBuilder _sqlBuilder;
        private readonly Connection _connection;
        private readonly ISqlProvider _sqlProvider;

        private DatabaseService(SmartSqlBuilder builder, Connection connection, ISqlProvider sqlProvider)
        {
            _sqlBuilder = builder;
            _connection = connection;
            _sqlProvider = sqlProvider;
        }

        private List<T> Query<T>(string sql)
        {
            using (var dbSession = _sqlBuilder.DbSessionFactory.Open())
            {
                return dbSession.Query<T>(new RequestContext
                {
                    RealSql = sql

                }).ToList();
            }
        }

        public static DatabaseService Create(SmartSqlBuilderFactory builderFactory, ISqlProviderFactory sqlProviderFactory, Connection connection)
        {
            var builder = builderFactory.Create(connection);
            var provider = sqlProviderFactory.Create(connection.DbType);
            return new DatabaseService(builder, connection, provider);
        }

        public List<string> ListDatabases()
        {
            var sql = _sqlProvider.GetListDatabasesSql();
            return Query<string>(sql);
        }

        public List<Table> ListTables(string dbName)
        {
            var sql = _sqlProvider.GetListTablesSql(dbName);
            return Query<Table>(sql);
        }

        internal List<Column> ListColumns(string tableName)
        {
            var sql = _sqlProvider.GetListColumnsSql(tableName);
            return Query<Column>(sql);
        }
    }
}
