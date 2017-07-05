using System;
using Xamarin.Forms;
using Project78.Models;
using Project78.Services;
using System.Globalization;

namespace Project78.ViewModels
{
	public class DeclarationViewModel : ViewModelBase
	{
		private Declaration declaration;
        private ImageSource imageSource;
		public INavigation Navigation;
        private string totalPrice = "0";
        private string vatPrice = "0";

		public DeclarationViewModel(int id)
		{
			declaration = new Declaration();
			GetData(id);
        }

		public DeclarationViewModel(Declaration declaration)
		{
			this.declaration = declaration;
            VatPrice = declaration.VATPrice.ToString();
            TotalPrice = declaration.TotalPrice.ToString();
            ImageSource = new UriImageSource { CachingEnabled = false, Uri = APIService.Instance.GetImageUri(declaration.ReceiptID) };
        }

        private async void GetData(int id)
		{
			Declaration = await APIService.Instance.GetDeclarationAsync(id);
            ImageSource = new UriImageSource { CachingEnabled = false, Uri = APIService.Instance.GetImageUri(Declaration.ReceiptID) };
        }

        public string TotalPrice
        {
            get => totalPrice;
            set
            {
                if (value.Contains(","))
                    value = value.Replace(",", ".");
                SetProperty(ref totalPrice, value);
                if (float.TryParse(value, out float result))
                {
                    Declaration.TotalPrice = float.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
        }

        public string VatPrice
        {
            get => vatPrice;
            set
            {
                if (value.Contains(","))
                    value = value.Replace(",", ".");
                SetProperty(ref vatPrice, value);
                if (float.TryParse(value, out float result))
                {
                    Declaration.VATPrice = float.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
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
	}
}
