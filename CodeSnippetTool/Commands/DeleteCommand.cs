using CodeSnippetTool.classes;
using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

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
           var param = parameter.ToString();
            this._viewModel.DeleteMethod(param);
            _navigationService.Navigate();
        }
    }
}
