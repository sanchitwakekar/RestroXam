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
        public Command Login, Register;

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
            throw new NotImplementedException();
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
