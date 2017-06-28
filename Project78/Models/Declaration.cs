using System;
using Newtonsoft.Json;

namespace Project78
{
	public class Declaration
	{
		[JsonProperty(PropertyName = "ID")]
		public int ID
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "Title")]
		public string Title
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "Description")]
		public string Description
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "date")]
		public DateTime Date
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "VATPrice")]
		public float VATPrice
		{
			get;
			set;
		}

		[JsonProperty(PropertyName = "TotalPrice")]
		public float TotalPrice
		{
			get;
			set;
		}
	}
}
