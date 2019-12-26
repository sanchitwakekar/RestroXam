using SQLiteXamarin.Data;
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

        public OwnerViewModel()
        {
            Restaurant = new Command(RestaurantDetails);
            Category = new Command(RestaurantDetails);
            Item = new Command(RestaurantDetails);
            UserSetting = new Command(RestaurantDetails);

        }
        

        private void RestaurantDetails()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Restaurant());
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
