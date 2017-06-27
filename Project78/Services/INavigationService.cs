using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project78.Services
{
    public interface INavigationService
    {
        Task NavigateToContentPage(ContentPage page);
    }
}
