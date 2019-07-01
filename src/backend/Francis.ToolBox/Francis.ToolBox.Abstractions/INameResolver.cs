using System;
using System.Collections.Generic;
using System.Text;

namespace Francis.ToolBox.Abstractions
{
    /// <summary>
    /// 定义将给定名称映射为目标名称的操作接口
    /// </summary>
    public interface INameResolver
    {
        string Resolve(string name);
    }
}
