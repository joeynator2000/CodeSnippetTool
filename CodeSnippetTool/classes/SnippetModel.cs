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
        public string snippet_text;
        public string language;
        public int favourite;
        public string description;
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
        public string SnippetText
        {
            get
            {
                return snippet_text;
            }
            set
            {
                snippet_text = value;
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
