using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Company.Core.Ioc;

[ExposedService(LifeCycle.Singleton, AutoInitialize = true)]
public sealed class PrismProvider
{
    public PrismProvider(
        IContainerExtension container,
        IRegionManager regionManager,
        IDialogService dialogService,
        IEventAggregator aggregator,
        IModuleManager moduleManager)
    {
        Container = container;
        RegionManager = regionManager;
        DialogService = dialogService;
        Aggregator = aggregator;
        ModuleManager = moduleManager;
    }

    /// <summary>
    ///  IContainerProvider and IContainerRegistry
    /// </summary>
    public static IContainerExtension? Container { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public static IRegionManager? RegionManager { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public static IDialogService? DialogService { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public static IEventAggregator? Aggregator { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public static IModuleManager? ModuleManager { get; private set; }

}