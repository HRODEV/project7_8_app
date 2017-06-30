using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Project78.Models;


using Xamarin.Forms;
using System.Diagnostics;

namespace Project78.Views
{

	public partial class DetailedDeclarationPage : ContentPage
	{
		private DeclarationViewModel vm;

        DatePicker datePicker = new DatePicker
        {
            Format = "D",
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public DetailedDeclarationPage(Declaration declaration)
		{
			vm = new DeclarationViewModel(declaration);
			this.BindingContext = vm;
			vm.Navigation = Navigation;
			//Image.Source = new APIService().GetImage(declaration.ReceiptID).Source;
			InitializeComponent();
		}
	}
}
