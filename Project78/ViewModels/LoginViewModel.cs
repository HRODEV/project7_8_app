using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Project78.Views;

namespace Project78.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        string email, password;
        public INavigation Navigation;
        APIService _api = new APIService();

        public LoginViewModel()
        {
            NavigateToDeclarations = new Command(() =>
            {
                var authData = string.Format("{0}:{1}", Email, Password);
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                var authCall = _api.getAuthenticateUser(authHeaderValue);
                
                if (authCall != null)
                    Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
            });
        }

        public ICommand NavigateToDeclarations { get; protected set; }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
    }
}
