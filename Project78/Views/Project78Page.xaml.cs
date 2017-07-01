using Xamarin.Forms;
using Project78.Services;
using Project78.Views;
using Project78.Models;
using System.Net.Http;
using System;
using System.IO;
using System.Diagnostics;
using Project78.ViewModels;
using System.Threading.Tasks;

namespace Project78
{
	public partial class Project78Page : ContentPage
	{
        private readonly INavigationService _navigationService = new Navigator();
        private Image PhotoImage;
        private readonly DeclarationsViewModel viewModel;

        public Project78Page()
		{
			PhotoImage = new Image();
			BindingContext = viewModel = new DeclarationsViewModel();
			InitializeComponent();
			Title = "Declarations";

			ToolbarItems.Add(new ToolbarItem("Add", null, async () =>
			{
				var wait = new WaitPage();

				var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
                if (photo != null)
                {
					await Navigation.PushAsync(wait);
                    PhotoImage.Source = ImageSource.FromStream(() => photo.GetStream());
                    var response = await new APIService().PostImageAsync(new ByteArrayContent(await StreamToByteArrayAsync(photo.GetStream())), GenerateFileName());
                    await Navigation.PushAsync(new DetailedDeclarationPage(response));
					Navigation.RemovePage(wait);
					photo.Dispose();
                }
            }));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDataCommand.Execute(null);
        }

        private string GenerateFileName()
        {
            Random rnd = new Random();
            //should be done serverside
			return rnd.Next(10000000, 99999999).ToString() + ".jpg";
        }

        private async Task<byte[]> StreamToByteArrayAsync(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        async void OnItemSelected(object sender, ItemTappedEventArgs e)
		{
            Declaration item = (sender as ListView)?.SelectedItem as Declaration;
            await Navigation.PushAsync(new EneditableDeclarationPage(item));
		}
	}
}
