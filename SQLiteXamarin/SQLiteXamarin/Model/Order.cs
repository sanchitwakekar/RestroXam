using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class Order
    {
        [PrimaryKey, AutoIncrement]
        public int order_id { get; set; }
        public int user_id { get; set; }
        public string cart { get; set; }
        public string order_address { get; set; }
        public string Phone_no { get; set; }
        public DateTime ordertime { get; set; }
        public int orderTotal { get; set; }
    }
}
