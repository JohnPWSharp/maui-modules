using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PartsClient.Data
{
    public class PartsManager
    {
        //static readonly string BaseAddress = "{Url from before}";
        static readonly string BaseAddress = "https://partsserver20210929111848.azurewebsites.net/";
        static readonly string Url = $"{BaseAddress}/api/parts/";
        private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            if (string.IsNullOrEmpty(authorizationKey))
            {
                await client.GetStringAsync(Url + "/login");
                authorizationKey = await client.GetStringAsync(Url + "/login");
                authorizationKey = JsonSerializer.Deserialize<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Part>> GetAll()
        {
            HttpClient client = await GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonSerializer.Deserialize<List<Part>>(result);
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
                    JsonSerializer.Serialize(part),
                    Encoding.UTF8, "application/json"));

            return JsonSerializer.Deserialize<Part>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task Update(Part part)
        {
            HttpClient client = await GetClient();
            await client.PutAsync(Url + "/" + part.PartID,
                new StringContent(
                    JsonSerializer.Serialize(part),
                    Encoding.UTF8, "application/json"));
        }

        public async Task Delete(string partID)
        {
            HttpClient client = await GetClient();
            await client.DeleteAsync(Url + partID);
        }
    }
}
