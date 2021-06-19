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


        public ICommand LoadCommand
        {
            get { return (ICommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.Register("LoadCommand", typeof(ICommand), typeof(DisplayView), new PropertyMetadata(null));


        public DisplayView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //if (LoadCommandProperty != null)
            //{
            //    LoadCommand.Execute(null);
            //}
        }
    }
}
