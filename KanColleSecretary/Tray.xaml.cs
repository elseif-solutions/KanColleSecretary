using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KanColleSecretary
{
    /// <summary>
    /// Interaction logic for Tray.xaml
    /// </summary>
    public partial class Tray : Window
    {
        public Tray()
        {
            InitializeComponent();
        }
        public Window CurrentWindow;

        private void GetYWDNEWindow()
        {
            foreach (Window w in App.Current.Windows)
            {
                if (w.ToString() == "KanColleSecretary.YWDNE")
                {
                    CurrentWindow = w;
                    return;
                }
            }
            return;
        }
        private void KillItem(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AoT_on(object sender, RoutedEventArgs e)
        {
            GetYWDNEWindow();
            CurrentWindow.Topmost = true;
        }

        private void AoT_off(object sender, RoutedEventArgs e)
        {
            CurrentWindow.Topmost = false;
        }

        private void Configuration(object sender, RoutedEventArgs e)
        {
            Thread ConfigThread = new Thread(OpenConfig);
            ConfigThread.Start();

        }
        private void OpenConfig()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                Configuration Config = new Configuration();
                Config.Activate();
                Config.Show();
            });
        }

    }
}