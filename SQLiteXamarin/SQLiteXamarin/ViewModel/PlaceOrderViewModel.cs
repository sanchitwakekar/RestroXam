using Newtonsoft.Json;
using SQLiteXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SQLiteXamarin.ViewModel
{
    class PlaceOrderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _orderItemList;
        private int _quantity, _orderTotal,_itemTotal;
        Order o;

        public PlaceOrderViewModel(Cart c)
        {
            var ordercart = c;
            _orderItemList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(c.item);
            _itemTotal = calculateTotal(_orderItemList);
        }
        private int calculateTotal(ObservableCollection<Item> addedItemList)
        {
            var itemPrices = (from x in _orderItemList select x.price);
            var itemQuantity = (from x in _orderItemList select x.quantity);
            int dotProduct = itemPrices.Zip(itemQuantity, (d1, d2) => d1 * d2).Sum();
            _orderTotal = dotProduct;
            _quantity = _orderItemList.Count();            
            return dotProduct;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Item> OrderItemList
        {
            get { return _orderItemList; }
            set
            {
                _orderItemList = value;
            }
        }
        public int OrderTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int ItemTotal
        {
            get { return _itemTotal; }
            set { _itemTotal = value; }
        }
    }
}
