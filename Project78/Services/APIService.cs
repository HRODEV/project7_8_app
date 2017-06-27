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
        }

        private HttpClient client;

        public IEnumerable<Declaration> getDeclarations()
        {
            return RequestJson<List<Declaration>>();
        }

        public HttpResponseMessage PostImage(HttpContent content)
        {
            var testcontent = new MultipartFormDataContent();
            testcontent.Add(content, "image", "test.jpg");

            HttpResponseMessage response = client.PostAsync("/receipt", testcontent).Result;

            return response;
        }

        private HttpResponseMessage PostRequest(HttpContent content)
        {
            var response = client.PostAsync("/receipt", content).Result;

            return response;
        }

        private T RequestJson<T>()
        {
            HttpResponseMessage responseshit = client.GetAsync("/declarations").Result;
            string responseBody = responseshit.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
	}
}
