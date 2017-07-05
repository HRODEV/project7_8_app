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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            var vm = new RegisterViewModel();
            this.BindingContext = vm;
            vm.Navigation = Navigation;

            InitializeComponent();
        }
    }
}