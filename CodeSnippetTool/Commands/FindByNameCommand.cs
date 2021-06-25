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
            //if(_viewModel.I)
            //_viewModel.FillList();
            if (parameter != null)
            {
                try
                {
                    var param = parameter.ToString();
                    //param.Trim();
                    //snippetName = param.Substring(param.IndexOf(':') + 1).Trim();
                    String[] arr = param.Split(":");
                    //var t=arr[0];
                    //var l=arr[1];
                    if (arr.Length < 2)
                    {
                        alreadyCreated = false;
                        //MessageBox.Show("Please specify Name of snippet");
                    }
                    else
                    {
                        snippetName = arr[1].Trim();
                        alreadyCreated = true;
                    }

                    _navigationService.Navigate();
                }catch(Exception ex)
                {
                    throw ex; 

                }
            }
            else
            {
                MessageBox.Show("Please specify id of snippet");
                alreadyCreated = false;
            }

        }
    }
}
