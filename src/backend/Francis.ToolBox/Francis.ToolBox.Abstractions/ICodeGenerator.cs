using System;
using System.Collections.Generic;
using System.Text;

namespace Francis.ToolBox.Abstractions
{
    public interface ICodeGenerator
    {
        string Execute(IEnumerable<IColumnMeta> columns);
    }
}
