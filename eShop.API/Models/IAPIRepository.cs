using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.API.Models.Entities
{
    public interface IAPIRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool includeItem);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItem);
        Order GetOrderById(string userName, int id);

        bool SaveAll();
        void AddEntity(object model);
        void AddOrder(Order newOrder);
    }
}