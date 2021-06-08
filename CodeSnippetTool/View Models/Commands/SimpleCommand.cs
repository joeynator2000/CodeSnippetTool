using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CodeSnippetTool.View_Models.Commands
{
    public class SimpleCommand : ICommand
    {
        //end these files with command at the end
        public event EventHandler CanExecuteChanged;

        public ViewModelBase ViewModel { get; set; }

        public SimpleCommand(ViewModelBase viewModel) 
        {
            this.ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //action here
            this.ViewModel.SimpleMethod();
        }
    }
}
