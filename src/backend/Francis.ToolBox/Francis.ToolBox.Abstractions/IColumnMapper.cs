using System;
using System.Collections.Generic;
using System.Text;

namespace Francis.ToolBox.Abstractions
{
    /// <summary>
    /// 定义将数据库列映射到 c# 实体属性的操作接口
    /// </summary>
    public interface IColumnMapper
    {
        /// <summary>
        /// 数据库类型与 c# 类型的映射。其中， key 为数据库类型名称，value 为 c# 类型名称。
        /// </summary>
        IDictionary<string, string> TypeNameMap { get; }
        /// <summary>
        /// 将数据库列名称映射到 C# 属性名称的解析工具。
        /// </summary>
        INameResolver NameResolver { get; set; }
        /// <summary>
        /// 通过一组数据列元数据集合，映射出一组 c# 属性集合
        /// </summary>
        /// <param name="columns">数据库列元数据集</param>
        /// <param name="customTypeNameMap">自定义数据库类型到 C# 类型的映射，当与默认映射重合时，将覆盖默认值</param>
        /// <returns></returns>
        List<PropertyInfo> Map(IEnumerable<IColumnMeta> columns, IDictionary<string, string> customTypeNameMap);
    }
}
