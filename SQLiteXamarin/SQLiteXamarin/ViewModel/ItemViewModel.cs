using SQLiteXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class ItemViewModel : INotifyPropertyChanged
    {
        private string _itemName;
        private int _itemPrice, _itemQuantity;
        private Restaurant _restaurant;
        private Category _category;
        public ObservableCollection<Restaurant> RestaurantList { get; set; }
        public ObservableCollection<Category> CategoryList { get; set; }

        public Command _submit;
      
        User user;

        public ItemViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitItem);
            RestaurantList = GetAllRestaurants();
            CategoryList = GetAllCategory();
        }
        public ObservableCollection<Restaurant> GetAllRestaurants()
        {
            return null;
        }

        public ObservableCollection<Category> GetAllCategory()
        {
            return null;
        }

        private void SubmitItem()
        {
           
        }

        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }

        public int ItemPrice
        {
            get
            {
                return _itemPrice;
            }
            set
            {
                _itemPrice = value;
            }
        }

        public int ItemQuantity
        {
            get
            {
                return _itemQuantity;
            }
            set
            {
                _itemQuantity = value;
            }
        }

        public Restaurant SelectedRestaurant
        {
            get
            {
                return _restaurant;
            }
            set
            {
                _restaurant = value;
            }
        }
        public Category SelectedCategory
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }
        public Command Submit
        {
            get
            {
                return _submit;
            }
            set
            {
                _submit = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
