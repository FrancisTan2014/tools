using System;
using System.Collections.Generic;
using System.Text;

namespace Francis.ToolBox.Abstractions
{
    public abstract class ColumnMapper : IColumnMapper
    {
        public abstract IDictionary<string, string> TypeNameMap { get; }

        public INameResolver NameResolver { get; set; } = new DefaultNameResolver();

        private string ResolveType(IDictionary<string, string> customTypeNameMap, string columnType)
        {
            if (customTypeNameMap?.ContainsKey(columnType) == true)
            {
                return customTypeNameMap[columnType];
            }
            return TypeNameMap[columnType];
        }

        private PropertyInfo ResolveProperty(IColumnMeta column, IDictionary<string, string> customTypeNameMap)
        {
            var result = new PropertyInfo
            {
                Name = NameResolver.Resolve(column.ColumnName),
                TypeName = ResolveType(customTypeNameMap, column.DataType),
                Comment = column.Comment
            };
            return result;
        }

        public virtual List<PropertyInfo> Map(IEnumerable<IColumnMeta> columns, IDictionary<string, string> customTypeNameMap)
        {
            var result = new List<PropertyInfo>();
            foreach (var col in columns)
            {
                var prop = ResolveProperty(col, customTypeNameMap);
                result.Add(prop);
            }
            return result;
        }
    }

    public sealed class DefaultNameResolver : INameResolver
    {
        public string Resolve(string name)
        {
            return name;
        }
    }
}
