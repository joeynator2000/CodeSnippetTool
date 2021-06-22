using CodeSnippetTool.classes;
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
                var param = parameter.ToString();
                this._viewModel.DeleteMethod(param);
                _navigationService.Navigate();
            } else
            {
                MessageBox.Show("Please select a snippet");
            }
        }
    }
}
