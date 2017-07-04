using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Project78.Models;
using Xamarin.Forms;
using Project78.ViewModels;
using Project78.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Project78.Views
{

	public partial class DetailedDeclarationPage : ContentPage
	{
		private DeclarationViewModel vm;
        private APIService _api = new APIService();

        DatePicker datePicker = new DatePicker
        {
            Format = "D",
            VerticalOptions = LayoutOptions.CenterAndExpand
        };



        public DetailedDeclarationPage(Declaration declaration)
		{
            ToolbarItems.Add(new ToolbarItem("Submit", null, async () =>
            {
                var answer = await DisplayAlert("", "Are you sure your declaration is finished?", "Yes", "No");
                if (answer)
                {
                    try
                    {
                        await new APIService().PostRequestAsync(new StringContent(JsonConvert.SerializeObject(declaration), Encoding.UTF8, "application/json"), "/declarations");
                    }
                    catch
                    {
                        await App.Current.MainPage.DisplayAlert("Oops!", "We could not create your declaration, please try again!", "Ok");
                    }
                    await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
                }
            }));

            vm = new DeclarationViewModel(declaration);
			this.BindingContext = vm;
			vm.Navigation = Navigation;
			InitializeComponent();
		}
	}
}
