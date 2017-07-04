using Xamarin.Forms;
using Project78.Services;
using Project78.Views;

namespace Project78
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
            //MainPage = new NavigationPage(new Project78Page());
            APIService _apiSeer = new APIService();
            MainPage = new NavigationPage(new StartUpPage());
        }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
