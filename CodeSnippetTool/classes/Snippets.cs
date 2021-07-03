using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CodeSnippetTool.classes
{
    public class Snippets
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string snippet_text { get; set; }
        public string lang { get; set; }
        public bool favourite { get; set; }
        public string description { get; set; }
        public string HotKey { get; set; }
        public string date_added { get; set; }
        public string last_copied { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
