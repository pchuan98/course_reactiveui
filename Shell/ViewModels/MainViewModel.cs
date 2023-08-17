using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Shell.ViewModels;

public partial class MainViewModel:ObservableObject
{
    [ObservableProperty]
    private string _title = "Hello World!";
}