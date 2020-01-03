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
        public Command _Logout, _Orders;
        private ObservableCollection<Restaurant> _RestaurantList;
        public CustomerMainViewModel()
        {
            RestaurantList = DBHelper.GetCustomerRestaurantList(new DBHelper());
            EnterRestaurant = new Command<object>(EnterRestaurantPage);
            Logout = new Command(UserLogout);
            Orders = new Command(UserOrders);
        }
        private void EnterRestaurantPage(object obj)
        {
            var itemData = obj as Restaurant;
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CustomerResturantView(itemData));
        }

        private void UserLogout()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
        }

        private void UserOrders()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new OrderSummaryView());
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

        public Command Logout
        {
            get
            {
                return _Logout;
            }
            set
            {
                _Logout = value;
            }
        }

        public Command Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
