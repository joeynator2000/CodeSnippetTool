    using MySql.Data.MySqlClient;
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

        //TODO: Button action listener and assign values
        public void InsertSnippet(string Name, string snippet_text, string language, int favourite, string HotKey, string Modefier, string description, string dateAdded)
        {
            if (HotKey != null && Modefier != null)
            {
                int number;
                if (int.TryParse(HotKey, out number))
                {
                    HotKey = "D" + number.ToString();
                }

                string mod = Modefier.Substring(Modefier.IndexOf(':') + 1).Trim();

                HotKey += $"+{mod}";

                DbSelect dataSelecter = new DbSelect(Db.databaseConnection);
                if (dataSelecter.hotKeyIsTaken(HotKey))
                {
                    HotKey = "";
                    MessageBox.Show("The hotkey is taken, please add one on the display page");
                }
            }

            string queryString = "INSERT INTO snippets (name, snippet_text, lang, favourite, description, HotKey, date_added, last_copied) VALUES (@name, @snippet_text, @lang, @favourite, @description, @HotKey, @date_added, @last_copied)";
            MySqlCommand command = new MySqlCommand(queryString, Db.databaseConnection);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@snippet_text", snippet_text);
            command.Parameters.AddWithValue("@lang", language);
            command.Parameters.AddWithValue("@favourite", favourite);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@HotKey", HotKey);
            command.Parameters.AddWithValue("@date_added", dateAdded);
            command.Parameters.AddWithValue("@last_copied", null);
            Db.databaseConnection.Open();
            int i = command.ExecuteNonQuery();
            Db.databaseConnection.Close();
            if (i!=0)
            {
                MessageBox.Show("Data saved");
            }
        }

        public void InsertKeywords(int id, Array keywords)
        {
            foreach (string keyword in keywords)
            {
                string queryString = "INSERT INTO key_words (snippet_id, word) VALUES (@snippet_id, @word)";
                MySqlCommand command = new MySqlCommand(queryString, Db.databaseConnection);
                command.Parameters.AddWithValue("@snippet_id", id);
                command.Parameters.AddWithValue("@word", keyword);
                Db.databaseConnection.Open();
                int i = command.ExecuteNonQuery();
                Db.databaseConnection.Close();
            }
        }
    }
}
