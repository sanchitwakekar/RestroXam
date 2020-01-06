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

namespace SQLiteXamarin.ViewModel
{
    class OrderSummaryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Order> _orderList;
        private ObservableCollection<Cart> _cartItemsList;
        public OrderSummaryViewModel()
        {
            _orderList = DBHelper.GetUserOrder(new DBHelper());
            _cartItemsList = GetCartItems();
        }
        private ObservableCollection<Cart> GetCartItems()
        {
            var _s = (_orderList.Select(c => c.cart)).ToList();
            var _ds = new ObservableCollection<Cart>();
            foreach (var c in _s)
            {
                var ds = JsonConvert.DeserializeObject<Cart>(c);
                _ds.Add(ds);
            }
            return new ObservableCollection<Cart>(_ds);
        }
        public ObservableCollection<Order> Orderlist
        {
            get { return _orderList; }
            set
            {
                _orderList = value;
            }
        }
        public ObservableCollection<Cart> CartItemList
        {
            get { return _cartItemsList; }
            set
            {
                _cartItemsList = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
