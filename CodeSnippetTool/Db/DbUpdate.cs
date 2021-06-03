using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace CodeSnippetTool.Db
{
    class DbUpdate
    {
        public DbUpdate{

    }
    public void UpdateSnippet(int id, String snippet_text, String lang, String favourite, String date_added, String last_copied)
        {
            mySqlConnection.Open();
            string updateQuery = "UPDATE snippets SET id=@id,snippet_text=@snippet_text,lang=@language,favourite=@favourite,date_added=@date_added,last_copied=@last_copied WHERE id=@id";
            if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = updateQuery;
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@snippet_text",snippet_text);
            cmd.Parameters.AddWithValue("@language",lang);
            cmd.Parameters.AddWithValue("@favourite",favourite);
            cmd.Parameters.AddWithValue("@date_added",date_added);
            cmd.Parameters.AddWithValue("@last_copied",last_copied);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
            Bind();
        }
        }
}
