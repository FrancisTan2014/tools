namespace Francis.ToolBox.SqlProviders
{
    public interface ISqlProvider
    {
        string GetListDatabasesSql();
        string GetListTablesSql(string dbName);
        string GetListColumnsSql(string tableName);
    }
}
