namespace Francis.ToolBox.Abstractions.Database
{
    /// <summary>
    /// 表示数据库列属性的接口
    /// </summary>
    public interface IColumn
    {
        string TableName { get; set; }
        string Name { get; set; }
        string DataType { get; set; }
        string Comment { get; set; }
        bool IsNullabled { get; set; }
    }
}
