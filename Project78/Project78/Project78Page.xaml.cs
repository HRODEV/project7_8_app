using Xamarin.Forms;

namespace Project78
{
	public partial class Project78Page : ContentPage
	{
		public Project78Page()
		{
			this.BindingContext = new DeclarationViewModel();
			InitializeComponent();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView lv = (ListView)sender;
			Declaration shit = (Declaration)lv.SelectedItem;
			await Navigation.PushAsync(new DetailedDeclarationPage());
		}
	}
}
