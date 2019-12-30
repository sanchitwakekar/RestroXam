using SQLiteXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.View
{
    class LoadCategory : TriggerAction<Picker>
    {
        protected override void Invoke(Picker sender)
        {
            ItemViewModel ivm = new ItemViewModel();
            ivm.getCategory(sender.SelectedItem.ToString());
        }
    }
}
