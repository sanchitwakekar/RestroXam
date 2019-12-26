using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using SQLiteXamarin.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class RestaurentViewModel : INotifyPropertyChanged
    {

        public Command _AddRestaurant;
        User user;
        private ObservableCollection<Model.Restaurant> _RestaurantList;
        public ObservableCollection<Model.Restaurant> RestaurantList
        {
            get
            {
                return _RestaurantList;
            }
            set
            {
                _RestaurantList = value;
                OnPropertyChanged();
            }
        }
        public RestaurentViewModel(User _user)
        {
            user = _user;
            AddRestaurant = new Command(AddRestaurantPage);
            RestaurantList = DBHelper.GetRestaurantList(new DBHelper(), _user);
        }

        private void AddRestaurantPage()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new AddRestaurantView(user));
        }

        public Command AddRestaurant
        {
            get
            {
                return _AddRestaurant;
            }
            set
            {
                _AddRestaurant = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
