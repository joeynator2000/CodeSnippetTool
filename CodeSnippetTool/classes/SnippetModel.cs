using CodeSnippetTool.Db;
using CodeSnippetTool.Hotkeys;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CodeSnippetTool.classes
{
    public class SnippetModel : INotifyPropertyChanged
    {
        public int id;
        public string name;
        public string snippetText;
        public string language;
        public bool favourite;
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
                DbSelect selecter = new DbSelect();
                if (!selecter.NameIsTaken(value))
                {
                    name = value;
                }
                else
                {
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
        public bool Favourite
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
                DbSelect selecter = new DbSelect();
                
                HotKey.ToLower();
                inputCheck.ToLower();

                String[] oldHotKey = HotKey.Split("+");
                String[] newHotKey = inputCheck.Split("+");
                if (newHotKey.Length ==2)
                {
                    var newKey = newHotKey[0];
                    string newModifier = newHotKey[1];
                    char[] modifierCharacters = newModifier.ToCharArray();
                    modifierCharacters[0] = char.ToUpper(modifierCharacters[0]);
                    newModifier = new string(modifierCharacters);
                    inputCheck = newKey + "+" + newModifier;

                    if (newKey.Length == 1)
                    {
                        if (newModifier == "Shift" || newModifier == "Alt")
                        {
                            if (int.TryParse(inputCheck.Substring(0, 1), out number))
                            {
                                inputCheck = "D" + inputCheck;
                            }
                            if (!selecter.hotKeyIsTaken(inputCheck))
                            {
                                if (oldHotKey.Length == 2)
                                {
                                    //Old hot key
                                    var oldKey = oldHotKey[0];
                                    string oldModifier = oldHotKey[1];
                                    char[] oldModifierCharacters = oldModifier.ToCharArray();
                                    oldModifierCharacters[0] = char.ToUpper(oldModifierCharacters[0]);
                                    oldModifier = new string(oldModifierCharacters);

                                    Key keyValue = (Key)Enum.Parse(typeof(Key), oldKey, true);
                                    ModifierKeys modifierValue = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), oldModifier, true);
                                    HotkeysManager.RemoveHotkey(modifierValue, keyValue);
                                }

                                hotKey = inputCheck;
                            }
                            else
                            {
                                MessageBox.Show("This hotkey combintion is already taken");
                            }
                            OnPropertyChanged("HotKey");
                        }
                        else
                        {
                            MessageBox.Show("When updating the hotkey, you can only use modifiers +Alt or +Shift. You can also leave the hotkey empty. Acceptable for example : t+Shift Or s+Alt", "Error updating HotKey");
                        }
                    }
                    else
                    {
                        MessageBox.Show("When updating the hotkey, you can use only one letter for the key value. Acceptable for example : t+Shift Or s+Alt", "Error updating HotKey");

                    }

                }
                else
                {
                    hotKey = inputCheck;
                    OnPropertyChanged("HotKey");
                }
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
        public SnippetModel(int id, string name, string text, string language, bool favourite, string description, string hotKey, string dateAdded, string lastCopied)
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
            DbUpdate dbUpdater = new DbUpdate();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                dbUpdater.UpdateSnippet(Id, Name, Language, Favourite, HotKey);
            }

        }
        #endregion
    }
}
