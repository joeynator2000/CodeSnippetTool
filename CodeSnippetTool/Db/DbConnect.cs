using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace CodeSnippetTool.Db
{
    public class DbConnect
    {

        string Conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=snippet_db;Allow User Variables=True";
        public MySqlConnection databaseConnection { get; set; }

        public DbConnect()
        {
            try
            {
                this.databaseConnection = new MySqlConnection(Conn);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
