using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace Project78.Views
{
	public partial class CameraPage : ContentPage
	{


		public CameraPage()
		{
			InitializeComponent();
			CameraButton.Clicked += CameraButton_Clicked;
		}

		private string GenerateFileName() 
		{
			Random rnd = new Random();
			return rnd.Next(1000000000).ToString() + ".jpg";
		}

        private byte[] StreamToByteArray(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
		{
			var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
				string filename = GenerateFileName();
                Declaration response = new APIService().PostImage(new ByteArrayContent(StreamToByteArray(photo.GetStream())), filename);
				await Navigation.PushAsync(new DetailedDeclarationPage(response.ID));
            }
		}
	}
}
