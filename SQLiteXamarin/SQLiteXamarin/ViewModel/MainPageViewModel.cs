using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using SQLiteXamarin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private string _username, _password, _role;
        public List<string> Role { get; set; }
        public Command _Login, _Register;
        DBHelper db;

        public MainPageViewModel()
        {
            Login = new Command(LoginUser);
            Register = new Command(RegisterUser);
            Role = GetRole();
        }
        private List<string> GetRole()
        {
            var _role = new List<string>()
            {
                "Customer",
                "Owner",
            };
            return _role;
        }

        private void RegisterUser()
        {
            throw new NotImplementedException();
        }

        private void LoginUser()
        {
            if (_username.Equals("admin") && _password.Equals("admin") && _role.Equals("Owner"))
            {
                db = new DBHelper();
                User user =new User() { username = _username, password = _password, role = _role };
                DBHelper.GetUser(db, user);
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new OwnerView());
            }
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
        public string SelectedRole
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
        public Command Register
        {
            get
            {
                return _Register;
            }
            set
            {
                _Register = value;
            }
        }
        public Command Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
