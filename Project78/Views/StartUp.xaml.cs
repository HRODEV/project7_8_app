﻿using Project78.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project78.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartUpPage : ContentPage
    {
        private readonly INavigationService _navigationService = new Navigator();

        public StartUpPage()
        {
            InitializeComponent();
        }
        
    }
}