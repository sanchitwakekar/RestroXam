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
    class CustomerMainViewModel : INotifyPropertyChanged
    {
        private Command<object> _EnterRestaurant;
        private ObservableCollection<Restaurant> _RestaurantList;
        public CustomerMainViewModel()
        {
            RestaurantList = DBHelper.GetCustomerRestaurantList(new DBHelper());
            EnterRestaurant = new Command<object>(EnterRestaurantPage);
        }
        private void EnterRestaurantPage(object obj)
        {
            var itemData = obj as Restaurant;
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CustomerResturantView(itemData));
        }
        public ObservableCollection<Restaurant> RestaurantList
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
        public Command<object> EnterRestaurant
        {
            get
            {
                return _EnterRestaurant;
            }
            set
            {
                _EnterRestaurant = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
