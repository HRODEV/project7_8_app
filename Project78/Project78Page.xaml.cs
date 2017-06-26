using Xamarin.Forms;

namespace Project78
{
	public partial class Project78Page : ContentPage
	{
		public Project78Page()
		{
			this.BindingContext = new DeclarationViewModel();
			InitializeComponent();
			Title = "Declarations";
			ToolbarItems.Add(new ToolbarItem("Add", null, async () =>
			{
				await Navigation.PushAsync(new DetailedDeclarationPage());
			}));
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView lv = (ListView)sender;
			Declaration club = (Declaration)lv.SelectedItem;
			await Navigation.PushAsync(new DetailedDeclarationPage());
		}
	}
}
