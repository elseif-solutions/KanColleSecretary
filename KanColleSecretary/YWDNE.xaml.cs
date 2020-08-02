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
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class YWDNE : Window
    {
        public YWDNE()
        {
            InitializeComponent();
        }
        void Animate()
        {
            while (true)
            {
                {
                    for (int i = 0; i < 20; i++)
                    {
                        this.Top -= 1;
                        Thread.Sleep(25);
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        this.Top += 1;
                        Thread.Sleep(25);
                    }
                }
            }

        }
        public void CommenceAnimation()
        {
            Thread AnimThread = new Thread(this.Animate);
            AnimThread.Start();

        }
        public void ReloadSecretary(string path, int percentage)
        {
            /* Generate Bitmap of Image */
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            try
            {
                Bitmap.UriSource = new Uri(path, UriKind.Absolute);

            }
            catch
            {
                try
                {
                    Bitmap.UriSource = new Uri("C:/KCS/Secretary.png", UriKind.Absolute);
                }
                catch
                {
                    MessageBox.Show("You haven't set a Secretary.png", "Error");
                    this.Close();
                }
            }
            Bitmap.EndInit();
            /* Set window */
            this.Height = Bitmap.Height;
            this.Width = Bitmap.Width;
            /* Set image */
            Secretary.Source = Bitmap;
            /* Shrink by 45% */
            this.Height = this.Height - (this.Height * (100 - percentage) / 100);
            this.Width = this.Width - (this.Width * (100 - percentage) / 100);

            // Move to bottom right
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Secretary_Initialized(object sender, EventArgs e)
        {
            ReloadSecretary(null, 45);
        }
    }
}
