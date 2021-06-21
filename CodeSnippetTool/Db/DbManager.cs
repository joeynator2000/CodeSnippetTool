using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.Db
{
    

    class DbManager
    {
        public DbInsert adder;

        public DbDelete deleter;

        public DbSelect selecter;

        public DbUpdate updater;

        public DbConnect db;

        public delegate void SelectDelegate(int id, MySqlConnection databaseConnection);

        public DbManager()
        {
            this.db = new DbConnect();
            //this.adder = new DbInsert();
            this.deleter = new DbDelete();
            this.selecter = new DbSelect(this.db.databaseConnection);
            this.updater = new DbUpdate();
        }


        private bool add()
        {
            return false;
        }

        private bool update(int id,string content, string newContent )
        {
            return false;
        }

        public void delete()
        {
            this.deleter.DeleteSnippet(db.databaseConnection);
        }

        public string select() 
        {

            //return this.selecter.selectSnippet(1,db.databaseConnection);
            return "";
        }

    }
}
