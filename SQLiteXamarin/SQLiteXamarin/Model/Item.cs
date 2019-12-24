using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class Item
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string item_name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string  imgurl { get; set; }
        public double category { get; set; }
        public string rest_name { get; set; }

    }
}
