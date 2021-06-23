using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class CopyCommand : CommandBase
    {
        private readonly DisplayViewModel _viewModel;

        public CopyCommand(DisplayViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var param = parameter.ToString();
                this._viewModel.CopyMethod(param);
            }
            else
            {
                MessageBox.Show("Please select a snippet");
            }
        }
    }
}
