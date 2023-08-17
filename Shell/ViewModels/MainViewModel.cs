using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Modularity;
using Prism.Regions;

namespace Shell.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public IModuleManager ModuleManager { get; }

    public IRegionManager RegionManager { get; }

    [ObservableProperty]
    private string _title = "Hello World!";

    public MainViewModel(IModuleManager module, IRegionManager region)
    {
        ModuleManager = module;
        RegionManager = region;
    }
}