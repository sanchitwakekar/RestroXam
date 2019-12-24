using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string rest_name { get; set; }
        public string area_name { get; set; }
        public double lat { get; set; }
        public double lang { get; set; }
        public string owner_username { get; set; }
    }
}
