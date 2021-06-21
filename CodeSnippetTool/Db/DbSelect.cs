﻿using CodeSnippetTool.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Db
{
    class DbSelect
    {

        public MySqlConnection connection;

        public DbSelect(MySqlConnection connection)
        {
            this.connection = connection;
        }



                                                                  
        public string selectSnippet(int id)
        {
            string snippet = "";
            this.connection.Open();
            string query = "SELECT snippet_text FROM snippets WHERE id=@id";
            using (var cmd = new MySqlCommand(query, this.connection))
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
            this.connection.Close();
            return snippet;
        }

        public List<string> selectFavourite(int favourite)
        {
            List<string> snippets = new List<string>();

            this.connection.Open();
            string query = "SELECT snippet_text FROM snippets WHERE favourite=@favourite";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@id", favourite);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetText = reader.GetString(0);

                        snippets.Add(snippetText);
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snippets;
        }

        public List<string> selectLanguage(string language)
        {
            List<string> snippets = new List<string>();

            this.connection.Open();
            string query = "SELECT snippet_text FROM snippets WHERE lang=@lang";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@lang", language);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetText = reader.GetString(0);

                        snippets.Add(snippetText);
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snippets;
        }

        public string selectDescription(int id)
        {
            string description = "";
            this.connection.Open();
            string query = "SELECT snippet_text FROM snippets WHERE lang=@language";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetText = reader.GetString(0);

                        description = snippetText;
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return description;
        }

        public List<string> selectAddDate(string date)
        {
            List<string> snippets = new List<string>();
            this.connection.Open();
            string query = "SELECT snippet_text FROM snippets WHERE date_added=@date";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@date", date);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetText = reader.GetString(0);

                        snippets.Add(snippetText);
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snippets;
        }

        public List<Snippet> selectAll()
        {
            this.connection.Open();
            string query = "SELECT * FROM snippets";
            List<Snippet> snippets = new List<Snippet>();
            using (var cmd = new MySqlCommand(query, this.connection))
            {

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetId = reader.GetInt32(0);
                        var snippetText = reader.GetString(1);
                        var snippetLang = reader.GetString(2);
                        var snippetFavourite = reader.GetInt32(3);
                        var snippetDescription= reader.GetString(4);
                        //var snippetDateAdded = reader.GetString(5);
                        var snippetDateAdded = "snippetDateAdded";
                        //var snippetDateLastCopied = reader.GetString(6);
                        var snippetDateLastCopied = "snippetDateLastCopied";
                        Snippet snp = new Snippet(snippetId, snippetText, snippetLang, snippetFavourite,snippetDescription, snippetDateAdded, snippetDateLastCopied);

                        snippets.Add(snp);
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snippets;
        }


    }
}
