using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Project78
{
	public class APIService
	{
		public APIService()
		{
		}

		private string url = "http://37.139.12.76:8080/";

		public IEnumerable<Declaration> getDeclarations()
		{
			return RequestJson<List<Declaration>>(url + "/declarations");
		}

		private static T RequestJson<T>(string url)
		{
			HttpWebRequest request = WebRequest.CreateHttp(url);
			WebResponse response = Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null).Result;

			using (StreamReader stream = new StreamReader(response.GetResponseStream()))
				return JsonConvert.DeserializeObject<T>(stream.ReadToEnd());
		}
	}
}
