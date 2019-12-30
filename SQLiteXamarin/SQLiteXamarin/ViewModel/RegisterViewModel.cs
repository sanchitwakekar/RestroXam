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
    class RegisterViewModel : INotifyPropertyChanged
    {
        private string _username, _password, _confirmPassword, _role;
        public List<string> Role { get; set; }
        public Command _Register;
        DBHelper db;

        public RegisterViewModel()
        {
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
            if (!string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_role) && _password.Equals(_confirmPassword))
            {
                db = new DBHelper();
                User user = new User() { username = _username, password = _password, role = _role };
                DBHelper.AddUser(db, user);
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
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


        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
