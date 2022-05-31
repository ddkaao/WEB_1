using Newtonsoft.Json;
using AutoRepApp.Data.Models;
using System.Net.Http.Json;

namespace AutoRepApp.Services
{
    public class ClientsProvider : IClientProvider
    {
        private HttpClient _client;
        public ClientsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Add(Client client)
        {
            string data = JsonConvert.SerializeObject(client);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/client", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<List<Client>> GetAll()
        {
            var val = await _client.GetFromJsonAsync<List<Client>>("/api/client");
            return val;
        }
    }
}
