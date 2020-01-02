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

namespace SQLiteXamarin.ViewModel
{
    class CustomerRestaurantViewModel : INotifyPropertyChanged
    {
        private int _onStepperValueChanged = 0;
        private ObservableCollection<Item> _itemList;
        private int _itemCount, _cartTotal;
        private Item cartItem;
        private Command<object> _AddItem;
        private Command _increament, _decreament;
        private List<Item> addedItemList;

        public CustomerRestaurantViewModel(Restaurant _CustomerRestaurant)
        {
            _itemList = DBHelper.GetUserRestaurantItemList(new DBHelper(), _CustomerRestaurant.rest_id);
            _AddItem = new Command<object>(AddItemToCart);
            _increament = new Command(increasesteppervalue);
            _decreament = new Command(decreasesteppervalue);
            addedItemList = new List<Item>();
        }

        private void decreasesteppervalue()
        {
            _onStepperValueChanged++;
        }

        private void increasesteppervalue()
        {
            _onStepperValueChanged--;
        }

        private void AddItemToCart(object obj)
        {
            addedItemList.Add(obj as Item);
            //Cart cart = new Cart()
            //{
            //    item = JsonConvert.SerializeObject(addedItemList.ToArray()),
            //    cart_total = calculateTotal(addedItemList),
            //    user_id = MainPageViewModel.GetCurrentUser().user_id,
            //};
            //DBHelper.AddItemToCart(new DBHelper(),cart);
            //Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new PlaceOrderView(cart));
        }
        private int calculateTotal(List<Item> addedItemList)
        {
            var itemPrices = (from x in addedItemList select x.price);
            var itemQuantity = (from x in addedItemList select x.quantity);
            int dotProduct = itemPrices.Zip(itemQuantity, (d1, d2) => d1 * d2).Sum();
            _cartTotal = addedItemList.Count();
            _itemCount = dotProduct;
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
        public Command Increament
        {
            get
            {
                return _increament;
            }
            set
            {
                _increament = value;
            }
        }
        public Command Decreament
        {
            get
            {
                return _decreament;
            }
            set
            {
                _decreament = value;
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
        public int OnStepperValueChanged
        {
            get
            {
                return _onStepperValueChanged;
            }
            set
            {
                _onStepperValueChanged = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OnStepperValueChanged"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
