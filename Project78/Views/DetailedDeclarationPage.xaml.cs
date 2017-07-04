using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Project78.Models;


using Xamarin.Forms;
using System.Diagnostics;
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

        DatePicker datePicker = new DatePicker
        {
            Format = "ddMMyyyy",
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public DetailedDeclarationPage(Declaration declaration)
		{
            try
            {
                datePicker.Date = DateTime.Parse(declaration.Date);
            }
            catch
            {
                datePicker.Date = DateTime.Now;
            }

            ToolbarItems.Add(new ToolbarItem("Submit", null, async () =>
            {
                var answer = await DisplayAlert("", "Are you sure your declaration is finished?", "Yes", "No");
                if (answer)
                {
                    try
                    {
                        await APIService.Instance.PostRequestAsync(new StringContent(JsonConvert.SerializeObject(declaration), Encoding.UTF8, "application/json"), "/declarations");
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
