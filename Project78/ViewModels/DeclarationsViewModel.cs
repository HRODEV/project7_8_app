using System.Collections.ObjectModel;
using Project78.Services;
using Xamarin.Forms;
using Project78.Models;
using System.Threading.Tasks;

namespace Project78.ViewModels
{
	public class DeclarationsViewModel : ViewModelBase
	{
		private ObservableCollection<Declaration> declarations;
        public Command LoadDataCommand { get; }

        public DeclarationsViewModel()
		{
			declarations = new ObservableCollection<Declaration>();
			LoadDataCommand = new Command(async () => await LoadData());
		}

		public async Task LoadData()
		{
            //should you create a new Collection?
            try
            {
                Declarations = new ObservableCollection<Declaration>(await new APIService().GetDeclarationsAsync());
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Oops!", "We have encountered a problem!", "Ok");
            }

        }

		public ObservableCollection<Declaration> Declarations
		{
            get => declarations;
            set => SetProperty(ref declarations, value);
		}
	}
}
