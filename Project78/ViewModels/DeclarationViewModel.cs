using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Project78.Services;
using Xamarin.Forms;

namespace Project78
{
	public class DeclarationViewModel : ViewModelBase
	{
		private ObservableCollection<Declaration> declarations;
        private readonly INavigationService _navigator;

		public DeclarationViewModel()
		{
			declarations = new ObservableCollection<Declaration>();
            _navigator = new Navigator();
			GetData();
		}

		public void GetData()
		{
			declarations = new ObservableCollection<Declaration>(new APIService().getDeclarations());
        }

		public ObservableCollection<Declaration> Declarations
		{
			get
			{
				return declarations;
			}
			set
			{
				declarations = value;
				OnPropertyChanged("Declarations");
			}
		}
	}
}
