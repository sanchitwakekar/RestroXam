using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Model
{
    class Product
    {
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public string pro_price { get; set; }
        [ForeignKey(typeof(ProductCategory))]
        public string pro_category_id { get; set; }
        [OneToMany]     
        public ProductCategory productCategory { get; set; }
    }
}
