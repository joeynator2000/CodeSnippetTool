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

        public void UpdateSnippet(int id, String snippet_text, String lang, int favourite, string description, string hotKey, string dateAdded, string lastCopied)
        {
            string updateQuery = "UPDATE snippets SET id=@id,snippet_text=@snippet_text,lang=@language,favourite=@favourite, description=@description, HotKey=@hotKey, date_added=@dateAdded, last_copied=@lastCopied WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(updateQuery, db.databaseConnection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@snippet_text", snippet_text);
                cmd.Parameters.AddWithValue("@language", lang);
                cmd.Parameters.AddWithValue("@favourite", favourite);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@HotKey", hotKey);
                cmd.Parameters.AddWithValue("@date_added", dateAdded);
                cmd.Parameters.AddWithValue("@last_copied", lastCopied);
                db.getConnection().Open();
                cmd.ExecuteNonQuery();
                db.getConnection().Close();
        }
    }
}
