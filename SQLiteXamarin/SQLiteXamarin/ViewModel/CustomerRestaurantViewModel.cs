using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SQLiteXamarin.ViewModel
{
    class CustomerRestaurantViewModel
    {
        private int _onStepperValueChanged;
        private ObservableCollection<Item> _itemList;
        public CustomerRestaurantViewModel(Restaurant _CustomerRestaurant)
        {
            _itemList = DBHelper.GetUserRestaurantItemList(new DBHelper(),_CustomerRestaurant.rest_id);
        }
        public ObservableCollection<Item> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                _itemList = value;
            }
        }
        public int OnStepperValueChanged
        {
            get
            {
                return _onStepperValueChanged;
            }
            set
            {
                _onStepperValueChanged = value;
            }
        }
    }
}
