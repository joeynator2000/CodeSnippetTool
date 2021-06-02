using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace CodeSnippetTool.Db
{
    class DbConnect
    {

        string Conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=snippet_db";
        public MySqlConnection databaseConnection;

        public DbConnect()
        {
            try
            {
                this.databaseConnection = new MySqlConnection(Conn);
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        /*public void startConnection(string command)
        {
            

            MySqlCommand commandDatabase = new MySqlCommand(Conn);

            if (command == "open")
            {
                try
                {
                    databaseConnection.Open();
                }
                catch (Exception e)
                {

                }
            }
            if (command == "close")
            {
                databaseConnection.Close();
            }
            
        }*/

        public void testSelect()
        {
            string query = "SELECT * FROM snippets";

            MySqlCommand check = new MySqlCommand(query);

            MySqlDataReader dr = check.ExecuteReader();

            MySqlCommand commandDatabase = new MySqlCommand(query);
            
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(  reader.GetString(0));
                        Console.WriteLine(   reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void testInsert()
        {
            databaseConnection.Open();
            string query = "INSERT INTO snippets (snippet_text, lang) VALUES ('I am a test snippet text', 'Java')";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("insert complete");
            databaseConnection.Close();
        }

        public MySqlConnection getConnection()
        {
            return this.databaseConnection;
        }

    }


}
