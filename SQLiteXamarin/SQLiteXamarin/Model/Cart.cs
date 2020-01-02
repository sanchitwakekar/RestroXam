using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int cart_id { get; set; }
        public string item { get; set; }
        public int user_id { get; set; }       
        public int cart_total { get; set; }        
    }
}
