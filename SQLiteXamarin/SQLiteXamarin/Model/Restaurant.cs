using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int rest_id { get; set; }
        [Unique]
        public string rest_name { get; set; }
        public string area { get; set; }
        public double lat { get; set; }
        public double lang { get; set; }
        public int owner_id { get; set; }
    }
}
