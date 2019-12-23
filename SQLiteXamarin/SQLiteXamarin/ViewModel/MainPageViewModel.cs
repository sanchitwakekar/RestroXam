using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.ViewModel
{
    class MainPageViewModel
    {
        private string _username,_password,_role;
        public List<string> Role = new List<string>() { "Customer", "Owner" };

        public MainPageViewModel()
        {
           
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
}
