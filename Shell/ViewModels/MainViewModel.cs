using System;
using System.Windows;
using System.Windows.Media.Media3D;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Company.Application.Share.Events;
using Company.Application.Share.Models;
using Company.Application.Share.Prism;
using Company.Core.Ioc;
using HandyControl.Tools.Extension;
using Prism.Events;
using Prism.Regions;
using static HandyControl.Tools.Interop.InteropValues;

namespace Shell.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "From MainViewModel";

    [RelayCommand]
    void Loaded()
    {
        var mainRegion = PrismProvider.RegionManager!.Regions[RegionNames.Main];
        mainRegion!.NavigationService.Navigated += NavigationService_Navigated;

        PrismProvider.ModuleManager!.LoadModule(ModuleNames.LaunchModuleName);
        PrismProvider.RegionManager!.RequestNavigate(RegionNames.Main, ViewNames.LaunchView);

        // subscribe
        PrismProvider.Aggregator!.GetEvent<LaunchSuccessEvent>().Subscribe(OnLaunch, ThreadOption.UIThread);
    }

    private void OnLaunch(LaunchModel obj)
    {
        PrismProvider.ModuleManager!.LoadModule(ModuleNames.MainModuleName);
        PrismProvider.RegionManager!.RequestNavigate(RegionNames.Main, ViewNames.MainView);

        LoadOthers();
    }

    private void LoadOthers()
    {
        // menu load
        //PrismProvider.ModuleManager!.LoadModule(ModuleNames.MenuModuleName);
    }

    private void NavigationService_Navigated(object? sender, RegionNavigationEventArgs e)
        => _ = e.Uri.OriginalString switch
        {
            ViewNames.MainView => SetMainWindow(),
            ViewNames.LaunchView => SetLaunchWindow(),
            _ => throw new NotSupportedException(),
        };

    public bool SetLaunchWindow()
    {
        var window = Application.Current.MainWindow;
        if (window == null) return false;

        window.Height = 350;
        window.Width = 250;

        CenterWindowOnScreen(window);
        return true;
    }

    public bool SetMainWindow()
    {
        var window = Application.Current.MainWindow;
        if (window == null) return false;

        window.Height = 800;
        window.Width = 1400;

        CenterWindowOnScreen(window);
        return true;
    }

    private void CenterWindowOnScreen(Window window)
    {
        var screenWidth = SystemParameters.PrimaryScreenWidth;
        var screenHeight = SystemParameters.PrimaryScreenHeight;
        var windowWidth = window.Width;
        var windowHeight = window.Height;

        window.Left = (screenWidth - windowWidth) / 2;
        window.Top = (screenHeight - windowHeight) / 2;
    }
}