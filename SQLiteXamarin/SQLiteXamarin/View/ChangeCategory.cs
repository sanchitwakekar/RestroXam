using SQLiteXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.View
{
    class ChangeCategory : TriggerAction<Picker>
    {
        protected override void Invoke(Picker sender)
        {
            CategoryViewModel cvm = new CategoryViewModel();
        }
    }
}
