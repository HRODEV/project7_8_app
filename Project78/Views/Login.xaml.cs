using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project78.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project78.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.Navigation = Navigation;
            InitializeComponent();
        }
    }
}