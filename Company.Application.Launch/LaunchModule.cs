using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application.Launch.Views;
using Company.Application.Share.Prism;
using Prism.Ioc;
using Prism.Modularity;

namespace Company.Application.Launch;

[Module(ModuleName = ModuleNames.LaunchModuleName, OnDemand = true)]
public class LaunchModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<LaunchView>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        
    }
}