using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcess.API.Entities;
using OrderProcess.API.Models;

namespace OrderProcess.API.Services
{
    public interface IOrderProcessorRepository
    {
        // IQueryable<Order> GerOrders();
        IEnumerable<Order> GerOrders();
        Product GetProdut(int productId);
        User GetUser(int userId);
        Order CreateOrder(CreateOrderDto createOrder);
        bool UpdateProduct(UpdateProductDto product);



    }
}
