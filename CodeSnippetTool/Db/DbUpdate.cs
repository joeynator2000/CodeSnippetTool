using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace CodeSnippetTool.Db
{
    public class DbUpdate
    {
        public DbConnect db { get; set; }
        public DbUpdate(DbConnect db)
        {
            this.db = db;
        }

        public void UpdateSnippet(int id, String snippet_text, String lang, int favourite)
        {
            string updateQuery = "UPDATE snippets SET id=@id,snippet_text=@snippet_text,lang=@language,favourite=@favourite WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = updateQuery;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@snippet_text", snippet_text);
                cmd.Parameters.AddWithValue("@language", lang);
                cmd.Parameters.AddWithValue("@favourite", favourite);
                db.databaseConnection.Open();
                cmd.ExecuteNonQuery();
                db.databaseConnection.Close();
        }

    }
}
