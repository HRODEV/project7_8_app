using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Project78.Views;

namespace Project78.Services
{
    public class Navigator : INavigationService
    {

        public Navigator()
        {
            //Navigation = new INavigation();
        }
        private readonly INavigation Navigation;

        public async Task NavigateToContentPage(ContentPage page)
        {
            await Navigation.PushAsync(page);
        }
    }
}
