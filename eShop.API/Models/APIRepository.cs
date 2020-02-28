using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using eShop.API.Models.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace eShop.API.Models
{
    public class APIRepository : IAPIRepository
    {
        private readonly APIContext _ctx;
        private readonly ILogger<APIContext> _logger;

        public APIRepository(APIContext ctx, ILogger<APIContext> logger)
        {
            _ctx=ctx;
            _logger=logger;
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
            if(includeItem)
            {
                return _ctx.Orders.Include(o => o.Items).ThenInclude(o => o.Product).
                ToList();
            }else{
                return _ctx.Orders.
                ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItem)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders.Where(o => o.Id == id).Include(o => o.Items).ThenInclude(o => o.Product).
            FirstOrDefault();
        }

        public bool SaveAll()
        {
            _ctx.SaveChanges();
            return true;        
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try{
            _logger.LogInformation(" GetAllProducts Called");
            return await _ctx.Products
                    .OrderBy(p=>p.Title)
                    .ToListAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError(" GetAllProducts has error "+ex);    
                return null;            
            }
        }

        async Task<IEnumerable<Product>> IAPIRepository.GetProductsByCategory(string category)
        {
            return  await _ctx.Products.Where(p => p.Category == category).ToListAsync();
        }
    }
}