using System;
using CodeSnippetTool.classes;


namespace CodeSnippetTool.Db
{
    public class DbUpdate
    {
        public DbSelect dbSelect;
        public DbUpdate()
        {
        }
        public void UpdateSnippet(int id, String name, String lang, bool favourite, string hotKey)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                conn.Execute("UPDATE snippets SET name = ?, lang = ?, favourite = ?, HotKey = ? Where id = ?", name, lang, favourite, hotKey, id);
            }
        }
        public void UpdateSnippetLastCopiedDate(int id)
        {
            DateTime theDate = DateTime.Now;
            string DateString = theDate.ToString("yyyy-MM-dd H:mm:ss");

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dtabasePath))
            {
                string Query = "UPDATE snippets SET last_copied = ? WHERE id = ?";
                var result = conn.Query<Snippets>(Query, DateString, id);
            }
        }
    }
}
