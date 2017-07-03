using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
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
			Declarations = new ObservableCollection<Declaration>(await new APIService().GetDeclarationsAsync());
        }

		public ObservableCollection<Declaration> Declarations
		{
            get => declarations;
            set => SetProperty(ref declarations, value);
		}
	}
}
