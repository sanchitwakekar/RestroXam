using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int user_id { get; set; }
        [Unique]
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
