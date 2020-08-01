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

namespace KanColleSecretary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void ReloadSecretary(string path)
        {
            /* Generate Bitmap of Image */
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri("C:/KCS/Secretary.png", UriKind.Absolute);
            Bitmap.EndInit();
            /* Set window */
            this.Height = Bitmap.Height;
            this.Width = Bitmap.Width;
            /* Set image */
            Secretary.Source = Bitmap;
            /* Shrink by 45% */
            this.Height = this.Height - (this.Height * 45 / 100);
            this.Width = this.Width - (this.Width * 45 / 100);

            // Move to bottom right
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            ReloadSecretary(null);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            /* Initialize tray */
            Tray TrayTB = new Tray();
            TrayTB.Activate();
        }
    }
}
