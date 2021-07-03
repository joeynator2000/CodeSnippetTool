using CodeSnippetTool.classes;
using CodeSnippetTool.ViewModels;
using MySql.Data.MySqlClient;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Db
{
    class DbInsert
    {
        public DbConnect Db { get; set; }
        public DbInsert(DbConnect dbConnection)
        {
            Db = dbConnection;
        }

        public void InsertSnippet(AddingViewModel _viewModel)
        {
            DateTime theDate = DateTime.Now;
            string DateString = theDate.ToString("yyyy-MM-dd H:mm:ss");

            if (_viewModel.HotKey != null && _viewModel.Modefier != null)
            {
                int number;
                if (int.TryParse(_viewModel.HotKey, out number))
                {
                    _viewModel.HotKey = "D" + number.ToString();
                }

                string mod = _viewModel.Modefier.Substring(_viewModel.Modefier.IndexOf(':') + 1).Trim();

                _viewModel.HotKey += $"+{mod}";

                DbSelect dataSelecter = new DbSelect(Db.databaseConnection);
                if (dataSelecter.hotKeyIsTaken(_viewModel.HotKey))
                {
                    _viewModel.HotKey = "";
                    MessageBox.Show("The hotkey is taken, it is possible to add one on the display page");
                }
            }

            Snippets snippet = new Snippets()
            {
                name = _viewModel.Name,
                snippet_text = _viewModel.CodeSnippet,
                lang = _viewModel.Language,
                favourite = _viewModel.Favourite,
                description = _viewModel.Description,
                HotKey = _viewModel.HotKey,
                date_added = DateString,
                last_copied = null
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.dtabasePath))
            {
                connection.CreateTable<Snippets>();
                connection.Insert(snippet);
            }

            DbSelect selecter = new DbSelect(Db.databaseConnection);

            //string queryString = "INSERT INTO snippets (name, snippet_text, lang, favourite, description, HotKey, date_added, last_copied) VALUES (@name, @snippet_text, @lang, @favourite, @description, @HotKey, @date_added, @last_copied)";
            //MySqlCommand command = new MySqlCommand(queryString, Db.databaseConnection);
            //command.Parameters.AddWithValue("@name", Name);
            //command.Parameters.AddWithValue("@snippet_text", snippet_text);
            //command.Parameters.AddWithValue("@lang", language);
            //command.Parameters.AddWithValue("@favourite", favourite);
            //command.Parameters.AddWithValue("@description", description);
            //command.Parameters.AddWithValue("@HotKey", HotKey);
            //command.Parameters.AddWithValue("@date_added", dateAdded);
            //command.Parameters.AddWithValue("@last_copied", null);
            //Db.databaseConnection.Open();
            //int i = command.ExecuteNonQuery();
            //Db.databaseConnection.Close();
            //if (i != 0)
            //{
            //    MessageBox.Show("Data saved");
            //}
        }
    }
}
