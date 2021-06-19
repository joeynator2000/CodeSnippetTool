using CodeSnippetTool.classes;
using CodeSnippetTool.Db;
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

        private void Button_Click(object sender, RoutedEventArgs e)

        {
           
            DbConnect conn = new DbConnect();
            DbSelect dbSelect = new DbSelect(conn.databaseConnection);

            //dbSelect.selectSnippet(1);
            List<Snippet> snippets=dbSelect.selectAll();
            
            //RowDefinition row = new RowDefinition();
            //row.Height = new GridLength(50);

            //ColumnDefinition col = new ColumnDefinition();
            //col.Name = "cos";

            for (int i= 0;i < snippets.Count; i++){
                Snippet snp = snippets[i];

                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(50);

                SnippetContainer.RowDefinitions.Add(row);

                //ColumnDefinition col = new ColumnDefinition();
                //col.Name = "cos";

                TextBlock txtBlock = new TextBlock();
                txtBlock.Text = snp.lang;
                txtBlock.FontSize = 20;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
                SnippetContainer.Children.Add(txtBlock);
                Grid.SetColumn(txtBlock, 0);
                Grid.SetRow(txtBlock, i);


                TextBlock snippetDescr = new TextBlock();
                snippetDescr.Text = snp.snippet_text;
                snippetDescr.FontSize = 20;
                snippetDescr.VerticalAlignment = VerticalAlignment.Center;
                snippetDescr.HorizontalAlignment = HorizontalAlignment.Center;
                SnippetContainer.Children.Add(snippetDescr);
                Grid.SetColumn(snippetDescr, 1);
                Grid.SetRow(snippetDescr, i);

            }

            //TextBlock txtBlock = new TextBlock();
            //txtBlock.Text = "Chiki briki";
            //txtBlock.FontSize = 20;
            //txtBlock.VerticalAlignment = VerticalAlignment.Center;
            //txtBlock.HorizontalAlignment = HorizontalAlignment.Center;

            ////txtBlock.Height = 150;

            //SnippetContainer.Children.Add(txtBlock);
            //Grid.SetColumn(txtBlock, 0);
            //Grid.SetRow(txtBlock, 1);

            //SnippetContainer.RowDefinitions.Add(row);

            //var uc = new DisplayView;
            //SnippetContainer.Children.Add(uc);
            //Grid.SetRow(uc, SnippetContainer.RowDefinitions.Count - 1);
        }
    }
}
