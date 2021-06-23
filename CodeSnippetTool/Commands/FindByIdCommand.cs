using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class FindByIdCommand : CommandBase
    {

        private readonly DisplayViewModel _viewModel;
        private readonly NavigationService<DisplayViewModel> _navigationService;
        public static bool alreadyCreated;

        public FindByIdCommand(DisplayViewModel viewModel, NavigationService<DisplayViewModel> navigationService)
        {

            _viewModel = viewModel;
            if (alreadyCreated == true)
            {
                _viewModel.tableAlreadyCreated = true;
            }
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            //if(_viewModel.I)
            //_viewModel.FillList();
            
            
                //var param = parameter.ToString();
                alreadyCreated = true;
                _navigationService.Navigate();
            

            
        }
    }
}
