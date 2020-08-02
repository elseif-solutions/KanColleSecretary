using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Serialization;
using KanColleSecretary.Logic;

namespace KanColleSecretary
{
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
            GetYWDNEWindow();
        }
        public string path;
        public int perc = 45;
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
        private void KCS_Folder_Initialized(object sender, EventArgs e)
        {
            string root = @"C:\KCS";
            string[] files = Directory.GetDirectories(root);


            /* B R U H */
            foreach (var f in files)
                KCS_Folder.Items.Add(System.IO.Path.GetFileName(f));
        }

        private void KCS_Folder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            path = $"C:/KCS/{KCS_Folder.SelectedItem.ToString()}/Secretary.png";
            (CurrentWindow as YWDNE).ReloadSecretary(path, perc);
        }

        private void ReloadButton(object sender, RoutedEventArgs e)
        {
            (CurrentWindow as YWDNE).ReloadSecretary(path, perc);
        }

        private void Percentage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Percentage.Text.Length == 0)
                return;
            foreach (char c in Percentage.Text)
                if (c < '0' || c > '9') 
                    return;

            perc = Convert.ToInt32(Percentage.Text);
        }

        
         
        
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //TODO: Animation
            Thread CA = new Thread((CurrentWindow as YWDNE).CommenceAnimation);
            
            CA.Start();
        }
    }
}
