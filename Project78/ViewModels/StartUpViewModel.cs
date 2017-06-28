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
    class StartUpViewModel
    {
        public INavigation Navigation;

        public StartUpViewModel()
        {
            NavigateToLogin = new Command(() => Navigation.PushAsync(new LoginPage()));
            NavigateToRegister = new Command(() => Navigation.PushAsync(new RegisterPage()));
        }

        public ICommand NavigateToLogin { get; protected set; }
        public ICommand NavigateToRegister { get; protected set; }




    }
}
