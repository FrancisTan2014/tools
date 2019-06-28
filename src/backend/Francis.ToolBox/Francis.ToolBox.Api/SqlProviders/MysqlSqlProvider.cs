namespace Francis.ToolBox.Api.SqlProviders
{
    public class MysqlSqlProvider : ISqlProvider
    {
        public string GetListColumnsSql(string tableName)
        {
            return $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
        }

        public string GetListDatabasesSql()
        {
            return "SELECT DISTINCT TABLE_SCHEMA FROM INFORMATION_SCHEMA.`TABLES`;";
        }

        public string GetListTablesSql(string dbName)
        {
            return $"SELECT `TABLE_NAME` AS `TableName`, `Engine`, `AUTO_INCREMENT` AS `AutoIncrement`, `CREATE_TIME` AS `CreateTime`, `TABLE_COMMENT` AS `TableComment`  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{dbName}'";
        }
    }
}
