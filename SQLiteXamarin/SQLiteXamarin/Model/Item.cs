﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class Item
    {
        [PrimaryKey, AutoIncrement]
        public int item_id { get; set; }
        public string item_name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }        
        public double cat_id{ get; set; }
        public string rest_id { get; set; }
    }
}