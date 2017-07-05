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

        public LoginViewModel()
        {
            NavigateToDeclarations = new Command(Login);
        }

        async void Login()
        {
            try
            {
                var authCall = await APIService.Instance.RequestAuthenticationToken(Email, Password);

                if (authCall == true)
                    await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));                    
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops!", "We are having issues, please try again later!", "Ok");
            } 
        }

        public Command NavigateToDeclarations { get; protected set; }

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
