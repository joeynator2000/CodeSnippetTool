using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using CodeSnippetTool.ViewModels;
using System;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class FindByNameCommand : CommandBase
    {
        private readonly DisplayViewModel _viewModel;
        private readonly NavigationService<DisplayViewModel> _navigationService;

        public FindByNameCommand(DisplayViewModel viewModel, NavigationService<DisplayViewModel> navigationService)
        {
            _viewModel = viewModel;
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
                    DbSelect selecter = new DbSelect();
                    var FoundList = selecter.SelectByName(arr[1].Trim());
                    if (FoundList.Count > 0)
                    {
                        FindByNameStore.FindByNameList = FoundList;
                    } else
                    {
                        MessageBox.Show("There are no results found with under the name: " + arr[1].Trim());
                    }
                }catch(Exception ex)
                {
                    throw ex; 
                }
            }
            _navigationService.Navigate();

        }
    }
}
