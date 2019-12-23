using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class ProductCategory
    {
        [PrimaryKey, AutoIncrement]
        public int cat_id { get; set; }
        public string cat_name { get; set; }
    }
}
