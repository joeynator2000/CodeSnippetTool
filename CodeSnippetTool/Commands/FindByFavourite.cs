using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Commands
{
    public class FindByFavourite : CommandBase
    {
        private readonly DisplayViewModel _viewModel;
        private readonly NavigationService<DisplayViewModel> _navigationService;
        public static bool alreadyCreated;
        public static int snippetId;

        public FindByFavourite(DisplayViewModel viewModel, NavigationService<DisplayViewModel> navigationService) {

            _viewModel = viewModel;
            if (alreadyCreated == true)
            {
                _viewModel.tableAlreadyCreated = true;
            }
            _navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
