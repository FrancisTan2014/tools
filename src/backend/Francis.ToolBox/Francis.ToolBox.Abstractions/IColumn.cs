namespace Francis.ToolBox.Abstractions
{
    /// <summary>
    /// 表示数据库列元数据的接口
    /// </summary>
    public interface IColumnMeta
    {
        string TableName { get; set; }
        string ColumnName { get; set; }
        string ColumnDefault { get; set; }
        string DataType { get; set; }
        string ColumnType { get; set; }
        string Comment { get; set; }
        string IsNullabled { get; set; }
        string CharacterMaximum { get; set; }
        string ColumnKey { get; set; }
        string ColumnComment { get; set; }
    }
}
