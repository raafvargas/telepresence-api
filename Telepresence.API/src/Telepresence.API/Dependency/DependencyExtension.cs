using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Telepresence.API.Dependency
{
    public static class DependencyExtension
    {
        public static void AddInternalDependencies<T>(this IServiceCollection service)
        {
            var interfaces = GetAssignable<T>().Where(t => t.IsInterface && t != typeof(T));

            foreach (var @interface in interfaces)
            {
                var implementation = GetAssignable(@interface).FirstOrDefault(t => !t.IsInterface);

                if (implementation != null)
                {
                    service.AddTransient(@interface, implementation);
                }
            }
        }

        private static ICollection<Type> GetAssignable<T>()
        {
            var type = typeof(T);
            return GetAssignable(type);
        }

        private static ICollection<Type> GetAssignable(Type type)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            return types.ToList();
        }
    }
}
