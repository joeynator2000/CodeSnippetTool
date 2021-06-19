using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Stores;

namespace CodeSnippetTool.ViewModels
{
    public class AddingViewModel : ViewModelBase
    {
        public ICommand NavigateDisplayCommand { get; }

        public AddingViewModel(NavigationStore navigationStore) 
        {
            NavigateDisplayCommand = new NavigateCommand<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore));
        }
    }
}
