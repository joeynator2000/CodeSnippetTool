using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CodeSnippetTool.Db
{
    class DbDelete
    {
        public DbDelete()
        {
        }

        //TODO Implement button click listener. Wrap function in a try catch block
        public void DeleteSnippet(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Open();
            int id = 1;
            string deleteQuery = "DELETE FROM snippets WHERE id='" + id + "';";
            MySqlCommand delete = new MySqlCommand(deleteQuery, mySqlConnection);
            MySqlDataReader reader;
            reader = delete.ExecuteReader();
            while(reader.Read())
            {
            }
            mySqlConnection.Close();
        }
    }
}