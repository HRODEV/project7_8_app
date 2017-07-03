using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using Project78.Models;
using Project78.Services;
using System.IO;
using System.Drawing;
using Android.Graphics;

namespace Project78.ViewModels
{
	public class DeclarationViewModel : ViewModelBase
	{
		private Declaration declaration;
		private Command updateCommand;
        private Image image;
		public INavigation Navigation;
        private byte[] imageByteArray;

		public DeclarationViewModel(int id)
		{
			updateCommand = new Command(Patch);
			declaration = new Declaration();
			GetData(id);
            GetImage(id);
		}

		public DeclarationViewModel(Declaration declaration)
		{
			updateCommand = new Command(Post);
			this.declaration = declaration;
			this.declaration.Date = DateTime.Now.ToString();
		}

        private async void GetImage(int id)
        {
            ImageByteArray = await new APIService().GetImageAsync(id);
        }

        private async void GetData(int id)
		{
			Declaration = await new APIService().GetDeclarationAsync(id);
		}

        public byte[] ImageByteArray
        {
            get => imageByteArray;
            set 
            {
                SetProperty(ref imageByteArray, value);
                Debug.WriteLine(value.Length);
                Image.Source = ImageSource.FromStream(() => new MemoryStream(value));
            }
        }

        public Image Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

		public Declaration Declaration
		{
            get => declaration;
            set => SetProperty(ref declaration, value);
		}

		public Command UpdateCommand { get { return updateCommand;} }

		private async void Patch()
		{
            var content = await (await new APIService()
                .PatchRequestAsync(new StringContent(JsonConvert.SerializeObject(Declaration), Encoding.UTF8, "application/json"), "/declarations/" + declaration.ID.ToString()))
                .Content.ReadAsStringAsync();

            Debug.WriteLine(content);
			await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
		}

		private async void Post()
		{
            await new APIService().PostRequestAsync(new StringContent(JsonConvert.SerializeObject(Declaration), Encoding.UTF8, "application/json"), "/declarations");
			await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));			                
		}
	}
}
