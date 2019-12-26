﻿using SQLiteXamarin.Model;
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
    public partial class RestaurantDetailView : ContentPage
    {
        public RestaurantDetailView(User user)
        {
            InitializeComponent();
            this.BindingContext = new RestaurantDetailViewModel(user);
        }
    }
}