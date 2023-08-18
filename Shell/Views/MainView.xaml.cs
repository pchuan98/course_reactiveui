using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Company.Application.Share.Prism;
using Shell.ViewModels;

namespace Shell.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;

            vm!.ModuleManager.LoadModule(ModuleNames.LaunchModuleName);

            vm!.RegionManager.RequestNavigate(RegionNames.Main,"LaunchView");
        }
    }
}
