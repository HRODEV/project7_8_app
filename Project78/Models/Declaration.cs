﻿using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Project78.Models
{
    public class Declaration
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

		[JsonProperty(PropertyName = "Date")]
		public string DateUnitTime { get; set; }

		[JsonIgnore]
		public DateTime DateTime
		{
            get
            {
                if (DateUnitTime == "")
                    return DateTime.Now;
                return Convert.ToDateTime(DateUnitTime, new CultureInfo("nl-NL"));
            }
			set => DateUnitTime = value.ToString();
		}

        [JsonProperty(PropertyName = "VATPrice")]
		public float VATPrice { get; set; }

        [JsonProperty(PropertyName = "TotalPrice")]
		public float TotalPrice { get; set; }

        [JsonProperty(PropertyName = "StoreName")]
		public string StoreName { get; set; }

        [JsonProperty(PropertyName = "ReceiptID")]
		public int ReceiptID { get; set; }
    }
}
