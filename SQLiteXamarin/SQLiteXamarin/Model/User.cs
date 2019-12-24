using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class User
    {
        [PrimaryKey]
        public string username { get; set; }
        public string passwrod { get; set; }
        public string role { get; set; }
    }
}
