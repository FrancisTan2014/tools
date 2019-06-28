using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Francis.ToolBox.Api.Utils.Helpers
{
    public static class Enums
    {
        private static Dictionary<int, string> GetEnumDict<TEnum>(Func<Type, object, string> getTargetString) where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            var values = Enum.GetValues(enumType);
            var dict = new Dictionary<int, string>();
            foreach (var @enum in values)
            {
                var str = getTargetString(enumType, @enum);
                dict.Add((int)@enum, str);
            }
            return dict;
        }

        public static Dictionary<int, string> GetValueNameDict<TEnum>() where TEnum: Enum
        {
            return GetEnumDict<TEnum>(Enum.GetName);
        }

        public static Dictionary<int, string> GetValueDescriptionDict<TEnum>() where TEnum: Enum
        {
            return GetEnumDict<TEnum>((enumType, @enum) => Util.Helpers.Enum.GetDescription<TEnum>(@enum));
        }
    }
}
