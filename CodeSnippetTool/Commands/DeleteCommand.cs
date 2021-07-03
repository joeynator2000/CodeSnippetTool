using CodeSnippetTool.classes;
using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class DeleteCommand : CommandBase
    {
        private readonly DisplayViewModel _viewModel;
        private readonly NavigationService<DisplayViewModel> _navigationService;
        public DeleteCommand(DisplayViewModel viewModel, NavigationService<DisplayViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                DbDelete deleter = new DbDelete();
                var param = parameter.ToString();
                deleter.DeleteSnippet(param);
                _navigationService.Navigate();
                MessageBox.Show("Snippet deleted");
            } else
            {
                MessageBox.Show("Please select a snippet");
            }
        }
    }
}
