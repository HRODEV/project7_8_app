using System.Linq;
using Project78.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project78.ViewModels;
using Project78.Services;

namespace Project78.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EneditableDeclarationPage : ContentPage
    {
        DeclarationViewModel vm;

        public EneditableDeclarationPage(Declaration declaration)
        {
            ToolbarItems.Add(new ToolbarItem("Delete", null, onDelete));

            vm = new DeclarationViewModel(declaration.ID);
            this.BindingContext = vm;

            vm.Navigation = Navigation;
            InitializeComponent();
        }

        private async void onDelete()
        {
            var answer = await DisplayAlert("", "Do you want to delete this declaration?", "Yes", "No");
            if (answer)
            {
                var response = await APIService.Instance.DeleteRequestAsync(vm.Declaration.ID, "/declarations/");
                await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
            }
        }
    }
}
