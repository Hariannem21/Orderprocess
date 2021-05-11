using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcess.API.Models;
using OrderProcess.API.Services;

namespace OrderProcess.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProcessorRepository _orderProcessorRepository;
        private readonly IPaymentService _paymentService;
        private readonly IMailService _mailService;

        public OrderController(IOrderProcessorRepository orderProcessorRepository, IPaymentService paymentService, IMailService mailService)
        {
            _orderProcessorRepository = orderProcessorRepository??
                                        throw new ArgumentNullException(nameof(orderProcessorRepository))     ;
            _paymentService = paymentService;
            _mailService = mailService;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderProcessorRepository.GerOrders();
            return Ok(orders);
        }
        [HttpPost]
        [Route("process")]
        public IActionResult ProcessOrder( [FromBody]ProcessOrderDto orderPlaced)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = _orderProcessorRepository.GetProdut(orderPlaced.ProductId);
            if (product.AvaliableQuantity >= orderPlaced.Quantity)
            {
                _orderProcessorRepository.CreateOrder(new CreateOrderDto(orderPlaced.UserId,orderPlaced.ProductId,orderPlaced.Quantity));
                _orderProcessorRepository.UpdateProduct(new UpdateProductDto(product.AvaliableQuantity- orderPlaced.Quantity));
                var paymentStatus = _paymentService.ChargePayment(orderPlaced.CreditCard, orderPlaced.Quantity* product.Price );
                if (paymentStatus)
                {
                    _mailService.Send($"Order Placed for {product.Id} by {orderPlaced.UserId}",$"Please ship {orderPlaced.Quantity} quantity of {product.Id} to User: {orderPlaced.UserId}");
                    return Ok(new Response<bool>()
                    {
                        Data = true,
                    });
                }
                return BadRequest(new Response<bool>()
                {
                    Data = false,
                    Error = "Unable to process payment"
                });
            }
            return BadRequest(new Response<bool>()
            {
                Data = false,
                Error = "Requested quantity of product is not available in inventory"
            });
        }
    }
}