using System;
using Xamarin.Forms;

namespace Project78
{
	public class DeclarationViewModel : ViewModelBase
	{
		private Declaration declaration;
        public INavigation Navigation;

		public DeclarationViewModel(int id)
		{
			declaration = new Declaration();
			GetData(id);
		}

		private void GetData(int id)
		{
			declaration = new APIService().getDeclaration(id);
		}

		public Declaration Declaration
		{
			get
			{
				return declaration;
			}
			set 
			{
				declaration = value;
				OnPropertyChanged("Declaration");
			}
		}


	}
}
