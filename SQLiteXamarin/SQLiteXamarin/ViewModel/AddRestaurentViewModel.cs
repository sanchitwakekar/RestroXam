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
    class AddRestaurentViewModel : INotifyPropertyChanged
    {
        private string _restaurantName, _restaurantArea;
        public Command _addRestaurantDetails;
        User user;
        public AddRestaurentViewModel()
        {
            AddRestaurantDetails = new Command(AddRestaurant);
            user = MainPageViewModel.GetCurrentUser();
        }

        private void AddRestaurant()
        {
            if (!string.IsNullOrWhiteSpace(_restaurantName) && !string.IsNullOrWhiteSpace(_restaurantArea))
            {
              Restaurant rest = new Restaurant() {
                    rest_name = _restaurantName,
                    area = _restaurantArea,
                    lat = 21.132545,
                    lang = 79.078413,
                    owner_id=user.user_id,
                };
                DBHelper.AddRestaurant(new DBHelper(), rest);
                Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
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
