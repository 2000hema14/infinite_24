using EKART_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace EKART_Application.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwinddbContext _dbContext;

        public OrderRepository(NorthwinddbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _dbContext.Orders.FindAsync(orderId);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}