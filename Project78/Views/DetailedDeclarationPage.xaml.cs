using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;


using Xamarin.Forms;


namespace Project78.Views
{

	public partial class DetailedDeclarationPage : ContentPage
	{
		
		public DetailedDeclarationPage(int id)
		{
			var vm = new DeclarationViewModel(id);
            this.BindingContext = vm;
            
			InitializeComponent();
		}
	}
}
