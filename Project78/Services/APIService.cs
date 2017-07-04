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
using System.Diagnostics;

namespace Project78.Services
{
    public sealed class APIService
    {
        private static APIService instance;

        private APIService() { }

        public static APIService Instance
        {
            get
            {
                if (instance == null)
                    instance = new APIService();
                return instance;
            }
        }
        
        private HttpClient client = new HttpClient { BaseAddress = new Uri("http://37.139.12.76:8080") };

        public async Task<IEnumerable<Declaration>> GetDeclarationsAsync() => await RequestJson<List<Declaration>>("/declarations");

        public User GetAuthenticateUser(string authenticationHeader)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authenticationHeader);
            //return RequestJson<User>("user/auth/");
            return new User("A", "b", "c", "d");
        }

        public Uri GetImageUri(int receiptID) => new Uri($"{client.BaseAddress}/receipt/{receiptID}/image");

        public async Task<Declaration> GetDeclarationAsync(int id) => await RequestJson<Declaration>("/declarations/" + id.ToString());

        public async Task<Declaration> PostImageAsync(HttpContent content, string filename)
        {
            var testcontent = new MultipartFormDataContent
            {
                { content, "image", filename }
            };
            HttpResponseMessage response = await client.PostAsync("/receipt", testcontent);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Declaration>(responseBody);
            }
            // Why a emptyDeclaration on fail?
            return new Declaration();
        }

        public async Task<byte[]> GetImageAsync(int id) => await client.GetByteArrayAsync("/receipt/" + id.ToString() + "/image");
 
        public async Task<HttpResponseMessage> PostRequestAsync(HttpContent content, string endpoint) => await client.PostAsync(endpoint, content);
        public async Task<HttpResponseMessage> DeleteRequestAsync(int id, string endpoint) => await client.DeleteAsync(endpoint + id);
        public async Task<HttpResponseMessage> PatchRequestAsync(HttpContent content, string endpoint)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint)
            {
                Content = content
            };

            return await client.SendAsync(request);
        }

        private async Task<T> RequestJson<T>(string endpoint)
        {
            HttpResponseMessage responseshit = await client.GetAsync(endpoint);
            string responseBody = await responseshit.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
	}
}
