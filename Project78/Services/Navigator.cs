using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project78.Services
{
    public class Navigator : INavigationService
    {

        public Navigator()
        {
            //Navigation = new INavigation();
        }
#pragma warning disable CS0649 // Field 'Navigator.Navigation' is never assigned to, and will always have its default value null
        private readonly INavigation Navigation;
#pragma warning restore CS0649 // Field 'Navigator.Navigation' is never assigned to, and will always have its default value null

        public async Task NavigateToContentPage(ContentPage page)
        {
            // always null. Not?
            await Navigation.PushAsync(page);
        }
    }
}
