using CodeSnippetTool.classes;
using CodeSnippetTool.Db;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeSnippetTool.Views
{
    /// <summary>
    /// Interaction logic for DisplayView.xaml
    /// </summary>
    public partial class DisplayView : UserControl
    {

        public DisplayView()
        {
            InitializeComponent();
        }
        private void BlackMode_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsChecked = true;
            if (rb != null)
            {                
                Properties.Settings.Default.ColorMode = "Black";
                Properties.Settings.Default.Save();
            }
        }

        private void DarkMode_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsChecked = true;
            if (rb != null)
            {
                Properties.Settings.Default.ColorMode = "Dark";
                Properties.Settings.Default.Save();
            }
        }

        private void LightMode_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsChecked = true;
            if (rb != null)
            {                
                Properties.Settings.Default.ColorMode = "Light";
                Properties.Settings.Default.Save();
            }
        }

        private void WhiteMode_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsChecked = true;
            if (rb != null)            
            {
                Properties.Settings.Default.ColorMode = "White";
                Properties.Settings.Default.Save();
            }
        }


        private void SnippetsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
