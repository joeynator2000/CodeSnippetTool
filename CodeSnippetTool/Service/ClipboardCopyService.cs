using CodeSnippetTool.classes;
using CodeSnippetTool.Db;
using CodeSnippetTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Service
{
    static class ClipboardCopyService
    {
        public static void copyToClipBoard(List<Snippets> snippet, DisplayViewModel _viewModel)
        {
            DbUpdate update = new DbUpdate();
            if (_viewModel.IsSelected)
            {
                MessageBox.Show(snippet[0].snippet_text, $"{snippet[0].HotKey}");
            }
            Clipboard.SetText(snippet[0].snippet_text);
            update.UpdateSnippetLastCopiedDate(snippet[0].id);
        }
    }
}
