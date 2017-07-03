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
using Plugin.ImageResizer;

namespace Project78
{
	public partial class Project78Page : ContentPage
	{
        private readonly INavigationService _navigationService = new Navigator();
        private Image PhotoImage;
        private readonly DeclarationsViewModel viewModel;

        public Project78Page()
		{
			BindingContext = viewModel = new DeclarationsViewModel();
			InitializeComponent();
			Title = "Declarations";

			ToolbarItems.Add(new ToolbarItem("Add", null, async () =>
			{
				var wait = new WaitPage();

				var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { CompressionQuality = 70, PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium});
                if (photo != null)
                {
					await Navigation.PushAsync(wait);
                    var resizedImage = await CrossImageResizer.Current.ResizeImageWithAspectRatioAsync(await StreamToByteArrayAsync(photo.GetStream()), 1080, 1920);
                    try
                    {
                        var response = await new APIService().PostImageAsync(new ByteArrayContent(resizedImage), GenerateFileName());
                        await Navigation.PushAsync(new DetailedDeclarationPage(response));
                    }
                    catch
                    {
                        await DisplayAlert("Oops!", "We have encountered a problem!", "I get it");
                    }
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
