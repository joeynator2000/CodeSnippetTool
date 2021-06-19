using CodeSnippetTool.Commands;
using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CodeSnippetTool.ViewModels
{
    public class DisplayViewModel : ViewModelBase
    {
        public ICommand NavigateAddingCommand { get; set; }

        public DisplayViewModel(NavigationStore navigationStore) 
        {
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
        }

        public void getOneSnippet(object SnippetContainer)
        {

            //DbConnect conn = new DbConnect();
            //DbSelect dbSelect = new DbSelect(conn.databaseConnection);

            //dbSelect.selectSnippet(1);
            //SnippetContainer.RowDefinitions.Add(new RowDefinition());
            

            //snippet_text
        }
    }
}
