using CodeSnippetTool.classes;
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
                                                                  
        public SnippetModel selectSnippetId(int id)
        {
            SnippetModel snpt = new SnippetModel();
            this.connection.Open();
            string query = "SELECT * FROM snippets WHERE id=@id";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var snippetId = reader.GetInt32(0);
                            var snippetName = reader.GetString(1);
                            var snippetText = reader.GetString(2);
                            var snippetLang = reader.GetString(3);
                            var snippetFavourite = reader.GetInt32(4);
                            var snippetDescription = reader.GetString(5);
                            var snippetHotKey = reader.GetString(6);
                            var snippetDateAdded = reader.GetString(7);
                            //var snippetDateLastCopied = reader.GetString(8);
                            var snippetDateLastCopied = "null";
                            var c = reader[8] as String;
                            if (!String.IsNullOrEmpty(c))
                            {
                                snippetDateLastCopied = reader.GetString(8);
                            }
                            SnippetModel snp = new SnippetModel(snippetId, snippetName, snippetText, snippetLang, snippetFavourite, snippetDescription, snippetHotKey, snippetDateAdded, snippetDateLastCopied);

                            snpt = snp;
                        }
                    }

                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snpt;
        }

        public SnippetModel selectSnippetName(string name)
        {
            SnippetModel snpt = new SnippetModel();
            this.connection.Open();
            string query = "SELECT * FROM snippets WHERE name=@name";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@name", name);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var snippetId = reader.GetInt32(0);
                            var snippetName = reader.GetString(1);
                            var snippetText = reader.GetString(2);
                            var snippetLang = reader.GetString(3);
                            var snippetFavourite = reader.GetInt32(4);
                            var snippetDescription = reader.GetString(5);
                            var snippetHotKey = reader.GetString(6);
                            var snippetDateAdded = reader.GetString(7);
                            //var snippetDateLastCopied = reader.GetString(8);
                            var snippetDateLastCopied = "null";
                            var c = reader[8] as String;
                            if (!String.IsNullOrEmpty(c))
                            {
                                snippetDateLastCopied = reader.GetString(8);
                            }
                            SnippetModel snp = new SnippetModel(snippetId, snippetName, snippetText, snippetLang, snippetFavourite, snippetDescription, snippetHotKey, snippetDateAdded, snippetDateLastCopied);

                            snpt = snp;
                        }
                    }

                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snpt;
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
        public SnippetModel selectAddDate(string date)
        {
            this.connection.Open();
            SnippetModel snippet = new SnippetModel();
            string query = "SELECT * FROM snippets WHERE date_added=@date";
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@date", date);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime theDate = DateTime.Now;
                        string DateString = theDate.ToString("yyyy-MM-dd H:mm:ss");

                        var snippetId = reader.GetInt32(0);
                        var snippetName = reader.GetString(1);
                        var snippetText = reader.GetString(2);
                        var snippetLang = reader.GetString(3);
                        var snippetFavourite = reader.GetInt32(4);
                        var snippetDescription = reader.GetString(5);
                        var snippetHotKey = "";
                        var snippetHotKeyTmp = reader[6] as String;
                        if (!String.IsNullOrEmpty(snippetHotKeyTmp))
                        {
                            snippetHotKey = reader.GetString(6);
                        }

                        var snippetDateAdded = reader.GetString(7);
                        var snippetDateLastCopied = "null";
                        var c = reader[8] as String;
                        if (!String.IsNullOrEmpty(c))
                        {
                            snippetDateLastCopied = reader.GetString(8);
                        }
                        SnippetModel snp = new SnippetModel(snippetId, snippetName, snippetText, snippetLang, snippetFavourite, snippetDescription, snippetHotKey, snippetDateAdded, snippetDateLastCopied);

                        snippet = snp;
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snippet;
        }



        public List<SnippetModel> selectAll()
        {
            this.connection.Open();
            string query = "SELECT * FROM snippets";
            List<SnippetModel> snippets = new List<SnippetModel>();
            using (var cmd = new MySqlCommand(query, this.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var snippetId = reader.GetInt32(0);

                        var snippetName = "";
                        var snippetNameTmp = reader[1] as String;
                        if (!String.IsNullOrEmpty(snippetNameTmp))
                        {
                            snippetName = reader.GetString(1);
                        }

                        var snippetText = "";
                        var snippetTextTmp = reader[2] as String;
                        if (!String.IsNullOrEmpty(snippetTextTmp))
                        {
                            snippetText = reader.GetString(2);
                        }

                        var snippetLang = "";
                        var snippetLangTmp = reader[3] as String;
                        if (!String.IsNullOrEmpty(snippetLangTmp))
                        {
                            snippetLang = reader.GetString(3);
                        }

                        var snippetFavourite = reader.GetInt32(4);

                        var snippetDescription= "";
                        var snippetDescriptionTmp = reader[5] as String;
                        if (!String.IsNullOrEmpty(snippetDescriptionTmp))
                        {
                            snippetDescription = reader.GetString(5);
                        }

                        var snippetHotKey = "";
                        var snippetHotKeyTmp = reader[6] as String;
                        if (!String.IsNullOrEmpty(snippetHotKeyTmp))
                        {
                            snippetHotKey = reader.GetString(6);
                        }

                        var snippetDateAdded = "";
                        var snippetDateDateAddedTmp = reader[7] as String;
                        if (!String.IsNullOrEmpty(snippetDateDateAddedTmp))
                        {
                            snippetDateAdded = reader.GetString(7);
                        }
                        
                        var snippetDateLastCopied = "";
                        var snippetDateLastCopiedTmp = reader[8] as String;
                        if (!String.IsNullOrEmpty(snippetDateLastCopiedTmp))
                        {
                            snippetDateLastCopied = reader.GetString(8);
                        }
                        SnippetModel snp = new SnippetModel(snippetId, snippetName, snippetText, snippetLang, snippetFavourite,snippetDescription, snippetHotKey, snippetDateAdded, snippetDateLastCopied);
                        snippets.Add(snp);
                        Console.WriteLine($"{snippetText}");
                    }
                }
            }
            Console.WriteLine("select complete");
            this.connection.Close();
            return snippets;
        }

        public bool hotKeyIsTaken(string hotKeyToCheck)
        {
            bool IsTaken = false;
            this.connection.Open();
            string query = "SELECT * FROM snippets WHERE HotKey=@hotKeyToCheck";

            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@hotKeyToCheck", hotKeyToCheck);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        IsTaken = true;
                    }
                }
            }
            this.connection.Close();

            return IsTaken;
        }

        public bool NameIsTaken(string nameToCheck)
        {
            bool IsTaken = false;
            this.connection.Open();
            string query = "SELECT * FROM snippets WHERE name=@nameToCheck";

            using (var cmd = new MySqlCommand(query, this.connection))
            {
                cmd.Parameters.AddWithValue("@nameToCheck", nameToCheck);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        IsTaken = true;
                    }
                }
            }
            this.connection.Close();

            return IsTaken;
        }
    }
}
