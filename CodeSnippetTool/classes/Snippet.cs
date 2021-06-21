using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippetTool.classes
{
    class Snippet
    {
        public int id { get; set; }
        public string snippet_text { get; set; }
        public int favourite { get; set; }
        public string description { get; set; }

        public string lang { get; set; }
        public string date_added { get; set; }
        public string last_copied { get; set; }

        public Snippet(int id,string snippet_text, string lang,int favourite,string description,string date_added, string last_copied)
        {
            this.id = id;
            this.snippet_text = snippet_text;
            this.lang = lang;
            this.favourite = favourite;
            this.description = description;
            this.date_added = date_added;
            this.last_copied = last_copied;
        }
    }
}
