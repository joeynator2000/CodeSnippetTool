using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    class AddToDatabaseCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;
        private readonly AddingViewModel _viewModel;

        public AddToDatabaseCommand(AddingViewModel viewModel, NavigationService<TViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show($"Snippet: {_viewModel.CodeSnippet} Description: {_viewModel.Description}");
            _navigationService.Navigate();
        }
    }
}
