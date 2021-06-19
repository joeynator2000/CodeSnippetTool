using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;

namespace CodeSnippetTool.ViewModels
{
    public class AddingViewModel : ViewModelBase
    {
        public ICommand NavigateDisplayCommand { get; }

        public AddingViewModel(NavigationStore navigationStore) 
        {
            NavigateDisplayCommand = new NavigateCommand<DisplayViewModel>(new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
        }
    }
}
