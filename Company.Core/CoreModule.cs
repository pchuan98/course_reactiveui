using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Extensions;
using Prism.Ioc;
using Prism.Modularity;

namespace Company.Core;

public class CoreModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterAssmbly(Assembly.GetExecutingAssembly());
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        containerProvider.InitializeAssembly(Assembly.GetExecutingAssembly());
    }
} 