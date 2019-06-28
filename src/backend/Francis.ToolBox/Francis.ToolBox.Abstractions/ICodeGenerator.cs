using System;
using System.Collections.Generic;
using System.Text;

namespace Francis.ToolBox.Abstractions
{
    public interface ICodeGenerator
    {
        void Execute(IList<IColumnMeta> columns, IList<IStringWriter> writers);
    }
}
