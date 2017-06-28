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
    class LoginViewModel
    {
        public INavigation Navigation;

        public LoginViewModel()
        {
            NavigateToDeclarations = new Command(() =>
            {
                Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
            });
        }

        public ICommand NavigateToDeclarations { get; protected set; }
    }
}
