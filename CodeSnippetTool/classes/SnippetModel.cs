using CodeSnippetTool.Db;
using System.ComponentModel;
using System.Windows;

namespace CodeSnippetTool.classes
{
    public class SnippetModel : INotifyPropertyChanged
    {
        public int id;
        public string name;
        public string snippetText;
        public string language;
        public int favourite;
        public string description;
        public string hotKey;
        public string dateAdded;
        public string lastCopied;
        public DbConnect dbConnect = new DbConnect();

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
                DbSelect selecter = new DbSelect(dbConnect.databaseConnection);
                if (!selecter.NameIsTaken(value))
                {
                    name = value;
                } else {
                    MessageBox.Show("This name is already taken");
                }
                OnPropertyChanged("Name");
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
                var inputCheck = value;
                int number;
                DbSelect selecter = new DbSelect(dbConnect.databaseConnection);
                if (int.TryParse(inputCheck.Substring(0, 1), out number))
                {
                    inputCheck = "D" + inputCheck; 
                }
                if (!selecter.hotKeyIsTaken(inputCheck))
                {
                    hotKey = inputCheck;
                } else {
                    MessageBox.Show("This hotkey combintion is already taken");
                }
                OnPropertyChanged("HotKey");
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

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            DbUpdate dbUpdater = new DbUpdate(dbConnect);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                dbUpdater.UpdateSnippet(Id, Name, Language, Favourite, HotKey);
            }
            
        }
        #endregion
    }
}
