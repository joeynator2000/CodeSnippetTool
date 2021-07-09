using CodeSnippetTool.classes;
using CodeSnippetTool.Db;
using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using Microsoft.Toolkit.Uwp.Notifications;
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
                DbSelect dbSelect = new DbSelect();
                var param = parameter.ToString();
                int id=Int32.Parse(param);
                List<Snippets> snippet = dbSelect.selectSnippetId(id);
                ClipboardCopyService.copyToClipBoard(snippet, _viewModel);
                new ToastContentBuilder()
                .AddText("Copied to clipboard")
                .Show();
            }
            else
            {
                MessageBox.Show("Please select a snippet");
            }
        }
    }
}
