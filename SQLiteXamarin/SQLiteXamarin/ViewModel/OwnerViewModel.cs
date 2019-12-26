﻿using SQLiteXamarin.Data;
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

        public Command _Restaurant, _Category, _Item, _UserSetting;
        DBHelper db;
        User user;

        public OwnerViewModel(User _user)
        {
            Restaurant = new Command(RestaurantDetails);
            Category = new Command(RestaurantDetails);
            Item = new Command(RestaurantDetails);
            UserSetting = new Command(RestaurantDetails);
            user = _user;
        }

        private void RestaurantDetails()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new View.Restaurant(user));
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
        public Command UserSetting
        {
            get
            {
                return _UserSetting;
            }
            set
            {
                _UserSetting = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
