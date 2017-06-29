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

        Action<string> action = (lol) => Debug.WriteLine(lol);

        public RegisterViewModel()
        {
            _navigator = new Navigator();
            CreateAccountCommand = new Command(() =>
            {
                var jsonUser = JsonConvert.SerializeObject(new User(Email, FirstName, LastName, FirstPassword));
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");           
                HttpResponseMessage post = _api.PostRequest(content, "/user");

                if (post.IsSuccessStatusCode)
                    Navigation.PushModalAsync(new NavigationPage(new StartUpPage()));
            });
        }

        public ICommand CreateAccountCommand { get; protected set; } //TO DO: create the command in the constructor

        public string FirstPassword
        {
            get { return fpassword; }
            set
            {
                if (fpassword != value)
                {
                    fpassword = value;
                    OnPropertyChanged("FirstPassword");
                }
            }
        }

        public string SecondPassword
        {
            get { return spassword; }
            set
            {
                if (spassword != value)
                {
                    spassword = value;
                    OnPropertyChanged("SecondPassword");
                }
            }
        }

        public string FirstName
        {
            get { return fname; }
            set
            {
                if (fname != value)
                {
                    fname = value;
                    OnPropertyChanged("FirstName");
                }            
            }
        }

        public string LastName
        {
            get { return lname; }
            set
            {
                if (lname != value)
                {
                    lname = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

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

        private readonly INavigationService _navigator;

        private string PasswordRegex(string password)
        {
            return "";
        }

        private string CheckIfPasswordsMatch(string password1, string password2)
        {
            return "";
        }

        private string FirstNameRegex(string firstname)
        {
            return "";
        }

        private string LastNameRegex(string lastname)
        {
            return "";
        }

        private string EmailRegex(string email)
        {
            return "";
        }

    }

    
}
