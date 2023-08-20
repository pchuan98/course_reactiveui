using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Company.Core.Dialog
{
    /// <summary>
    /// Interaction logic for PopupBox.xaml
    /// </summary>
    public partial class PopupBox : Popup
    {
        private static readonly PopupBox Dialog = new();
        private static readonly DispatcherTimer Timer = new();

        /// <summary>
        /// the time of auto-fade
        /// </summary>
        public static int FadeMillisecond = 1000;

        /// <summary>
        /// 最小线程循环时间
        /// </summary>
        private static readonly int MinThreadInterval = 5;

        /// <summary>
        /// show a message dialog with auto-fade
        /// </summary>
        /// <param name="message"></param>
        /// <param name="owner">owner of PopupBox</param>
        /// <param name="second"></param>
        public static void Show(string message, Window? owner = null, int second = 1)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    owner ??= Application.Current.MainWindow;

                    Dialog.Message = message ?? "";
                    Dialog.PlacementTarget = owner;
                    Dialog.Placement = PlacementMode.Center;
                    Dialog.StaysOpen = true;
                    Dialog.AllowsTransparency = true;
                    Dialog.Opacity = 0.9;
                    Dialog.VerticalOffset = owner!.ActualHeight / 3;
                    Dialog.IsOpen = true;


                    Timer.Tick -= Timer_Tick;
                    Timer.Tick += Timer_Tick;
                    Timer.Interval = TimeSpan.FromSeconds(second);

                    Timer.Start();
                });


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Timer_Tick(object? sender, EventArgs e)
        {
            Timer.Stop();

            var count = (int)Math.Floor(((double)FadeMillisecond / MinThreadInterval));
            var scale = (Dialog.Opacity) / count;

            Task.Run(() =>
            {
                try
                {
                    for (var i = 0; i < count; i++)
                    {
                        Thread.Sleep(MinThreadInterval);

                        Application.Current?.Dispatcher.BeginInvoke(() =>
                        {
                            Debug.WriteLine(Dialog.Opacity);
                            Dialog.Opacity -= scale;
                        });
                    }

                    Application.Current?.Dispatcher.Invoke(() =>
                    {
                        Dialog.IsOpen = false;
                        Dialog.Message = string.Empty;
                    });
                }
                catch (Exception exception)
                {
                    
                }
            });
        }

        public PopupBox()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message), typeof(string), typeof(PopupBox), new PropertyMetadata(default(string)));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }
    }
}
