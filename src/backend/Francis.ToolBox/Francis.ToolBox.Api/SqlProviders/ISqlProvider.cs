namespace Francis.ToolBox.Api.SqlProviders
{
    public interface ISqlProvider
    {
        string GetListDatabasesSql();
        string GetListTablesSql(string dbName);
        string GetListColumnsSql(string tableName);
    }
}
