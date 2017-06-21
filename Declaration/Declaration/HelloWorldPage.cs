using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Declaration
{
    public class HelloWorldPage : ContentPage
    {
        public HelloWorldPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin Forms!" }
                }
            };
        }
    }
}