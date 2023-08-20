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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Company.Core.Ioc;

namespace Company.Application.Launch.Views
{
    /// <summary>
    /// Interaction logic for LaunchView.xaml
    /// </summary>
    public partial class LaunchView : UserControl
    {
        public LaunchView()
        {
            InitializeComponent();

            ZhChecked.Checked += ZhChecked_Checked;
            EnChecked.Checked += EnChecked_Checked;
        }

        private void EnChecked_Checked(object sender, RoutedEventArgs e)
        {
            PrismProvider.LanguageManager?.Set(Core.Constant.Language.En);
        }

        private void ZhChecked_Checked(object sender, RoutedEventArgs e)
        {
            PrismProvider.LanguageManager?.Set(Core.Constant.Language.Zh);
        }
    }
}
