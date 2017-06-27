using Xamarin.Forms;
using Project78.Services;

namespace Project78
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
            MainPage = new NavigationPage(new Project78Page());
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
