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
    class CategoryViewModel : INotifyPropertyChanged
    {
        private string _foodcategory;
        private Restaurant _restaurant;
        public ObservableCollection<string> RestaurantList { get; set; }
        public Command _submit;
        DBHelper db;
        User user;

        public CategoryViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitCategory);
            RestaurantList = GetAllRestaurants();
           
        }
        public ObservableCollection<string> GetAllRestaurants()
        {
            var restaurantlist = DBHelper.GetRestaurantList(new DBHelper(), user);
            var restaurentNames = from r in restaurantlist
                                  select r.rest_name;

           return (new ObservableCollection<string>(restaurentNames.ToList()));
        }

        private void SubmitCategory()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_foodcategory) && !string.IsNullOrWhiteSpace(_restaurant.rest_name))
                {
                    Category category = new Category() { rest_id = SelectedRestaurant.rest_id, cat_name = _foodcategory };
                    DBHelper.AddCategory(new DBHelper(), category);
                    //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new CategoryView(retrivedUser));
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
