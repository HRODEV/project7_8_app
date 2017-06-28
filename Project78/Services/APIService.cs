using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.VisualBasic;
using System.Text;
using Xamarin.Forms;
using Project78.Models;

namespace Project78
{
    public class APIService
    {
        public APIService()
        {
            client = new HttpClient { BaseAddress = new Uri("http://37.139.12.76:8080") };  
        }
        
        private HttpClient client;

        public IEnumerable<Declaration> getDeclarations()
        {
            return RequestJson<List<Declaration>>("/declarations");
        }

        public User getAuthenticateUser(string authenticationHeader)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authenticationHeader);

            //return RequestJson<User>("user/auth/");
            return new User("A", "b", "c", "d");
        }

		public Declaration getDeclaration(int id)
		{
			return RequestJson<Declaration>("/declarations/" + id.ToString());
		}

        public Declaration PostImage(HttpContent content, string filename)
        {
            var testcontent = new MultipartFormDataContent();
            testcontent.Add(content, "image", filename);

            HttpResponseMessage response = client.PostAsync("/receipt", testcontent).Result;
			if (response.IsSuccessStatusCode)
			{
				string responseBody = response.Content.ReadAsStringAsync().Result;
				return new Declaration { ID = 1 };
				//return JsonConvert.DeserializeObject<Declaration>(responseBody);                              
			}
			return new Declaration();
        }

		public Image GetImage(int id)
		{
			return RequestJson<Image>("/declarations/" + id.ToString());
		}

        public HttpResponseMessage PostRequest(HttpContent content, string endpoint)
        {
            var response = client.PostAsync(endpoint, content).Result;

            return response;
        }

		public HttpResponseMessage PutRequest(HttpContent content, string endpoint)
		{
			HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint)
			{
				Content = content
			};

			var response = client.SendAsync(request).Result;

            return response;
		}

        private T RequestJson<T>(string endpoint)
        {
            HttpResponseMessage responseshit = client.GetAsync(endpoint).Result;
            string responseBody = responseshit.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
	}
}
