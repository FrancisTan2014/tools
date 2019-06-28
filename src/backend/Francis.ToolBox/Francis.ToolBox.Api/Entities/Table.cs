using System;

namespace Francis.ToolBox.Api.Entities
{
    public class Table
    {
        public string TableName { get; set; }
        public string Engine { get; set; }
        public long? AutoIncrement { get; set; }
        public DateTime? CreateTime { get; set; }
        public string TableComment { get; set; }
    }
}
