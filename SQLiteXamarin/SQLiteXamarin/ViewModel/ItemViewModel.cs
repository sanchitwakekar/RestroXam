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
        private string _foodcategory;
        private Restaurant _restaurant;
        public ObservableCollection<Restaurant> RestaurantList { get; set; }
        public Command _submit;
      
        User user;

        public ItemViewModel()
        {
            user = MainPageViewModel.GetCurrentUser();
            Submit = new Command(SubmitCategory);
            RestaurantList = GetAllRestaurants();
        }
        public ObservableCollection<Restaurant> GetAllRestaurants()
        {
            return null;
        }

        private void SubmitCategory()
        {
           
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
