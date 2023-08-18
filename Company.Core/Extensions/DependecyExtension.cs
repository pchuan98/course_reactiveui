using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Ioc;

namespace Company.Core.Extensions;

/// <summary>
/// Dependency extension class.
/// 
/// Automatically Load Attribute Data When Modules Can Be Loaded
/// </summary>
public static class DependecyExtension
{

    private static List<Type> GetTypes(Assembly assembly)
        => assembly.GetTypes()
            .Where(t => t != null && t.IsClass && !t.IsAbstract &&
                        t.CustomAttributes.Any(p => p.AttributeType == typeof(ExposedServiceAttribute))).ToList();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="container"></param>
    /// <param name="assembly"></param>
    public static void RegisterAssmbly(this IContainerRegistry container, Assembly assembly)
    {

    }
}