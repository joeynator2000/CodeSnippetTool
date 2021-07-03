using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLite;

namespace CodeSnippetTool.Db
{
    public class DbDelete
    {
        public DbDelete()
        {
        }
        public void DeleteSnippet(string id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dtabasePath))
            {
                connection.Execute("Delete from Snippets where id = ?", id);
            }
        }
    }
}