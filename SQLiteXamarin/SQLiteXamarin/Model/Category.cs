using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class Category
    {
        [PrimaryKey, AutoIncrement]
        public int cat_id { get; set; }
        [Unique]
        public string cat_name { get; set; }
        public string rest_id { get; set; }
    }
}
