using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Db
{
    class DbSelect
    {
        public DbSelect()
        {

        }

        public string selectSnippet(int id, MySqlConnection databaseConnection)
        {
            string snippet = "";
            databaseConnection.Open();
            string query = "SELECT snippet_text FROM snippets WHERE id=@id";
            using (var cmd = new MySqlCommand(query, databaseConnection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetText = reader.GetString(0);

                        snippet = snippetText;
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            databaseConnection.Close();
            return snippet;
        }

        public int selectFavourite(int id, string selectQuery)
        {
            return 0;
        }

        public string selectCategory(int id, string selectQuery)
        {
            return "";
        }

        public string selectDescription(int id, string selectQuery)
        {
            return "";
        }

        public string selectDate(int id, string selectQuery)
        {
            return "";
        }

        public string selectAll(string selectQuery)
        {
            return "";
        }


    }
}
