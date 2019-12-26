using SQLiteXamarin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class AddRestaurentViewModel : INotifyPropertyChanged
    {
        private string _restaurantName, _restaurantArea;
        public Command _addRestaurantDetails;
        public AddRestaurentViewModel()
        {
            AddRestaurantDetails = new Command(AddRestaurant);

        }

        private void AddRestaurant()
        {
            if (!string.IsNullOrWhiteSpace(_restaurantName) && !string.IsNullOrWhiteSpace(_restaurantArea))
            {
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Restaurant());
            }
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

        public Command AddRestaurantDetails
        {
            get
            {
                return _addRestaurantDetails;
            }
            set
            {
                _addRestaurantDetails = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
