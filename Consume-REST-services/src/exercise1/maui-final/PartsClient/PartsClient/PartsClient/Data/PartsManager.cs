using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartsClient.Data
{
    public class PartsManager
    {
        //static readonly string BaseAddress = "{Url from before}";
        static readonly string BaseAddress = "https://mslearnbookserver2559419090.azurewebsites.net/";
        static readonly string Url = $"{BaseAddress}/api/parts/";
        private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            if (string.IsNullOrEmpty(authorizationKey))
            {
                client.GetStringAsync(Url + "/login");
                authorizationKey = await client.GetStringAsync(Url + "/login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Part>> GetAll()
        {
            HttpClient client = await GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Part>>(result);
        }

        public async Task<Part> Add(string partName, string supplier, string partType)
        {
            Part part = new Part()
            {
                PartName = partName,
                Suppliers = new List<string>(new[] { supplier }),
                PartID = string.Empty,
                PartType = partType,
                PartAvailableDate = DateTime.Now.Date,
            };

            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(part),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Part>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task Update(Part part)
        {
            HttpClient client = await GetClient();
            await client.PutAsync(Url + "/" + part.PartID,
                new StringContent(
                    JsonConvert.SerializeObject(part),
                    Encoding.UTF8, "application/json"));
        }

        public async Task Delete(string partID)
        {
            HttpClient client = await GetClient();
            await client.DeleteAsync(Url + partID);
        }
    }
}
