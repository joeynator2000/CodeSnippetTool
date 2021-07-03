using CodeSnippetTool.classes;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Db;
using CodeSnippetTool.Hotkeys;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using MySql.Data.MySqlClient;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeSnippetTool.ViewModels
{
    public class DisplayViewModel : ViewModelBase
    {
        //static String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=snippet_db;Allow User Variables=True";
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataAdapter adapter;
        //DataSet ds;
        public bool isSelected { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public CopyCommand CopyCommand { get; set; }
        public ICommand NavigateAddingCommand { get; set; }
        public bool tableAlreadyCreated { get; set; }
        public FindByNameCommand FindByNameCommand { get; set; }
        

        public List<SnippetModel> snippetsModel;


        public DisplayViewModel(NavigationStore navigationStore)
        {
            this.CopyCommand = new CopyCommand(this);
            this.DeleteCommand = new DeleteCommand(this, new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            this.FindByNameCommand = new FindByNameCommand(this, new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
            //FillList();
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

        public void FillSqliteList()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                conn.CreateTable<Snippets>();
                SQLiteSnippets = conn.Table<Snippets>().ToList();
            }
        }

        public void FillList()
        {
            DbConnect con = new DbConnect();
            DbSelect dbSelect = new DbSelect();
            if (tableAlreadyCreated != true)
            {
                try
                {
                    snippetsModel = dbSelect.selectAll();
                    foreach (SnippetModel snp in snippetsModel)
                    {
                        string hotKey = snp.HotKey;
                        String[] arr = snp.hotKey.Split("+");
                        var key = arr[0];
                        Key keyValue = (Key)Enum.Parse(typeof(Key), key, true);
                        var modifier = arr[1];
                        ModifierKeys modifierValue = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), modifier, true);
                        HotkeysManager.AddHotkey(new GlobalHotkey(modifierValue, keyValue, () =>
                        {
                            //CopySnippet(snp);
                        }));
                    }
                    if (snippetsModel == null || snippetsModel.Count == 0)
                        snippetsModel = new List<SnippetModel>();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            else
            {
                try
                {
                    var name = FindByNameCommand.snippetName;
                    SnippetModel snp = new SnippetModel();
                    snp = dbSelect.selectSnippetName(name);
                    if (snp.Name != null)
                    {
                        if (snippetsModel == null || snippetsModel.Count == 0)
                            snippetsModel = new List<SnippetModel>();
                        if (snp != null)
                        {
                            snippetsModel.Add(snp);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Snippet with name:{name} does not exist", "Find Snippet");
                    }

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();

                }
            }
        }

        //public void DeleteMethod(String deleteId)
        //{
        //    MessageBox.Show("Hello");
        //    using (SQLiteConnection connection = new SQLiteConnection(App.dtabasePath))
        //    {
        //        int idInt = Convert.ToInt32(deleteId);
        //        var query = connection.Table<Snippets>().Where(v => v.name.StartsWith("a"));
        //        connection.Delete(query);
        //        connection.Execute("Delete from Snippets where id = ?", deleteId);

        //        foreach (var stock in query)
        //            MessageBox.Show("Stock: " + stock.name);

        //        var query = connection.Table<Snippets>().Where(id => id.Equals(deleteId));

        //        var toRemove = connection.Table<Snippets>().Where(x => x.id == Convert.ToInt32(deleteId));
        //        connection.Table<Snippets>().Delete(toRemove);
        //        connection.SaveChanges();

        //        foreach (var tmp in query)
        //            Console.WriteLine("deleted id: " + tmp.id.ToString());


        //        connection.CreateTable<Snippets>();
        //        connection.Insert(snippet);
        //    }
        //}
    }
}
