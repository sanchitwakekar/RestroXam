using Newtonsoft.Json;
using SQLiteXamarin.Data;
using SQLiteXamarin.Model;
using SQLiteXamarin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteXamarin.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _username, _password, _role;
        public List<string> Role { get; set; }
        public Command _Login, _Register;
        DBHelper db;

        public MainPageViewModel()
        {
            Login = new Command(LoginUserAsync);
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
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new Register());
        }

        private async void LoginUserAsync()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_role))
                {
                    User user = new User() { username = _username, password = _password, role = _role };
                    User retrivedUser = DBHelper.GetUser(new DBHelper(), user);
                    if (!retrivedUser.Equals(null) && retrivedUser.role.Equals("Owner"))
                    {
                        var jsonValueToSave = JsonConvert.SerializeObject(retrivedUser);
                        Application.Current.Properties["CurrentUser"] = jsonValueToSave;
                        await Application.Current.SavePropertiesAsync();                      
                        Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new OwnerView());
                    }
                    if (!retrivedUser.Equals(null) && retrivedUser.role.Equals("Customer"))
                    {
                        var jsonValueToSave = JsonConvert.SerializeObject(retrivedUser);
                        Application.Current.Properties["CurrentUser"] = jsonValueToSave;
                        await Application.Current.SavePropertiesAsync();
                        Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CustomerMainView());
                    }
                }
            }
            catch (NullReferenceException n)
            {

            }
        }
        public static User GetCurrentUser()
        {
            var value = Application.Current.Properties["CurrentUser"];
            return JsonConvert.DeserializeObject<User>(Convert.ToString(value));            
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
