using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using CodeSnippetTool.classes;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using SQLite;

namespace CodeSnippetTool.ViewModels
{
    public class AddingViewModel : ViewModelBase
    {
        private string _modefier;
        public string Modefier
        {
            get
            {
                return _modefier;
            }

            set
            {
                _modefier = value;
                OnPropertyChanged(nameof(Modefier));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _hotKey;
        public string HotKey
        {
            get
            {
                return _hotKey;
            }

            set
            {
                _hotKey = value;
                OnPropertyChanged(nameof(HotKey));
            }
        }

        private string _codeSnippet;
        public string CodeSnippet 
        {
            get
            {
                return _codeSnippet;
            }

            set
            {
                _codeSnippet = value;
                OnPropertyChanged(nameof(CodeSnippet));
            }
        }
        private string _language;
        public string Language 
        {
            get
            {
                return _language;
            }

            set
            {
                var x = value.Substring(value.IndexOf(':') + 1);
                _language = x;
                OnPropertyChanged(nameof(_language));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private bool _favourite = false;
        public bool Favourite
        {
            get
            {
                return _favourite;
            }

            set
            {
                _favourite = value;
                OnPropertyChanged(nameof(Favourite));
            }
        }

        public ICommand NavigateDisplayCommand { get; }

        public AddToDatabaseCommand AddToDbCommand { get; set; }

        public void AddToDbdMethod()
        {
            /* DbConnect con = new DbConnect();
             DbInsert inserter = new DbInsert(con);
             DbSelect idSelecter = new DbSelect(con.getConnection());

             DateTime theDate = DateTime.Now;
             string DateString = theDate.ToString("yyyy-MM-dd H:mm:ss");
             int fav = 0;
             if (_favourite)
             {
                 fav = 1;
             }

             inserter.InsertSnippet(_name, _codeSnippet, _language, fav, _hotKey, _modefier, _description, DateString);
 */
            
        }

        public AddingViewModel(NavigationStore navigationStore) 
        {
            NavigateDisplayCommand = new NavigateCommand<DisplayViewModel>(new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            AddToDbCommand = new AddToDatabaseCommand(this, new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
        }
    }
}
