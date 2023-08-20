using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI.Fody.Helpers;

namespace Company.Application.Share.Models;

public partial class LaunchModel : ObservableObject
{
    [ObservableProperty]
    private string _info = "";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Percent))]
    private int _count = 15;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Percent))]
    private int _index = 0;

    public double Percent => (double)(Index / (double)Count) * 100;
}

