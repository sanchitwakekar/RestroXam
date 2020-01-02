using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using SQLiteXamarin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class OwnerViewModel : INotifyPropertyChanged
    {

        public Command _Restaurant, _Category, _Item, _Logout;
        User user;

        public OwnerViewModel()
        {
            Restaurant = new Command(RestaurantDetails);
            Category = new Command(CategoryDetails);
            Item = new Command(ItemDetails);
            Logout = new Command(UserLogout);
            user = MainPageViewModel.GetCurrentUser(); ;
        }

        private void RestaurantDetails()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new RestaurantView());
        }

        private void CategoryDetails()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CategoryView());
        }

        private void ItemDetails()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ItemView());
        }

        private void UserLogout()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
        }

        public Command Restaurant
        {
            get
            {
                return _Restaurant;
            }
            set
            {
                _Restaurant = value;
            }
        }

        public Command Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        public Command Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
