using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using CodeSnippetTool.classes;
using MySql.Data.MySqlClient;


namespace CodeSnippetTool.Db
{
    public class DbUpdate
    {
        public DbConnect db { get; set; }
        public DbSelect dbSelect;
        public DbUpdate()
        {
        }
        public void UpdateSnippet(int id, String name, String lang, int favourite, string hotKey)
        {
            string updateQuery = "UPDATE snippets SET name=@name, lang=@language, favourite=@favourite, HotKey=@hotKey WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(updateQuery, db.databaseConnection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@language", lang);
            cmd.Parameters.AddWithValue("@favourite", favourite);
            cmd.Parameters.AddWithValue("@HotKey", hotKey);
            db.getConnection().Open();
            cmd.ExecuteNonQuery();
            db.getConnection().Close();
        }
        public void UpdateSnippetLastCopiedDate(int id)
        {
            //string updateQuery = "UPDATE snippets SET last_copied=@lastCopied WHERE id=@id";
            //MySqlCommand cmd = new MySqlCommand(updateQuery,db.databaseConnection);
            //cmd.CommandText = updateQuery;
            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Parameters.AddWithValue("@lastCopied",DateTime.Now);
            //db.databaseConnection.Open();
            //cmd.ExecuteNonQuery();
            //db.databaseConnection.Close();

            DateTime theDate = DateTime.Now;
            string DateString = theDate.ToString("yyyy-MM-dd H:mm:ss");

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "UPDATE snippets SET last_copied = ? WHERE id = ?";
                var result = conn.Query<Snippets>(Query, DateString, id);
            }
        }
    }
}
