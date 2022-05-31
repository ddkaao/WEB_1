using AutoRep1.Data.DTOs;
using AutoRep1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRep1.Data.Services
{
    public class OrderService
    {
        private EducationContext _context;
        public OrderService(EducationContext context)
        {
            _context = context;
        }

        public async Task<Order?> AddOrder(OrderDTO order)
        {
            Order norder = new Order
            {
                ClientID = order.ClientID,
                ServiceID = order.ServiceID
            };
            var result = _context.Orders.Add(norder);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        public async Task<List<Order>> GetOrders()
        {
            var result = await _context.Orders.Include(a => a.Clients).Include(b => b.Services).ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<Order?> GetOrder(int id)
        {

            var result = _context.Orders.Include(a => a.Clients).Include(b => b.Services).FirstOrDefault(order => order.Id == id);

            return await Task.FromResult(result);
        }

        public async Task<List<IncompleteOrderDTO>> GetOrdersIncomplete()
        {
            var orders = await _context.Orders.ToListAsync();
            List<IncompleteOrderDTO> result = new List<IncompleteOrderDTO>();
            orders.ForEach(or => result.Add(new IncompleteOrderDTO { Id = or.Id }));
            return await Task.FromResult(result);
        }

        public async Task<Order?> UpdateOrder(int id, Order updatedOrder)
        {
            var order = await _context.Orders.Include(order => order.Clients).Include(b => b.Services).FirstOrDefaultAsync(or => or.Id == id);
            if (order != null)
            {
                if (updatedOrder.Clients.Any())
                {
                    order.Clients = _context.Clients.ToList().IntersectBy(updatedOrder.Clients, client => client).ToList();
                }
                if (updatedOrder.Services.Any())
                {
                    order.Services = _context.Services.ToList().IntersectBy(updatedOrder.Services, service => service).ToList();
                }
                _context.Orders.Update(order);
                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return order;
            }

            return null;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(or => or.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
