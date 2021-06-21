using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Commands
{
    public class DisplayParamCommand : CommandBase

    {
        public DisplayViewModel ViewModel { get; set; }

        public DisplayParamCommand(DisplayViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var s = parameter as String;
                if (String.IsNullOrEmpty(s))
                    return false;
                return true;
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            //this.ViewModel.ParameterMethod(parameter as String);
            this.ViewModel.getDataFromDb();

            //throw new NotImplementedException();
        }
    }
}
