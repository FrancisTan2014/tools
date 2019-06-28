using Francis.ToolBox.Abstractions;

namespace Francis.ToolBox.Entities
{
    public class Column : IColumnMeta
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDefault { get; set; }
        public string DataType { get; set; }
        public string ColumnType { get; set; }
        public string Comment { get; set; }
        public string IsNullabled { get; set; }
        public string CharacterMaximum { get; set; }
        public string ColumnKey { get; set; }
        public string ColumnComment { get; set; }
    }
}
