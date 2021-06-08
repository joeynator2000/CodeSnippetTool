using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CodeSnippetTool.Db
{
    class DbInsert
    {
        public DbInsert()
        {

        }
        //TODO: Button action listener and assign values
        public void InsertSnippet(MySqlConnection mySqlConnection, string snippet_text, string language, string favourite, string dateAdded, string lastCopied)
        {
            MySqlCommand command = new MySqlCommand("insert", mySqlConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@snippet_text", snippet_text);
            command.Parameters.AddWithValue("@lang", language);
            command.Parameters.AddWithValue("@favourite", favourite);
            command.Parameters.AddWithValue("@date_added", dateAdded);
            command.Parameters.AddWithValue("@last_copied", lastCopied);
            mySqlConnection.Open();
            int i = command.ExecuteNonQuery();
            mySqlConnection.Close();
            if(i!=0)
            {
                MessageBox.Show("Data saved");
            }

        }
    }
}
