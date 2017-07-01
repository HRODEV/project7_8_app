﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project78.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project78.ViewModels;

namespace Project78.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EneditableDeclarationPage : ContentPage
    {
        DeclarationViewModel vm;

        public EneditableDeclarationPage(Declaration declaration)
        {
            ToolbarItems.Add(new ToolbarItem("Delete", null, async () =>
            {
                var answer = await DisplayAlert("", "Do you want to delete this declaration?", "Yes", "No");
                if (answer)
                {
                    var response = new APIService().DeleteRequestAsync(declaration.ID, "/declarations/");
                    await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
                }
            }));

            vm = new DeclarationViewModel(declaration.ID);
            this.BindingContext = vm;
			vm.Declaration.Date = vm.Declaration.Date.Split(' ').First();
            vm.Navigation = Navigation;
            InitializeComponent();
        }
    }
}
