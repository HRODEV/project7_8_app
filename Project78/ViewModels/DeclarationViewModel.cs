using System;
using Xamarin.Forms;
using Project78.Models;
using Project78.Services;

namespace Project78.ViewModels
{
	public class DeclarationViewModel : ViewModelBase
	{
		private Declaration declaration;
        private ImageSource imageSource;
		public INavigation Navigation;

		public DeclarationViewModel(int id)
		{
			declaration = new Declaration();
			GetData(id);
        }

		public DeclarationViewModel(Declaration declaration)
		{
			this.declaration = declaration;
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
	}
}
