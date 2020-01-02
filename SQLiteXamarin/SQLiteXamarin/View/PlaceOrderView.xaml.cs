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
    public partial class PlaceOrderView : ContentPage
    {
        public PlaceOrderView(Cart c)
        {
            InitializeComponent();
            this.BindingContext = new PlaceOrderViewModel(c);
        }
    }
}