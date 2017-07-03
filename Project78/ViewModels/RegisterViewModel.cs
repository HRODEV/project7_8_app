using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project78.Services;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using Project78.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using Project78.Views;

namespace Project78.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        string fpassword, spassword, fname, lname, email;
        APIService _api = new APIService();
        public INavigation Navigation;

        public RegisterViewModel()
        {
            _navigator = new Navigator();
            CreateAccountCommand = new Command(async () =>
            {
                try
                {
                    var jsonUser = JsonConvert.SerializeObject(new User(Email, FirstName, LastName, FirstPassword));
                    var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                    HttpResponseMessage post = await _api.PostRequestAsync(content, "/user");

                    if (post.IsSuccessStatusCode)
                        await Navigation.PushModalAsync(new NavigationPage(new StartUpPage()));
                }
                catch
                {
                    await App.Current.MainPage.DisplayAlert("Oops!", "We are having issues, please try again later!", "Ok");
                }
            });
        }

        public ICommand CreateAccountCommand { get; protected set; }

        public string FirstPassword
        {
            get => fpassword;
            set => SetProperty(ref fpassword, value);
        }

        public string SecondPassword
        {
            get => spassword;
            set => SetProperty(ref spassword, value);
        }

        public string FirstName
        {
            get => fname;
            set => SetProperty(ref fname, value);
        }

        public string LastName
        {
            get => lname;
            set => SetProperty(ref lname, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private readonly INavigationService _navigator;

        private string PasswordRegex(string password) => string.Empty;
        private string CheckIfPasswordsMatch(string password1, string password2) => string.Empty;
        private string FirstNameRegex(string firstname) => string.Empty;
        private string LastNameRegex(string lastname) => string.Empty;
        private string EmailRegex(string email) => string.Empty;
    }

    
}
