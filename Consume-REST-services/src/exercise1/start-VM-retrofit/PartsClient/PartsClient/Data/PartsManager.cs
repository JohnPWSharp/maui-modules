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
        // TODO: Add fields here

        private async Task<HttpClient> GetClient()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Part>> GetAll()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public async Task<Part> Add(string partName, string supplier, string partType)
        {
            // TODO:
            throw new NotImplementedException();
        }

        public async Task Update(Part part)
        {
            // TODO:
            throw new NotImplementedException();
        }

        public async Task Delete(string partID)
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}
