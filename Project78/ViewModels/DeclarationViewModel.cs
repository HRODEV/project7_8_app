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
        private string totalPrice, vatPrice;

		public DeclarationViewModel(int id)
		{
			declaration = new Declaration();
			GetData(id);
        }

		public DeclarationViewModel(Declaration declaration)
		{
			this.declaration = declaration;
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
                if (TotalPrice.Contains(","))
                    TotalPrice.Replace(",", ".");
                SetProperty(ref totalPrice, value);
                Declaration.TotalPrice = float.Parse(TotalPrice);
            }
        }

        public string VatPrice
        {
            get => vatPrice;
            set
            {
                if (VatPrice.Contains(","))
                    VatPrice.Replace(",", ".");
                SetProperty(ref vatPrice, value);
                Declaration.VATPrice = float.Parse(VatPrice);
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
