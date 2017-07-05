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
        private ICommand SubmitDeclaration { get; set; }

        public DetailedDeclarationPage(Declaration declaration)
		{
            ToolbarItems.Add(new ToolbarItem("Submit", null, onSubmit));
        
            vm = new DeclarationViewModel(declaration);
			this.BindingContext = vm;
			vm.Navigation = Navigation;
			InitializeComponent();
		}

        private async void onSubmit()
        {
            if (CheckFields())
            {
                bool answer = await DisplayAlert("", "Are you sure your declaration is finished?", "Yes", "No");
                if (answer)
                {
                    try
                    {
                        await APIService.Instance.PostRequestAsync(new StringContent(
                            JsonConvert.SerializeObject(vm.Declaration), Encoding.UTF8, "application/json"), "/declarations");
                    }
                    catch
                    {
                        await App.Current.MainPage.DisplayAlert("Oops!", "We could not create your declaration, please try again!", "Ok");
                    }
                    await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
                }
            }
            else
                await DisplayAlert("Empty field", "No empty field allowed", "Ok");            
        }

        private bool CheckFields()
        {
            int count = 0;
            if (Double.TryParse(Total.Text, out double total))
                if (Double.Parse(Total.Text) != 0)
                    count++;

            if (Double.TryParse(Vat.Text, out double vat))
                if (Double.Parse(Vat.Text) != 0)
                    count++;

            if (Title.Text != "" && Description.Text != "")
                count++;

            if (count == 3)
                return true;
            return false;
        }

    }
}
