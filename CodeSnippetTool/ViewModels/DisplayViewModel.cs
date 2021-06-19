using CodeSnippetTool.Commands;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CodeSnippetTool.ViewModels
{
    public class DisplayViewModel : ViewModelBase
    {
        public ICommand NavigateAddingCommand { get; set; }

        public DisplayViewModel(NavigationStore navigationStore) 
        {
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
        }
    }
}
