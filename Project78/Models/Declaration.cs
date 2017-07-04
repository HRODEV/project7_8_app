using Newtonsoft.Json;

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

        //[JsonProperty(PropertyName = "Date")]
        //public int DateUnitTime { get; set; }

        //[JsonIgnore]
        //public DateTime DateTime 
        //{
        //    get => new DateTime(1970, 1, 1).AddSeconds(DateUnitTime);
        //    set => DateUnitTime = (value - new DateTime(1970, 1, 1)).Seconds;
        //}

		[JsonProperty(PropertyName = "Date")]
		public string DateUnitTime { get; set; }

		[JsonIgnore]
		public DateTime DateTime
		{
			get => Convert.ToDateTime(DateUnitTime);
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
