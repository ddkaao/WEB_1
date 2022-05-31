using AutoRepApp.Data.Models;

namespace AutoRepApp.Services

{
    public interface IClientProvider
    {
        Task<bool> Add(Client client);
        Task<List<Client>> GetAll();
    }
}
