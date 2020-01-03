using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SQLiteXamarin.Model
{
    public class Cart
    {
        //  [PrimaryKey, AutoIncrement]        
        //public string item { get; set; }
        public int cart_total { get; set; }
        public int user_id { get; set; }
        public int rest_id { get; set; }
        public int item_count { get; set; }
        public string rest_name { get; set; }
        public ObservableCollection<Item> cartItems { get; set; }
    }
}
