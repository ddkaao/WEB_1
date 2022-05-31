using AutoRep1.Data.DTOs;
using AutoRep1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRep1.Data.Services
{
    public class ServiceService
    {

        private EducationContext _context;
        public ServiceService(EducationContext context)
        {
            _context = context;
        }

        public async Task<Service?> AddService(ServiceDTO service)
        {
            Service nservice = new Service
            {
                NameOfService = service.NameOfService,
                Price = service.Price,
                Time = service.Time
            };
            var result = _context.Services.Add(nservice);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<List<Service>> GetServices()
        {
            var result = await _context.Services.ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Service?> GetService(int id)
        {

            var result = _context.Services.FirstOrDefault(service => service.Id == id);

            return await Task.FromResult(result);
        }

        public async Task<Service?> UpdateService(int id, Service updatedService)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service != null)
            {
                service.NameOfService = updatedService.NameOfService;
                service.Price = updatedService.Price;
                service.Time = updatedService.Time;
                _context.Services.Update(service);
                _context.Entry(service).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return service;
            }

            return null;
        }

        public async Task<bool> DeleteService(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<IncompleteServiceDTO>> GetServicesIncomplete()
        {
            var services = await _context.Services.ToListAsync();
            List<IncompleteServiceDTO> result = new List<IncompleteServiceDTO>();
            services.ForEach(sr => result.Add(new IncompleteServiceDTO { Id = sr.Id, NameOfService = sr.NameOfService, Price = sr.Price }));
            return await Task.FromResult(result);
        }
    }
}
