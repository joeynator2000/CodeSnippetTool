﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;

namespace CodeSnippetTool.ViewModels
{
    public class AddingViewModel : ViewModelBase
    {
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
                _language = value;
                OnPropertyChanged(nameof(_language));
            }
        }

        private string _keyWords;
        public string KeyWords
        {
            get
            {
                return _keyWords;
            }

            set
            {
                _keyWords = value;
                OnPropertyChanged(nameof(KeyWords));
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

        public ICommand NavigateDisplayCommand { get; }

        public AddToDatabaseCommand AddToDbCommand { get; set; }

        public void AddToDbdMethod()
        {
            MessageBox.Show($"Snippet: {this.CodeSnippet} Description: {this.Description}");
        }

        public AddingViewModel(NavigationStore navigationStore) 
        {
            NavigateDisplayCommand = new NavigateCommand<DisplayViewModel>(new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            this.AddToDbCommand = new AddToDatabaseCommand(this);
        }


    }
}