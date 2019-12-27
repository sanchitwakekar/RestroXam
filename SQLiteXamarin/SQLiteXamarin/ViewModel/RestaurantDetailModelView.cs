using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class RestaurantDetailModelView : INotifyPropertyChanged
    {
        private string _restaurantName, _restaurantArea;
        public Command _removeRestaurant, _updateRestaurant;
        Restaurant restaurant;
        public RestaurantDetailModelView(Restaurant _restaurant)
        {
            UpdateRestaurant = new Command(UpdateRestaurantDetails);
            RemoveRestaurant = new Command(DeleteRestaurantDetail);
            restaurant = _restaurant;
            _restaurantName = _restaurant.rest_name;
            _restaurantArea = _restaurant.area;
        }

        private void UpdateRestaurantDetails()
        {
            if (!string.IsNullOrWhiteSpace(_restaurantName) && !string.IsNullOrWhiteSpace(_restaurantArea))
            {
                DBHelper.UpdateRestaurant(new DBHelper(), restaurant);
            }
        }

        private void DeleteRestaurantDetail()
        {
            DBHelper.DeleteRestaurant(new DBHelper(), restaurant);
        }
        public string RestaurantArea
        {
            get
            {
                return _restaurantArea;
            }
            set
            {
                _restaurantArea = value;
            }
        }
        public string RestaurantName
        {
            get
            {
                return _restaurantName;
            }
            set
            {
                _restaurantName = value;
            }
        }

        public Command UpdateRestaurant
        {
            get
            {
                return _updateRestaurant;
            }
            set
            {
                _updateRestaurant = value;
            }
        }
        public Command RemoveRestaurant
        {
            get
            {
                return _removeRestaurant;
            }
            set
            {
                _removeRestaurant = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
