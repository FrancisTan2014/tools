using Francis.ToolBox.Entities;
using Francis.ToolBox.Common.Exceptions;
using System.Text;

namespace Francis.ToolBox.Services.Extenssions
{
    public static class ConnectionExtenssions
    {
        private static string BuildMysqlConnectionString(Connection connection)
        {
            return $"server={connection.Host};port={connection.Port};uid={connection.Username};pwd={connection.Password};Allow User Variables=true;";
        }

        public static string BuildConnectionString(this Connection connection)
        {
            switch (connection.DbType)
            {
                case DatabaseType.Mysql: return BuildMysqlConnectionString(connection);
                case DatabaseType.Sqlserver:
                case DatabaseType.Oracle:
                default:
                    throw new UnknownDbTypeException();
            }
        }
    }
}
