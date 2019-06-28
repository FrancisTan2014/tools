using System;
using System.Collections.Generic;
using System.Text;

namespace Francis.ToolBox.Abstractions
{
    public interface IColumnHandler
    {
        IList<IPropertyInfo> ResolveProperties(IList<IColumnMeta> columns);
    }
}
