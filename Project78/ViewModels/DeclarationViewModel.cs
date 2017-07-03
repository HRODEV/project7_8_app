using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using Project78.Models;
using Project78.Services;
using System.IO;

namespace Project78.ViewModels
{
	public class DeclarationViewModel : ViewModelBase
	{
		private Declaration declaration;
		private Command updateCommand;
        private ImageSource imageSource;
		public INavigation Navigation;

		public DeclarationViewModel(int id)
		{
			declaration = new Declaration();
			GetData(id);
        }

		public DeclarationViewModel(Declaration declaration)
		{
			updateCommand = new Command(Post);
			this.declaration = declaration;
			this.declaration.Date = DateTime.Now.ToString();
            ImageSource = ImageSource.FromUri(new Uri($"http://37.139.12.76:8080/receipt/{declaration.ReceiptID}/image"));
        }

        private async void GetData(int id)
		{
			Declaration = await new APIService().GetDeclarationAsync(id);
            ImageSource = ImageSource.FromUri(new Uri($"http://37.139.12.76:8080/receipt/{Declaration.ReceiptID}/image"));
        }

		public Declaration Declaration
		{
            get => declaration;
            set => SetProperty(ref declaration, value);
		}

        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetProperty(ref imageSource, value);
        }

		public Command UpdateCommand { get { return updateCommand;} }

		private async void Post()
		{
            try
            {
                await new APIService().PostRequestAsync(new StringContent(JsonConvert.SerializeObject(Declaration), Encoding.UTF8, "application/json"), "/declarations");             
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops!", "We could not create your declaration, please try again!", "Ok");
            }
            await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
        }
	}
}
