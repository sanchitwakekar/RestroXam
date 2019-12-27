using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int cat_id { get; set; }
        [Unique]
        public string cat_name { get; set; }
        public int rest_id { get; set; }
    }
}
