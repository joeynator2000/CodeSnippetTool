using CodeSnippetTool.Stores;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CodeSnippetTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "snippet_db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string dtabasePath = System.IO.Path.Combine(folderPath, databaseName);

        protected override void OnStartup(StartupEventArgs e)
        {
            //run table creation here

            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new DisplayViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
