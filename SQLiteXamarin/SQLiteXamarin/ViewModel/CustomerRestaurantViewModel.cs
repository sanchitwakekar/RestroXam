using Newtonsoft.Json;
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
using Xamarin.Forms.Internals;

namespace SQLiteXamarin.ViewModel
{
    class CustomerRestaurantViewModel : INotifyPropertyChanged
    {
        private int _onStepperValueChanged = 0;
        private ObservableCollection<Item> _itemList;
        private int _itemCount, _cartTotal;
        private Command<object> _AddItem;
        private ObservableCollection<Item> _addedItemList;
        private Command _viewCart;
        Cart cart;
        Restaurant rest;

        public CustomerRestaurantViewModel(Restaurant _CustomerRestaurant)
        {
            rest = _CustomerRestaurant;
            _itemList = DBHelper.GetUserRestaurantItemList(new DBHelper(), _CustomerRestaurant.rest_id);
            _itemList.ForEach(i =>
            {
                i.quantity = 0;
            });
            _AddItem = new Command<object>(AddItemToCart);
            _addedItemList = new ObservableCollection<Item>();
            _viewCart = new Command(ViewCartPage);
        }

        private void ViewCartPage(object obj)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new PlaceOrderView(cart));
        }

        private void AddItemToCart(object obj)
        {
            var deleteSame = _addedItemList.FirstOrDefault(cus => cus.item_id == (obj as Item).item_id);
            _addedItemList.Remove(deleteSame);
            if ((obj as Item).quantity > 0)
            {
                _addedItemList.Add(obj as Item);
            }
            cart = new Cart()
            {
                // item = JsonConvert.SerializeObject(_addedItemList.ToArray()),
                cart_total = calculateTotal(_addedItemList),
                user_id = MainPageViewModel.GetCurrentUser().user_id,
                rest_id = rest.rest_id,
                rest_name = rest.rest_name,
                item_count = _itemCount,
                cartItems = _addedItemList,
            };
        }
        private int calculateTotal(ObservableCollection<Item> addedItemList)
        {
            var itemPrices = (from x in addedItemList select x.price);
            var itemQuantity = (from x in addedItemList select x.quantity);
            int dotProduct = itemPrices.Zip(itemQuantity, (d1, d2) => d1 * d2).Sum();
            _cartTotal = dotProduct;
            _itemCount = addedItemList.Count();
            return dotProduct;
        }
        public int ItemCount
        {
            get
            {
                return _itemCount;
            }
            set
            {
                _itemCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemCount"));
            }
        }
        public int CartTotal
        {
            get
            {
                return _cartTotal;
            }
            set
            {
                _cartTotal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CartTotal"));
            }
        }
        public Command<Object> AddItem
        {
            get
            {
                return _AddItem;
            }
            set
            {
                AddItem = value;
            }
        }
        public Command ViewCart
        {
            get
            {
                return _viewCart;
            }
            set
            {
                _viewCart = value;
            }
        }

        public ObservableCollection<Item> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
            }
        }
        public ObservableCollection<Item> AddedItemList
        {
            get
            {
                return _addedItemList;
            }
            set
            {
                _addedItemList = value;
            }
        }
        public int OnStepperValueChanged
        {
            get
            {
                return _onStepperValueChanged;
            }
            set
            {
                _onStepperValueChanged = value;
                OnPropertyChanged("AddItem");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddItem"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
