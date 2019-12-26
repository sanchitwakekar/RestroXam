<<<<<<< HEAD
using SQLiteXamarin.Model;
using SQLiteXamarin.ViewModel;
=======
﻿using SQLiteXamarin.Model;
>>>>>>> a5889fc49609c89d433758fb97e8e94494eefe84
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
    public partial class OwnerView : ContentPage
    {
        public OwnerView(User user)
        {
            InitializeComponent();
            this.BindingContext = new OwnerViewModel(user);
        }
    }
}