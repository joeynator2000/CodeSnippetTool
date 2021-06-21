using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Commands
{
    public class DisplayCommand : CommandBase
    {

        public DisplayViewModel ViewModel { get; set; }
        public DisplayCommand(DisplayViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }


        public override void Execute(object parameter)
        {
            this.ViewModel.getDataFromDb();

            //this.ViewModel.simpleMethod();
            //throw new NotImplementedException();
        }





        public override string ToString()
        {
            return $"{{}}";
        }
    }
}
