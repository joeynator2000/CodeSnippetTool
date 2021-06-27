using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class FindByNameCommand : CommandBase
    {
        private readonly DisplayViewModel _viewModel;
        private readonly NavigationService<DisplayViewModel> _navigationService;
        public static bool alreadyCreated;
        public static string snippetName;

        public FindByNameCommand(DisplayViewModel viewModel, NavigationService<DisplayViewModel> navigationService)
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
            if (parameter != null)
            {
                try
                {
                    var param = parameter.ToString();
                    String[] arr = param.Split(":");
                    if (arr.Length < 2)
                    {
                        alreadyCreated = false;
                    }
                    else
                    {
                        snippetName = arr[1].Trim();
                        alreadyCreated = true;
                    }

                }catch(Exception ex)
                {
                    throw ex; 

                }
            }
            else
            {
                alreadyCreated = false;
            }
            _navigationService.Navigate();

        }
    }
}
