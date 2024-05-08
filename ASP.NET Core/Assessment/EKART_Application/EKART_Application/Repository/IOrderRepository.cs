using EKART_Application.Models;

namespace EKART_Application.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int orderId);

        Task<List<Order>> GetAllOrders();

        Task<Order> AddOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task DeleteOrder(int orderId);
    }
}