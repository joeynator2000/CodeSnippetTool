using CodeSnippetTool.Db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CodeSnippetTool.classes
{
    public class SnippetModel : INotifyPropertyChanged
    {
        static String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=snippet_db;Allow User Variables=True";
        MySqlConnection con;
        MySqlCommand cmd;
        public int id;
        public string name;
        public string snippetText;
        public string language;
        public int favourite;
        public string description;
        public string hotKey;
        public string dateAdded;
        public string lastCopied;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
                UpdateDatabase();
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
                UpdateDatabase();
            }
        }
        public string SnippetText
        {
            get
            {
                return snippetText;
            }
            set
            {
                snippetText = value;
                OnPropertyChanged("SnippetText");
                UpdateDatabase();
            }
        }
        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                OnPropertyChanged("Language");
                UpdateDatabase();
            }
        }
        public int Favourite
        {
            get
            {
                return favourite;
            }
            set
            {
                favourite = value;
                OnPropertyChanged("Favourite");

                UpdateDatabase();
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
                
                UpdateDatabase();
            }
        }
        public string HotKey
        {
            get
            {
                return hotKey;
            }
            set
            {
                hotKey = value;
                OnPropertyChanged("Description");

                UpdateDatabase();
            }
        }


        public string DateAdded
        {
            get
            {
                return dateAdded;
            }
            set
            {
                dateAdded = value;
                OnPropertyChanged("DateAdded");
                UpdateDatabase();
            }
        }

        public string LastCopied
        {
            get
            {
                return lastCopied;
            }
            set
            {
                lastCopied = value;
                OnPropertyChanged("LastCopied");
                UpdateDatabase();
            }
        }
        public SnippetModel(int id,string name,string text, string language,int favourite,string description,string hotKey,string dateAdded,string lastCopied)
        {
            this.id = id;
            this.name = name;
            this.snippetText = text;
            this.language = language;
            this.favourite = favourite;
            this.description = description;
            this.hotKey = hotKey;
            this.dateAdded = dateAdded;
            this.lastCopied = lastCopied; 
        }
        public SnippetModel()
        {

        }

        public void UpdateDatabase()
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            cmd = new MySqlCommand("UPDATE snippets SET id=@id,snippet_text=@snippet_text,lang=@language,favourite=@favourite WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@snippet_text", SnippetText);
            cmd.Parameters.AddWithValue("@language", Language);
            cmd.Parameters.AddWithValue("@favourite", Favourite);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
