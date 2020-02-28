using System.Collections.Generic;
using eShop.API.Models.Entities;

namespace eShop.API.Models
{
    public class APIRepository : IAPIRepository
    {
        public APIRepository()
        {
        }

        public void AddEntity(object model)
        {
            throw new System.NotImplementedException();
        }

        public void AddOrder(Order newOrder)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItem)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrderById(string userName, int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveAll()
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Product> GetAllProducts()
        {
            return null;
        }

        IEnumerable<Product> IAPIRepository.GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}