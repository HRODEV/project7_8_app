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
            NavigateToDeclarations = new Command(Login, () => !IsBusy);
        }

        async void Login()
        {
            //IsBusy = true;
            try
            {
                var authCall = await APIService.Instance.RequestAuthentication(Email, Password);

                if (authCall == true)
                    await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
                        
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops!", "We are having issues, please try again later!", "Ok");
            }
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
