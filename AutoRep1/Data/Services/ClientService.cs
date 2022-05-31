using AutoRep1.Data.DTOs;
using AutoRep1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRep1.Data.Services
{
    public class ClientService
    {
        private EducationContext _context;
        public ClientService(EducationContext context)
        {
            _context = context;
        }

        public async Task<Client?> AddClient(ClientDTO client)
        {
            Client nclient = new Client
            {
                FullName = client.FullName,
                Phone = client.Phone,
                Email = client.Email
            };
            var result = _context.Clients.Add(nclient);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<List<Client>> GetClients()
        {
            var result = await _context.Clients.ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Client?> GetClient(int id)
        {

            var result = _context.Clients.FirstOrDefault(client => client.Id == id);

            return await Task.FromResult(result);
        }

        public async Task<List<IncompleteClientDTO>> GetClientsIncomplete()
        {
            var clients = await _context.Clients.ToListAsync();
            List<IncompleteClientDTO> result = new List<IncompleteClientDTO>();
            clients.ForEach(cl => result.Add(new IncompleteClientDTO { Id = cl.Id, FullName = cl.FullName }));
            return await Task.FromResult(result);
        }

        public async Task<Client?> UpdateClient(int id, Client updatedClient)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(cl => cl.Id == id);
            if (client != null)
            {
                client.FullName = updatedClient.FullName;
                client.Phone = updatedClient.Phone;
                client.Email = updatedClient.Email;
                _context.Clients.Update(client);
                _context.Entry(client).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return client;
            }

            return null;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(cl => cl.Id == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
