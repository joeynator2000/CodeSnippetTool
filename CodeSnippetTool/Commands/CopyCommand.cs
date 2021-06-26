using CodeSnippetTool.classes;
using CodeSnippetTool.Db;
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
                DbConnect con = new DbConnect();
                DbSelect dbSelect = new DbSelect(con.databaseConnection);
                var param = parameter.ToString();
                int id=Int32.Parse(param);
                SnippetModel snp=dbSelect.selectSnippetId(id);

                this._viewModel.CopySnippet(snp);
            }
            else
            {
                MessageBox.Show("Please select a snippet");
            }
        }
    }
}
