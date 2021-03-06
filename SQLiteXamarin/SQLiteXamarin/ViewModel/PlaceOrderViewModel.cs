﻿using Newtonsoft.Json;
using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using SQLiteXamarin.View;
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
        private int _quantity, _orderTotal, _itemTotal;
        private string _Address, _PhoneNumber, _restName;
        Command _PlaceOrder;
        Order o;
        Cart cart;

        public PlaceOrderViewModel(Cart c)
        {
            cart = c;
            //_orderItemList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(c.item);
            _orderItemList = c.cartItems;
            _itemTotal = c.cart_total;
            _restName = c.rest_name;
            //cart_total = calculateTotal(_addedItemList),
            //    user_id = MainPageViewModel.GetCurrentUser().user_id,
            //    rest_id = rest.rest_id,
            //    rest_name = rest.rest_name,
            //    item_count = _itemCount,            
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
            if (!string.IsNullOrWhiteSpace(_Address) && !string.IsNullOrWhiteSpace(_PhoneNumber))
            {
                o = new Order()
                {
                    ordertime = DateTime.UtcNow,
                    Phone_no = _PhoneNumber,
                    order_address = _Address,
                    cart = JsonConvert.SerializeObject(this.cart),
                    user_id = cart.user_id,
                };
                DBHelper.CartToOrder(new DBHelper(), o);
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CustomerMainView());
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
        public string RestaurantName
        {
            get { return _restName; }
            set { _restName = value; }
        }

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
    }
}
