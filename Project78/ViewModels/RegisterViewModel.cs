using System.Text;
using Project78.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Project78.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Project78.Views;

namespace Project78.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        private User user;
        string spassword;
        public INavigation Navigation;

        public RegisterViewModel()
        {
            user = new User();
            CreateAccountCommand = new Command(CreateAccount);
        }

        async void CreateAccount()
        {
            if (User.Password == SecondPassword)
            {
                try
                {
                    HttpResponseMessage post = await APIService.Instance.PostRequestAsync(new StringContent(
                        JsonConvert.SerializeObject(new User(User.Email, User.FirstName, User.LastName, User.Password)), Encoding.UTF8, "application/json"), "/user");
                    if (post.IsSuccessStatusCode)
                    {
                        await App.Current.MainPage.DisplayAlert("", "Your account has been created", "Continue");
                        await Navigation.PushModalAsync(new NavigationPage(new StartUpPage()));
                    }
                    else
                    {
                        string message = await post.Content.ReadAsStringAsync();
                        await App.Current.MainPage.DisplayAlert("Failed to register", message, "OK");
                    }
                }

                catch
                {
                    await App.Current.MainPage.DisplayAlert("Oops!", "We are having issues, please try again later!", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Oops!", "Passwords do not match", "Ok");
            }      
        }

        //Not actually implemented
        private bool CheckFields()
        {
            if (User.FirstName != "" && User.LastName != "") 
                return true;
            return false;   
        }

        public ICommand CreateAccountCommand { get; protected set; }

        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public string SecondPassword
        {
            get => spassword;
            set => SetProperty(ref spassword, value);
        }

        //Not implemented Regular expression functions
        private string PasswordRegex(string password) => string.Empty;
        private string CheckIfPasswordsMatch(string password1, string password2) => string.Empty;
        private string FirstNameRegex(string firstname) => string.Empty;
        private string LastNameRegex(string lastname) => string.Empty;
        private string EmailRegex(string email) => string.Empty;
    }

    
}
