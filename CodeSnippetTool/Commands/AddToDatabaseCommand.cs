using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class AddToDatabaseCommand : CommandBase
    {
        private readonly AddingViewModel _viewModel;
        private readonly NavigationService<AddingViewModel> _navigationService;
        public AddToDatabaseCommand(AddingViewModel viewModel, NavigationService<AddingViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            if (_viewModel.CodeSnippet != null && _viewModel.Description != null && _viewModel.Language != null && _viewModel.Name != null && 
                ((_viewModel.HotKey != null && _viewModel.Modefier != null) || (_viewModel.HotKey == null && _viewModel.Modefier == null)))
            {
                DbSelect selecter = new DbSelect();
                DbInsert inserter = new DbInsert();
                if (!selecter.NameIsTaken(_viewModel.Name))
                {
                    inserter.InsertSnippet(_viewModel);
                    _navigationService.Navigate();
                } else {
                    MessageBox.Show("The name is already taken");
                }
            } else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
