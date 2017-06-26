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
	}
}
