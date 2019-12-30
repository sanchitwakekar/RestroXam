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
        private Command<object> _ModifyRestaurant;
        User user;
        private ObservableCollection<Restaurant> _RestaurantList;
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
        public RestaurentViewModel()
        {
            user = MainPageViewModel.GetCurrentUser(); ;
            AddRestaurant = new Command(AddRestaurantPage);
            ModifyRestaurant = new Command<object>(ModifyRestaurantPage);
            RestaurantList = DBHelper.GetRestaurantList(new DBHelper(), user);
        }

        private void AddRestaurantPage()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new AddRestaurantView());
        }
        private void ModifyRestaurantPage(object obj)
        {           
            var itemData = obj as Restaurant;                          
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new RestaurantDetailView(itemData));
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
        public Command<object> ModifyRestaurant
        {
            get
            {
                return _ModifyRestaurant;
            }
            set
            {
                _ModifyRestaurant = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
