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

namespace SQLiteXamarin.ViewModel
{
    class ItemViewModel : INotifyPropertyChanged
    {
        private string _itemName;
        private int _itemPrice, _itemQuantity;
        private Restaurant _restaurant;
        private Category _category;
        public ObservableCollection<Restaurant> RestaurantList { get; set; }
        //public ObservableCollection<Category> CategoryList { get; set; }

        private ObservableCollection<Category> _CategoryList;
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
              
                // return (new ObservableCollection<string>(categoryNames.ToList()));
            }
            catch
            { }
        }
        public ObservableCollection<string> GetAllCategory()
        {
            try
            {
                var categorylist = DBHelper.GetCategoryList(new DBHelper(), SelectedRestaurant.rest_id);
                var categoryNames = from r in categorylist
                                    select r.cat_name;

                return (new ObservableCollection<string>(categoryNames.ToList()));
            }
            catch
            {
                return null;
            }
        }

        private void SubmitItem()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_itemName) && _itemPrice > 0 && _itemQuantity > 0 && !string.IsNullOrWhiteSpace(_restaurant.rest_name) && !string.IsNullOrWhiteSpace(_category.cat_name))
                {
                   
                }
            }
            catch (NullReferenceException n)
            {

            }
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
