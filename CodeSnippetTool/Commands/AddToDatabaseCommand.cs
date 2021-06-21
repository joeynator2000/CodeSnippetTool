﻿using CodeSnippetTool.Service;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Commands
{
    public class AddToDatabaseCommand : CommandBase
    {
        private readonly AddingViewModel _viewModel;

        public AddToDatabaseCommand(AddingViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.CodeSnippet != null && _viewModel.Description != null && _viewModel.KeyWords != null && _viewModel.Language != null)
            {
                _viewModel.AddToDbdMethod();
            } else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
