using System;
namespace Project78
{
	public class DeclartionViewModel : ViewModelBase
	{
		private Declaration declaration;

		public DeclartionViewModel(int id)
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
