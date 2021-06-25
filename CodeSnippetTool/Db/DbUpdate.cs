using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;


namespace CodeSnippetTool.Db
{
    public class DbUpdate
    {
        public DbConnect db { get; set; }
        public DbSelect dbSelect;
        public DbUpdate(DbConnect db)
        {
            this.db = db;
            this.dbSelect = new DbSelect(db.databaseConnection);
        }

        public void UpdateSnippet(int id, String name, String snippet_text, String lang, int favourite, string description, string hotKey, string dateAdded, string lastCopied)
        {
            if(!dbSelect.hotKeyIsTaken(hotKey))
            {
                if(!dbSelect.NameIsTaken(name))
                {
                    string updateQuery = "UPDATE snippets SET id=@id, name=@name, snippet_text=@snippet_text,lang=@language,favourite=@favourite, description=@description, HotKey=@hotKey, date_added=@dateAdded, last_copied=@lastCopied WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, db.databaseConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
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
                else
                {
                    MessageBox.Show("Name is already taken");
                }
            }
            else
            {
                MessageBox.Show("Hotkey is already taken");
            }
        
        }


        public void UpdateSnippetLastCopiedDate(int id)
        {
            string updateQuery = "UPDATE snippets SET last_copied=@lastCopied WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(updateQuery,db.databaseConnection);
            cmd.CommandText = updateQuery;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@lastCopied",DateTime.Now);
            db.databaseConnection.Open();
            cmd.ExecuteNonQuery();
            db.databaseConnection.Close();
        }


    }
}
