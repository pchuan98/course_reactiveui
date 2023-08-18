using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Company.Application.Launch.ViewModels;

public partial class LaunchViewModel : ObservableObject
{
    [ObservableProperty]
    private string _info = "";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Percent))]
    private int _count = 500;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Percent))]
    private int _index = 0;

    public double Percent => (double)(Index / (double)Count) * 100;

    public LaunchViewModel()
    {
        var timer = new DispatcherTimer(priority: DispatcherPriority.Render)
        {
            Interval = TimeSpan.FromMilliseconds(10),
        };

        timer.Tick += (s, e) =>
        {
            if (Index < Count) Index++;
            else timer.Stop();

            Info = $"Current load : {Index}/{Count}";
        };

        timer.Start();
    }
}