using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Project78.Models;


using Xamarin.Forms;


namespace Project78.Views
{

	public partial class DetailedDeclarationPage : ContentPage
	{
		private DeclarationViewModel vm;

		public DetailedDeclarationPage(Declaration declaration)
		{
			if (declaration.ID != 0)
			{
				vm = new DeclarationViewModel(declaration.ID);
				this.BindingContext = vm;
			}
			else 
			{
				vm = new DeclarationViewModel(declaration);
				this.BindingContext = vm;
			}
			vm.Navigation = Navigation;
			InitializeComponent();
		}
	}
}
