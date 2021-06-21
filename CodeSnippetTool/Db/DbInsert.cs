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
        public void InsertSnippet(string snippet_text, string language, int favourite, string description, string dateAdded, string lastCopied)
        {  
            //Full texts id snippet_text lang favourite description date_added last_copie
            //string queryString = "INSERT INTO snippets (snippet_text, lang, favourite, description, date_added, last_copied) VALUES (" + snippet_text + ", " + language + ", " + favourite + ", " + description + ", " + dateAdded + ", " + lastCopied + ")";
            //string queryString = "INSERT INTO snippets (snippet_text, lang, favourite, description, date_added, last_copied) VALUES ('" + snippet_text + "', '" + language + "', " + favourite + ", '" + description + "', null, null)";
            //string queryString = "INSERT INTO snippets(snippet_text, lang, favourite, description, date_added, last_copied) VALUES (@snippet_text, '@lang', @favourite, '@description', null, null)";
            string queryString = "INSERT INTO snippets (snippet_text, lang, favourite, description, date_added, last_copied) VALUES (@snippet_text, @lang, @favourite, @description, @date_added, @last_copied)";
            MySqlCommand command = new MySqlCommand(queryString, Db.databaseConnection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@snippet_text", snippet_text);
            command.Parameters.AddWithValue("@lang", language);
            command.Parameters.AddWithValue("@favourite", favourite);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@date_added", null);
            command.Parameters.AddWithValue("@last_copied", null);
            Db.databaseConnection.Open();
            int i = command.ExecuteNonQuery();
            Db.databaseConnection.Close();
            if (i!=0)
            {
                MessageBox.Show("Data saved");
            }
             
        }
    }
}
