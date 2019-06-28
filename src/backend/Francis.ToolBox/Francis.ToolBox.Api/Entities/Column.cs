using Francis.ToolBox.Abstractions.Database;

namespace Francis.ToolBox.Api.Entities
{
    public class Column : IColumn
    {
        public string TableName { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Comment { get; set; }
        public bool IsNullabled { get; set; }
    }
}
