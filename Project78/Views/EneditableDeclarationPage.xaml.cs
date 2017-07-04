﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ToolbarItems.Add(new ToolbarItem("Delete", null, async () =>
            {
                var answer = await DisplayAlert("", "Do you want to delete this declaration?", "Yes", "No");
                if (answer)
                {
                    try
                    {
                        await APIService.Instance.DeleteRequestAsync(declaration.ID, "/declarations/");
                        await Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
                    }
                    catch
                    {
                        await DisplayAlert("Oops!", "We have encountered a problem!", "Ok");
                    }
                    //ImageTest.Source = await apiService.GetImage(declaration.ID);
                }
            }));
            
            vm = new DeclarationViewModel(declaration.ID);
            this.BindingContext = vm;
			//vm.Declaration.Date = vm?.Declaration?.Date?.Split(' ')?.First() ?? string.Empty;
            vm.Navigation = Navigation;
            InitializeComponent();
        }
    }
}
