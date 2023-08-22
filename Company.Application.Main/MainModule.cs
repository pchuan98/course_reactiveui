using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application.Main.Views;
using Company.Application.Share.Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Company.Application.Main;

[Module(ModuleName = ModuleNames.MainModuleName, OnDemand = true)]
[ModuleDependency(ModuleNames.MenuModuleName)]
public class MainModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainView>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        containerProvider.Resolve<IRegionManager>().RegisterViewWithRegion<MainView>(RegionNames.Main);
    }
}