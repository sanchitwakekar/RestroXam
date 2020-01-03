using Newtonsoft.Json;
using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace SQLiteXamarin.ViewModel
{
    class PlaceOrderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _orderItemList;
        private int _quantity, _orderTotal,_itemTotal;
        private string _Address, _PhoneNumber;
        Command _PlaceOrder;
        Order o;

        public PlaceOrderViewModel(Cart c)
        {
            var ordercart = c;
            _orderItemList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(c.item);
            _itemTotal = calculateTotal(_orderItemList);
            PlaceOrder = new Command(PlaceUserOrders);
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
        private void PlaceUserOrders()
        {
            if(!string.IsNullOrWhiteSpace(_Address) && !string.IsNullOrWhiteSpace(_PhoneNumber))
            {
                
            }
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
        public Command PlaceOrder
        {
            get
            {
                return _PlaceOrder;
            }
            set
            {
                _PlaceOrder = value;
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

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
    }
}
