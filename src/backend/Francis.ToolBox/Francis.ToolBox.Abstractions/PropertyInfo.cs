using System;

namespace Francis.ToolBox.Abstractions
{
    /// <summary>
    /// 表示一个 C# 实体类属性的模型
    /// </summary>
    public class PropertyInfo
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public Type Type { get; set; }
        public string Comment { get; set; }
    }
}
