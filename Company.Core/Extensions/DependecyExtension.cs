using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            .Where(t => t is { IsClass: true, IsAbstract: false } &&
                        t.CustomAttributes.Any(p => p.AttributeType == typeof(ExposedServiceAttribute))).ToList();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="container"></param>
    /// <param name="assembly"></param>
    public static void RegisterAssmbly(this IContainerRegistry container, Assembly assembly)
    {
        var list = GetTypes(assembly);

        list.ForEach(item =>
        {
            RegisterAssmbly(container, item);
        });
    }

    private static IEnumerable<ExposedServiceAttribute> GetExposedServices(Type type)
    {
        var typeInfo = type.GetTypeInfo();
        return typeInfo.GetCustomAttributes<ExposedServiceAttribute>();
    }

    public static void RegisterAssmbly(this IContainerRegistry container, Type type)
    {
        var list = GetExposedServices(type).ToList();

        list.ForEach(item =>
        {
            switch (item.LifeCycle)
            {
                case LifeCycle.Singleton:
                    container.RegisterSingleton(type);
                    break;
                case LifeCycle.Transient:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }

            foreach (var interfaceType in item.Types)
            {
                _ = item.LifeCycle switch
                {
                    LifeCycle.Singleton => container.RegisterSingleton(interfaceType, type),
                    LifeCycle.Transient => container.Register(interfaceType, type),
                    _ => throw new NotImplementedException(),
                };
            }
        });
    }

    public static void InitializeAssembly(this IContainerProvider container, Assembly assembly)
    {
        var list = GetTypes(assembly);

        list.ForEach(item =>
        {
            InitializeAssembly(container, item);
        });
    }

    private static void InitializeAssembly(IContainerProvider container, Type type)
    {
        var list = GetExposedServices(type);

        foreach (var item in list)
        {
            if (item is { LifeCycle: LifeCycle.Singleton, AutoInitialize: true }) container.Resolve(type);
        }

    }
}