using CodeSnippetTool.classes;
using CodeSnippetTool.Commands;
using CodeSnippetTool.Db;
using CodeSnippetTool.Hotkeys;
using CodeSnippetTool.Service;
using CodeSnippetTool.Stores;
using MySql.Data.MySqlClient;
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
        static String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=snippet_db;Allow User Variables=True";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataSet ds;
        public DeleteCommand DeleteCommand { get; set; }
        public CopyCommand CopyCommand { get; set; }
        public ICommand NavigateAddingCommand { get; set; }
        public bool tableAlreadyCreated { get; set; }
        public FindByNameCommand FindByNameCommand { get; set; }



        public IList<SnippetModel> snippetsModel;
        public DisplayViewModel(NavigationStore navigationStore)
        {
            this.CopyCommand = new CopyCommand(this);
            this.DeleteCommand = new DeleteCommand(this, new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            this.FindByNameCommand = new FindByNameCommand(this, new NavigationService<DisplayViewModel>(navigationStore, () => new DisplayViewModel(navigationStore)));
            NavigateAddingCommand = new NavigateCommand<AddingViewModel>(new NavigationService<AddingViewModel>(navigationStore, () => new AddingViewModel(navigationStore)));
            FillList();
        }

        public IList<SnippetModel> Snippets
        {
            get { return snippetsModel; }
            set { snippetsModel = value; }
        }

        public void FillList()
        {
            DbConnect con = new DbConnect();
            DbSelect dbSelect = new DbSelect(con.databaseConnection);
            if (tableAlreadyCreated != true)
            {
                try
                {
                    
                    snippetsModel = dbSelect.selectAll();
                    foreach(SnippetModel snp in snippetsModel)
                    {
                        string hotKey = snp.HotKey;
                        //Key keyValue = (Key)Enum.Parse(typeof(Key), hotKey,true);

                        String [] arr=snp.hotKey.Split("+");
                        var key=arr[0];
                        Key keyValue = (Key)Enum.Parse(typeof(Key), key, true);
                        var modifier=arr[1];
                        ModifierKeys modifierValue = (ModifierKeys)Enum.Parse(typeof(ModifierKeys),modifier,true);
                        HotkeysManager.AddHotkey(new GlobalHotkey(modifierValue, keyValue, () => { ShowBox(modifier,key,snp.snippetText,snp); }));
                    }
                    

                    if (snippetsModel == null || snippetsModel.Count==0)
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
                    //MessageBox.Show("" + snp.snippetText,"snippet");
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();

                }
            }
        }

        //public void FillList()
        //{
        //    if (tableAlreadyCreated != true)
        //    {
        //        try
        //        {
        //            //HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.S, () => { ShowBox("Ctrl+S Fired"); }));
        //            con = new MySqlConnection(connectionString);
        //            con.Open();
        //            cmd = new MySqlCommand("SELECT id, snippet_text, lang, favourite, description FROM snippets", con);
        //            adapter = new MySqlDataAdapter(cmd);
        //            ds = new DataSet();
        //            adapter.Fill(ds, "snippets");

        //            if (snippetsModel == null)
        //                snippetsModel = new List<SnippetModel>();

        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                snippetsModel.Add(new SnippetModel
        //                {
        //                    Id = Convert.ToInt32(dr[0].ToString()),
        //                    SnippetText = dr[1].ToString(),
        //                    Language = dr[2].ToString(),
        //                    Favourite = Convert.ToInt32(dr[3].ToString()),
        //                    Description = dr[4].ToString()
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Message.ToString();
        //        }
        //        finally
        //        {
        //            ds = null;
        //            adapter.Dispose();
        //            con.Close();
        //            con.Dispose();
        //        }
        //        //tableAlreadyCreated = true;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //snippetsModel.Clear();
        //            con = new MySqlConnection(connectionString);
        //            con.Open();
        //            var id = FindByIdCommand.snippetId;
        //            cmd = new MySqlCommand($"SELECT * FROM snippets WHERE id={id}", con);
        //            //cmd.Parameters.AddWithValue("@id", id);
        //            //DbSelect dbSelect = new DbSelect(con);
        //            adapter = new MySqlDataAdapter(cmd);
        //            ds = new DataSet();
        //            adapter.Fill(ds, "snippets");

        //            //if (snippetsModel == null)
        //            snippetsModel = new List<SnippetModel>();

        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                snippetsModel.Add(new SnippetModel
        //                {
        //                    Id = Convert.ToInt32(dr[0].ToString()),
        //                    SnippetText = dr[1].ToString(),
        //                    Language = dr[2].ToString(),
        //                    Favourite = Convert.ToInt32(dr[3].ToString()),
        //                    Description = dr[4].ToString()
        //                });
        //            }
        //            FindByIdCommand.alreadyCreated = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Message.ToString();

        //        }
        //        //tableAlreadyCreated = false;
        //    }
        //}
        
        
        public void ShowBox(string modifier,string hotKey,string snippet,SnippetModel snp)
        {
            Clipboard.SetText(snippet);
            DbConnect conn = new DbConnect();
            DbUpdate update = new DbUpdate(conn);
            update.UpdateSnippetLastCopiedDate(snp.id);

            MessageBox.Show(snippet,$"{modifier}+{hotKey}");
        }

        public void CopyMethod(String txt)
        {
            Clipboard.SetText(txt);
            MessageBox.Show("Copied to clipboard!");
        }
        public void DeleteMethod(String id)
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            int Id = Convert.ToInt32(id.ToString());
            DbDelete dbDeleter = new DbDelete();
            dbDeleter.DeleteSnippet(con, Id);
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
   
            }

            #endregion
        }
    }
}
