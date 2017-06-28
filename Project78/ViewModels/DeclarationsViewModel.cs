using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Project78.Services;
using Xamarin.Forms;
using Project78.Models;

namespace Project78
{
	public class DeclarationsViewModel : ViewModelBase
	{
		private ObservableCollection<Declaration> declarations;

		public DeclarationsViewModel()
		{
			declarations = new ObservableCollection<Declaration>();
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
