﻿using MySql.Data.MySqlClient;
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

        public DbManager()
        {
            this.adder = new DbInsert();
            this.deleter = new DbDelete();
            this.selecter = new DbSelect();
            this.updater = new DbUpdate();
            this.db = new DbConnect();
        }

        private bool add()
        {
            return false;
        }

        private bool update(int id,string content, string newContent )
        {
            return false;
        }

        private bool delete()
        {
            return false;
        }

        public string select() 
        {

            return this.selecter.selectSnippet(1,getConnection());
        }

        public MySqlConnection getConnection()
        {
            return this.db.getConnection();
        }
    }
}
