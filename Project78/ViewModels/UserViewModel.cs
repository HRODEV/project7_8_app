using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project78.Services;
using Project78.Views;

namespace Project78.ViewModels
{
    class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            _navigator = new Navigator();
        }

        private readonly INavigationService _navigator;

        public void test()
        {
            _navigator.NavigateToContentPage(new RegisterPage());
        }

    }
}
