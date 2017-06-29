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

        public DetailedDeclarationPage(Declaration declaration)
		{
            ToolbarItems.Add(new ToolbarItem("Delete", null, async () =>
            {
                var answer = await DisplayAlert("", "Do you want to delete this declaration?", "Yes", "No");
                Debug.WriteLine("Answer: " + answer);

                if (answer) //if the user clicks on yes
                {
                    var response = new APIService().DeleteRequest(declaration.ID, "/declarations/");
                    await Navigation.PushModalAsync(new Project78Page());
                }
            }));

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
