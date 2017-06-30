using Xamarin.Forms;
using Project78.Services;
using Project78.Views;
using Project78.Models;
using System.Net.Http;
using System;
using System.IO;
using System.Diagnostics;

namespace Project78
{
	public partial class Project78Page : ContentPage
	{
        private readonly INavigationService _navigationService = new Navigator();
        private Image PhotoImage;

        public Project78Page()
		{
			PhotoImage = new Image();
			this.BindingContext = new DeclarationsViewModel();
			InitializeComponent();
			Title = "Declarations";

			ToolbarItems.Add(new ToolbarItem("Add", null, async () =>
			{
				var wait = new WaitPage();
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
                if (photo != null)
                {
					await Navigation.PushAsync(wait);
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                    var response = new APIService().PostImage(new ByteArrayContent(StreamToByteArray(photo.GetStream())), GenerateFileName());
                    await Navigation.PushAsync(new DetailedDeclarationPage(response));
					Navigation.RemovePage(wait);
                }
            }));
        }

        private string GenerateFileName()
        {
            Random rnd = new Random();
			return rnd.Next(10000000, 99999999).ToString() + ".jpg";
        }

        private byte[] StreamToByteArray(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        async void OnItemSelected(object sender, ItemTappedEventArgs e)
		{
			ListView lv = (ListView)sender;
			Declaration item = (Declaration)lv.SelectedItem;
			await Navigation.PushAsync(new EneditableDeclarationPage(item));
		}
	}
}
