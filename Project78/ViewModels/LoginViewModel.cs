using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Project78.Views;
using System.Diagnostics;
using Project78.Services;

namespace Project78.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        string email, password;
        bool isBusy = false;
        public INavigation Navigation;
        APIService _api = new APIService();

        public LoginViewModel()
        {
            NavigateToDeclarations = new Command(NavigateDeclarations, () => !IsBusy);
        }

        void NavigateDeclarations()
        {
            //IsBusy = true;
            var authData = string.Format("{0}:{1}", Email, Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            var authCall = _api.GetAuthenticateUser(authHeaderValue);

            if (authCall != null)
                Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
            //IsBusy = false;
        }

        public Command NavigateToDeclarations { get; protected set; }

        public bool IsBusy
        {
            get { return isBusy; }
            // Why always set to FALSE??
            set
            {
                isBusy = false;
                //isBusy = value;
                //OnPropertyChanged("IsBusy");
                //NavigateToDeclarations.ChangeCanExecute();
            }
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
