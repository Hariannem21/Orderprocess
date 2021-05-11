using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcess.API.Contexts;
using OrderProcess.API.Entities;
using OrderProcess.API.Models;

namespace OrderProcess.API.Services
{
    public class OrderProcessorRepository : IOrderProcessorRepository
    {
        private readonly ProcessOrderContext _ctx;

        public OrderProcessorRepository(ProcessOrderContext ctx)
        {
            _ctx = ctx?? throw new ArgumentNullException(nameof(ctx));
        }
        public IEnumerable<Order> GerOrders()
        {
            return _ctx.Orders.ToList();
        }

        public Product GetProdut(int productId)
        {
            return _ctx.Products.FirstOrDefault(x=> x.Id == productId);
        }

        public User GetUser(int userId)
        {
            return _ctx.Users.FirstOrDefault(x => x.Id == userId);
        }

        public Order CreateOrder(CreateOrderDto createOrder)
        {
            //todo  requirement document missing piece
            return  new Order();
        }

        public bool UpdateProduct(UpdateProductDto product)
        {
            //todo requirement document missing piece
            return true;
        }
    }
}
