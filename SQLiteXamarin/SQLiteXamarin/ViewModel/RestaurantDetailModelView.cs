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
        User user;
        public RestaurantDetailModelView(User _user)
        {
            UpdateRestaurant = new Command(UpdateRestaurantDetails);
            RemoveRestaurant = new Command(UpdateRestaurantDetail);
            user = _user;
        }

        private void UpdateRestaurantDetails()
        {
           
        }

        private void UpdateRestaurantDetail()
        {
           
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
