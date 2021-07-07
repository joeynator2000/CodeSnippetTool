using CodeSnippetTool.classes;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Db;
using CodeSnippetTool.Hotkeys;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace CodeSnippetTool.ViewModels
{
    public class DisplayViewModel : ViewModelBase
    {
        public bool isSelected { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public CopyCommand CopyCommand { get; set; }
        public ICommand NavigateAddingCommand { get; set; }
        public bool tableAlreadyCreated { get; set; }
        public FindByNameCommand FindByNameCommand { get; set; }

        public bool FindCommandTriggered = false;

        private int _Id;
    public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                DbSelect selecter = new DbSelect();
                if (!selecter.NameIsTaken(value, SelectedItem.id))
                {
                    _Name = value;
                }
                else
                {
                    MessageBox.Show("This name is already taken");
                }
            }
        }
        private string _Snippet_text;
        public string Snippet_text
        {
            get
            {
                return _Snippet_text;
            }
            set
            {
                _Snippet_text = value;
            }
        }

        private string _Lang;
        public string Lang
        {
            get
            {
                return _Lang;
            }
            set
            {
                _Lang = value;
            }
        }
        private bool _Favourite;
        public bool Favourite
        {
            get
            {
                return _Favourite;
            }
            set
            {
                _Favourite = value;
            }
        }
        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private string _HotKey;
        public string HotKey
        {
            get
            {
                return _HotKey;
            }
            set
            {
                var inputCheck = value;
                if (!String.IsNullOrEmpty(inputCheck))
                {
                    HotKeyUpdateService updateService = new HotKeyUpdateService(_HotKey, inputCheck, SelectedItem.id);
                    if (updateService.isValidInput())
                    {
                        updateService.removeOldHotKey();
                        _HotKey = updateService.getNewHotKey();
                        _HotKey = value;
                    }
                    else
                    {
                        MessageBox.Show("The hotkey is either not available or invalid");
                    }
                }
            }
        }
        private string _Date_added;
        public string Date_added
        {
            get
            {
                return _Date_added;
            }
            set
            {
                _Date_added = value;
            }
        }
        private string _last_copied;
        public string last_copied
        {
            get
            {
                return _last_copied;
            }
            set
            {
                _last_copied = value;
            }
        }

        public List<SnippetModel> snippetsModel;
        
        public DisplayViewModel(NavigationStore navigationStore)
        {
            this.CopyCommand = new CopyCommand(this);
            this.DeleteCommand = new DeleteCommand(this, new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            this.FindByNameCommand = new FindByNameCommand(this, new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
            FillSqliteList();
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected == value)
                    return;
                isSelected = value;
            }
        }
        public List<SnippetModel> Snippets
        {
            get { return snippetsModel; }
            set { snippetsModel = value; }
        }

        public List<Snippets> _sqliteSnippets { get; set; }
        public List<Snippets> SQLiteSnippets
        {
            get { return _sqliteSnippets; }
            set { _sqliteSnippets = value; }
        }

        Snippets PrevSelectedItem { get; set; }

        Snippets _SelectedItem;
        public Snippets SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                PrevSelectedItem = _SelectedItem;
                _SelectedItem = value;
                if (PrevSelectedItem != null)
                {
                    if (value == null || PrevSelectedItem.id != value.id)
                    {
                        DbUpdate updater = new DbUpdate();
                        DbSelect selecter = new DbSelect();
                        if (!selecter.NameIsTaken(PrevSelectedItem.name, PrevSelectedItem.id) && !selecter.hotKeyIsTaken(PrevSelectedItem.HotKey, PrevSelectedItem.id))
                        {
                            updater.UpdateSnippet(PrevSelectedItem.id, PrevSelectedItem.name, PrevSelectedItem.lang, PrevSelectedItem.favourite, PrevSelectedItem.HotKey);
                        }
                    }
                }
                updateSelectedFields(_SelectedItem);
                OnPropertyChanged("SelectedItem");
            }
        }

        public void updateSelectedFields(Snippets snippet)
        {
            //update values to current if not null
            //if null run update method and make possible changes
            if (snippet != null)
            {
                Id = snippet.id;
                Name = snippet.name;
                Snippet_text = snippet.snippet_text;
                Lang = snippet.lang;
                HotKey = snippet.HotKey;
                Favourite = snippet.favourite;
            }
        }

        public void FillSqliteList()
        {
            if (FindByNameStore.FindByNameList == null)
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
                {
                    conn.CreateTable<Snippets>();
                    SQLiteSnippets = conn.Table<Snippets>().ToList();

                    if (SQLiteSnippets.Count > 0)
                    {
                        foreach (Snippets elem in SQLiteSnippets)
                        {
                            addHotKeyToSystem(elem);
                        }
                    }
                }
            } else
            {
                SQLiteSnippets = FindByNameStore.FindByNameList;
                FindByNameStore.FindByNameList = null;
            }
            
        }

        public void addHotKeyToSystem(Snippets elem)
        {
            if (!String.IsNullOrEmpty(elem.HotKey))
            {
                string hotKey = elem.HotKey;
                String[] arr = elem.HotKey.Split("+");
                var key = arr[0];
                Key keyValue = (Key)Enum.Parse(typeof(Key), key, true);
                var modifier = arr[1];
                ModifierKeys modifierValue = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), modifier, true);
                HotkeysManager.AddHotkey(new GlobalHotkey(modifierValue, keyValue, () =>
                {
                    //CopySnippet(snp);
                    if (IsSelected)
                    {
                        MessageBox.Show(elem.snippet_text, $"{elem.HotKey}");
                    }
                    Clipboard.SetText(elem.snippet_text);

                    //This timer is so that ctrl+V can execute
                    Thread.Sleep(1000);
                }));
                Console.WriteLine(elem.HotKey);
            }
        }
    }
}
