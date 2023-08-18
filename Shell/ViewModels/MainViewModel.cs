using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Company.Application.Share.Events;
using Company.Application.Share.Models;
using Company.Application.Share.Prism;
using Company.Core.Ioc;
using Prism.Events;

namespace Shell.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    void Loaded()
    {
        PrismProvider.ModuleManager!.LoadModule(ModuleNames.LaunchModuleName);
        PrismProvider.RegionManager!.RequestNavigate(RegionNames.Main, ViewNames.LaunchView);

        // subscribe
        PrismProvider.Aggregator!.GetEvent<LaunchSuccessEvent>().Subscribe(OnLaunch, ThreadOption.UIThread);
    }

    private void OnLaunch(LaunchModel obj)
    {
        PrismProvider.ModuleManager!.LoadModule(ModuleNames.MainModuleName);

        PrismProvider.RegionManager!.RequestNavigate(RegionNames.Main, ViewNames.MainView);
    }
}