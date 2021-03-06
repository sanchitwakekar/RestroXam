﻿using SQLiteXamarin.Model;
using SQLiteXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerResturantView : ContentPage
    {
        public CustomerResturantView(Restaurant restaurant)
        {
            InitializeComponent();
            this.BindingContext = new CustomerRestaurantViewModel(restaurant);
        }
    }
}