using Company.Application.Share.Prism;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.Aplication.Menu.Views;
using Company.Core.Extensions;
using Company.Core.Ioc;
using Prism.Ioc;
using Prism.Regions;

namespace Company.Aplication.Menu;

[Module(ModuleName = ModuleNames.MenuModuleName, OnDemand = true)]
public class MenuModule:IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        PrismProvider.RegionManager.RegisterViewWithRegion<MenuView>(RegionNames.Menu);
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
       
    }
}