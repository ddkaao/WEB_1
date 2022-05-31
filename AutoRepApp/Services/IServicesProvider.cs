using AutoRepApp.Data.Models;

namespace AutoRepApp.Services
{
    public interface IServicesProvider
    {
        Task<List<Service>> GetAll();
        Task<Service> GetOne(int id);
        Task<bool> Add(Service item);
        Task<Service> Edit(Service item);
        Task<bool> Remove(int id);

    }
}
