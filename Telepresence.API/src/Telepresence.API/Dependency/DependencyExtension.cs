using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Telepresence.API.Dependency
{
    /// <summary>
    /// Custom dependency resolver
    /// </summary>
    public static class DependencyExtension
    {
        /// <summary>
        /// Register all internal dependencies
        /// </summary>
        /// <typeparam name="T">Dependency type</typeparam>
        /// <param name="service">Service container</param>
        public static void AddInternalDependencies<T>(this IServiceCollection service)
        {
            var interfaces = GetAssignable<T>().Where(t => t.IsInterface && t != typeof(T));

            foreach (var @interface in interfaces)
            {
                var implementation = GetAssignable(@interface).FirstOrDefault(t => !t.IsInterface);

                if (implementation != null)
                {
                    service.AddSingleton(@interface, implementation);
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
