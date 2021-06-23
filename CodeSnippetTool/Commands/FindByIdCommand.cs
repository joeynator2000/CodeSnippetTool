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
        public static int snippetId;

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
            if (parameter != null)
            {
                var param = parameter.ToString();
                //param.Trim();
                var x = param.Substring(param.IndexOf(':') + 1).Trim();
                alreadyCreated = true;
                try
                {
                    snippetId = Convert.ToInt32(x);
                }catch(Exception ex)
                {
                    MessageBox.Show("Please specify id of snippet");
                    alreadyCreated = false;
                }
                //x.Trim();
                
                _navigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Please specify id of snippet");
            }

        }
    }
}
