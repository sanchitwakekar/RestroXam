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
    class CategoryViewModel : INotifyPropertyChanged
    {
        private string _foodcategory;
        private Restaurant _restaurant;
        public ObservableCollection<Restaurant> RestaurantList { get; set; }
        public ObservableCollection<string> categorynames { get; set; }
        ObservableCollection<Restaurant> restaurantlist;
        public Command _submit;
        User user;
        private ObservableCollection<Category> _categoryList;
        public ObservableCollection<Category> CategoryList
        {
            get
            {
                return _categoryList;
            }
            set
            {
                _categoryList = value;
                OnPropertyChanged();
            }
        }

        public CategoryViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitCategory);
            RestaurantList = GetAllRestaurants();
        }

        public ObservableCollection<Restaurant> GetAllRestaurants()
        {
            restaurantlist = DBHelper.GetRestaurantList(new DBHelper(), user);
            var restaurentNames = from r in restaurantlist
                                  select r.rest_name;

            return (new ObservableCollection<Restaurant>(restaurantlist));
        }
        public void GetCategories(Restaurant restaurant)
        {
            try
            {
                CategoryList = DBHelper.GetCategoryList(new DBHelper(), _restaurant.rest_id);
            }
            catch (NotSupportedException nse)
            { }
        }
        private void SubmitCategory()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_foodcategory) && !string.IsNullOrWhiteSpace(SelectedRestaurant.rest_name))
                {
                    Category category = new Category() { rest_id = SelectedRestaurant.rest_id, cat_name = _foodcategory };
                    DBHelper.AddCategory(new DBHelper(), category);
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new OwnerView());
                }
            }
            catch (NullReferenceException n)
            { }
        }

        public string FoodCategory
        {
            get
            {
                return _foodcategory;
            }
            set
            {
                _foodcategory = value;
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

                GetCategories(_restaurant);
                OnPropertyChanged();
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
