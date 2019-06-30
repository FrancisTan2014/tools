using System;

namespace Francis.ToolBox.Abstractions
{
    public interface IPropertyInfo
    {
        string Name { get; set; }
        string TypeName { get; set; }
        Type Type { get; set; }
    }
}
