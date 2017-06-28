using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;

namespace Project78
{
	public class DeclartionViewModel : ViewModelBase
	{
		private Declaration declaration;
		private Command updateCommand;

		public DeclartionViewModel(int id)
		{
			updateCommand = new Command(Update);
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

		public Command UpdateCommand { get { return updateCommand;} }

		private void Update()
		{
			Debug.WriteLine(new APIService().PutRequest(new StringContent(JsonConvert.SerializeObject(Declaration), Encoding.UTF8, "application/json"), "/declarations/" + declaration.ID.ToString()));
		}

	}
}
