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
        public ObservableCollection<string> RestaurantList { get; set; }
        private ObservableCollection<Category> _categoryList { get; set; }
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

        ObservableCollection<Restaurant> restaurantlist;
        public Command _submit;
        User user;

        public CategoryViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitCategory);
            //RestaurantList = new ObservableCollection<string>();
            RestaurantList = GetAllRestaurants();                              
        }
        public void updateConditions(string rest)
        {
            SelectedRestaurant = restaurantlist.Where(st => st.rest_name.Equals(rest)).FirstOrDefault();
                                  
            _categoryList = GetCategories(SelectedRestaurant);           
        }
        public ObservableCollection<string> GetAllRestaurants()
        {
            restaurantlist = DBHelper.GetRestaurantList(new DBHelper(), user);
            var restaurentNames = from r in restaurantlist
                                  select r.rest_name;

            return (new ObservableCollection<string>(restaurentNames.ToList()));
        }
        public ObservableCollection<Category> GetCategories(Restaurant restaurant)
        {
            try
            {                
                
                                    

           //     return (new ObservableCollection<string>(categoryNames.ToList()));
                return null;
            }
            catch (NotSupportedException nse)
            {
                return new ObservableCollection<Category>();
            }

        }

        private void SubmitCategory()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_foodcategory) && !string.IsNullOrWhiteSpace(_restaurant.rest_name))
                {
                    Category category = new Category() { rest_id = SelectedRestaurant.rest_id, cat_name = _foodcategory };
                    DBHelper.AddCategory(new DBHelper(), category);
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new OwnerView());
                }
            }
            catch (NullReferenceException n)
            {

            }
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
