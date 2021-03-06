﻿using Project78.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project78.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartUpPage : ContentPage
    {
        public StartUpPage()
        { 
            var vm = new StartUpViewModel();
            this.BindingContext = vm;
            vm.Navigation = Navigation;
            InitializeComponent();
        }
    }
}