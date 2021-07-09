using CodeSnippetTool.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CodeSnippetTool.Db
{
    public class DbSelect
    {
        public MySqlConnection connection;
        public DbSelect()
        {
        }                                            
        public List<Snippets> selectSnippetId(int id)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "SELECT * FROM snippets WHERE id = ?";
                var result = conn.Query<Snippets>(Query, id);
                return result;
            }
        }
        public bool hotKeyIsTaken(string hotKeyToCheck)
        {
            bool IsTaken = false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "SELECT * FROM snippets WHERE HotKey = ?";
                var result = conn.Query<Snippets>(Query, hotKeyToCheck);
                if (result.Count > 0)
                {
                    IsTaken = true;
                }
            }

            return IsTaken;
        }

        public bool hotKeyIsTaken(string hotKeyToCheck, int id)
        {
            bool IsTaken = false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "SELECT * FROM snippets WHERE HotKey = ? and id <> ?";
                var result = conn.Query<Snippets>(Query, hotKeyToCheck, id);
                if (result.Count > 0)
                {
                    IsTaken = true;
                }
            }

            return IsTaken;
        }

        public bool NameIsTaken(string nameToCheck)
        {
            bool IsTaken = false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "SELECT * FROM snippets WHERE name = ?";
                var result = conn.Query<Snippets>(Query, nameToCheck);
                if (result.Count > 0)
                {
                    IsTaken = true;
                }
            }

            return IsTaken;
        }

        public bool NameIsTaken(string nameToCheck, int id)
        {
            bool IsTaken = false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "SELECT * FROM snippets WHERE name = ? and id <> ?";
                var result = conn.Query<Snippets>(Query, nameToCheck, id);
                if (result.Count > 0)
                {
                    IsTaken = true;
                }
            }

            return IsTaken;
        }

        public List<Snippets> SelectByName(string name)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "SELECT * FROM snippets WHERE name = ?";
                var result = conn.Query<Snippets>(Query, name);
                return result;
            }
        }
    }
}
