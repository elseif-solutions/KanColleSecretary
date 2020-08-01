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

        private void KillItem(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void ReloadItem(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Hide();
        }

        private void HideItem(object sender, RoutedEventArgs e)
        {

        }

        private void AoT_on(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Topmost = true;
        }

        private void AoT_off(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Topmost = false;
        }
    }
}
