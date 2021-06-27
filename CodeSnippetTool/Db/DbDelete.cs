using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CodeSnippetTool.Db
{
    public class DbDelete
    {
        public DbDelete()
        {
        }
        public void DeleteSnippet(MySqlConnection mySqlConnection, int id)
        {
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