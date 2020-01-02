using SQLiteXamarin.Model;
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
    public partial class OwnerView : ContentPage
    {
        public OwnerView()
        {
            InitializeComponent();
            this.BindingContext = new OwnerViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}