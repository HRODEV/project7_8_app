using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.VisualBasic;
using System.Text;

namespace Project78
{
	public class APIService
	{
		public APIService()
		{
            var authData = string.Format("{0}:{1}", "testUsername", "testPassword");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient { BaseAddress = new Uri("http://37.139.12.76:8080") };
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeaderValue);

            //HttpResponseMessage response = client.GetAsync("/declarations").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    string body = response.Content.ReadAsStringAsync().Result;
            //}
		}

        private HttpClient client;

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
