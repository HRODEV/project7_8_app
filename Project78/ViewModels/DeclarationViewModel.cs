using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using Project78.Models;

namespace Project78
{
	public class DeclarationViewModel : ViewModelBase
	{
		private Declaration declaration;
        public INavigation Navigation;
		private Command updateCommand;

		public DeclarationViewModel(int id)
		{
			updateCommand = new Command(Patch);
			declaration = new Declaration();
			GetData(id);
		}

		public DeclarationViewModel(Declaration declaration)
		{
			updateCommand = new Command(Post);
			this.declaration = declaration;
			this.declaration.Date = DateTime.Now;
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

		private void Patch()
		{
			Debug.WriteLine(new APIService().PatchRequest(new StringContent(JsonConvert.SerializeObject(Declaration), Encoding.UTF8, "application/json"), "/declarations/" + declaration.ID.ToString()));
			Navigation.PushModalAsync(new NavigationPage(new Project78Page()));
		}

		private void Post()
		{
			Debug.WriteLine(new APIService().PostRequest(new StringContent(JsonConvert.SerializeObject(Declaration), Encoding.UTF8, "application/json"), "/declarations/"));
			Navigation.PushModalAsync(new NavigationPage(new Project78Page()));			                
		}
	}
}
