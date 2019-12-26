using SQLiteXamarin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class RestaurentViewModel : INotifyPropertyChanged
    {
       
        public Command _AddRestaurant;


        public RestaurentViewModel()
        {
            AddRestaurant = new Command(AddRestaurantPage);

        }

        private void AddRestaurantPage()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new AddRestaurantView());
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
