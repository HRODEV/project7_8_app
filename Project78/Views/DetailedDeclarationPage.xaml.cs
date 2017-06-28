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
			this.BindingContext = new DeclartionViewModel(id);
			InitializeComponent();
		}

		private void OnSubmit(object sender, EventArgs e)
		{
			
		}
	}
}
