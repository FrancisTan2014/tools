using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Francis.ToolBox.Services.Extenssions
{
    public static class ServiceDIExtenssion
    {
        /// <summary>
        /// 注入 Service
        /// </summary>
        /// <param name="serviceAssemblyName"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services, string serviceAssemblyName, Func<Type, bool> filters)
        {
            var assembly = Assembly.Load(serviceAssemblyName);
            var types = assembly.GetTypes().Where(filters);
            foreach (var type in types)
            {
                services.AddSingleton(type);
            }
            return services;
        }
    }
}
