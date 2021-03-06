﻿using SQLiteXamarin.Data;
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
    class ItemViewModel : INotifyPropertyChanged
    {
        private string _itemName;
        private int _itemPrice, _itemQuantity;
        private Restaurant _restaurant;
        private Category _category;
        public ObservableCollection<Restaurant> RestaurantList { get; set; }
        private ObservableCollection<Category> _CategoryList;
        private ObservableCollection<Item> _ItemList;

        public ObservableCollection<Category> CategoryList
        {
            get { return _CategoryList; }
            set
            {
                if (_CategoryList != value)
                {
                    _CategoryList = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Item> ItemList
        {
            get { return _ItemList; }
            set
            {
                if (_ItemList != value)
                {
                    _ItemList = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command _submit;
        ObservableCollection<Restaurant> restaurantlist;
        User user;

        public ItemViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitItem);
            RestaurantList = GetAllRestaurants();
        }
        public ObservableCollection<Restaurant> GetAllRestaurants()
        {
            restaurantlist = DBHelper.GetRestaurantList(new DBHelper(), user);
            var restaurentNames = from r in restaurantlist
                                  select r.rest_name;
            return (restaurantlist);
        }
        public void getCategory(String rest)
        {
            SelectedRestaurant = restaurantlist.Where(st => st.rest_name.Equals(rest)).FirstOrDefault();
            try
            {
                CategoryList = DBHelper.GetCategoryList(new DBHelper(), SelectedRestaurant.rest_id);
            }
            catch
            { }
        }
      
        private void SubmitItem()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_itemName) && _itemPrice > 0 && _itemQuantity > 0 && !string.IsNullOrWhiteSpace(_restaurant.rest_name) && !string.IsNullOrWhiteSpace(_category.cat_name))
                {
                    Item item = new Item()
                    {
                        item_name = _itemName,
                        price = _itemPrice,
                        quantity = _itemQuantity,
                        cat_id = SelectedCategory.cat_id,
                        rest_id = SelectedRestaurant.rest_id
                    };
                    DBHelper.AddItem(new DBHelper(), item);
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new OwnerView());
                }
            }
            catch (NullReferenceException n)
            {}
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
                try
                {
                    CategoryList = DBHelper.GetCategoryList(new DBHelper(), SelectedRestaurant.rest_id);
                }
                catch
                { }
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
                try
                {
                    ItemList = DBHelper.GetItemList(new DBHelper(), SelectedCategory.cat_id);
                }
                catch
                { }
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
