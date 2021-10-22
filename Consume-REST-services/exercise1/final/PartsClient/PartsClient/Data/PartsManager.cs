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
        static readonly string BaseAddress = "ADD URL HERE";
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
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<Part>>(result, options);
        }

        public async Task<Part> Add(string partName, string supplier, string partType)
        {
            Part part = new Part()
            {
                PartName = partName,
                Suppliers = new List<string>(new[] { supplier }),
                PartID = string.Empty,
                PartType = partType,
                PartAvailableDate = DateTime.Now.Date
            };

            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonSerializer.Serialize(part),
                    Encoding.UTF8, "application/json"));

            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var insertedPart = JsonSerializer.Deserialize<Part>(
                await response.Content.ReadAsStringAsync(), options);
            Console.WriteLine($"{insertedPart.PartID}, {insertedPart.PartName}, {insertedPart.PartType}");
            return insertedPart;
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
