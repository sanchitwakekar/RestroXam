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
        private Restaurant restaurant;
        private Category _category;
        public ObservableCollection<string> RestaurantList { get; set; }
        public ObservableCollection<string> CategoryList { get; set; }

        public Command _submit;

        ObservableCollection<Restaurant> restaurantlist;

        User user;

        public ItemViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitItem);
            RestaurantList = GetAllRestaurants();
           

        }
        public ObservableCollection<string> GetAllRestaurants()
        {
            restaurantlist = DBHelper.GetRestaurantList(new DBHelper(), user);
            var restaurentNames = from r in restaurantlist
                                  select r.rest_name;
            return (new ObservableCollection<string>(restaurentNames.ToList()));
        }

        public void updateCategory(String rest)
        {
            SelectedRestaurant = restaurantlist.Where(st => st.rest_name.Equals(rest)).FirstOrDefault();
            try
            {
                var categorylist = DBHelper.GetCategoryList(new DBHelper(), SelectedRestaurant.rest_id);
                var categoryNames = from r in categorylist
                                    select r.cat_name;
                CategoryList = new ObservableCollection<string>(categoryNames.ToList());
               // return (new ObservableCollection<string>(categoryNames.ToList()));
            }
            catch
            {
               
            }
          
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
