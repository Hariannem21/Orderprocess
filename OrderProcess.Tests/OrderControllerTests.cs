using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OrderProcess.API.Controllers;
using OrderProcess.API.Entities;
using OrderProcess.API.Models;
using OrderProcess.API.Services;

namespace OrderProcess.Tests
{
    [TestFixture]
    public class OrderControllerTests
    {
        private Mock<IOrderProcessorRepository> _mockOrderProcessorRepo;
        private Mock<IMailService> _mockMailService;
        private Mock<IPaymentService> _mockPaymentService;
        private OrderController _controller;
        [SetUp]
        public void Setup()
        {
            _mockOrderProcessorRepo = new Mock<IOrderProcessorRepository>();
            _mockMailService = new Mock<IMailService>();
            _mockPaymentService = new Mock<IPaymentService>();
            _controller = new OrderController(_mockOrderProcessorRepo.Object, _mockPaymentService.Object, _mockMailService.Object);
        }

        [Test]
        public void ReturnBadResultWhenAvailableQuantityLessThanRequestedQuantity()
        {
            //Assemble
            var product = LessAvailableProduct();
            var orderPlaced = ValidProcessOrderDto();

            _mockOrderProcessorRepo.Setup(x
                => x.GetProdut(10))
                .Returns(product);


            //Act
            var response = _controller.ProcessOrder(orderPlaced) as BadRequestObjectResult;
            //Assert
            var value = response?.Value as Response<bool>;
            Assert.IsNotNull(response);
            Assert.AreEqual("Requested quantity of product is not available in inventory", value?.Error);
        }

        [Test]
        public void ReturnBadResultWhenPaymentIsUnSuccessful()
        {
            //Assemble
            //Assemble
            var orderPlaced = ValidProcessOrderDto();
            var product = ValidProduct();
          
            _mockOrderProcessorRepo.Setup(x
                    => x.GetProdut(orderPlaced.ProductId))
                .Returns(product);

            _mockPaymentService.Setup(x => x.ChargePayment(orderPlaced.CreditCard,orderPlaced.Quantity * product.Price )).Returns(false);

            //Act
            var response = _controller.ProcessOrder(orderPlaced) as BadRequestObjectResult;
            //Assert
            var value = response?.Value as Response<bool>;
            Assert.IsNotNull(response);
            Assert.AreEqual("Unable to process payment", value?.Error);
        }

        [Test]
        public void ReturnOkResultWhenPaymentIsUnSuccessful()
        {
            //Assemble
            //Assemble
            var orderPlaced = ValidProcessOrderDto();
            var product = ValidProduct();

            _mockOrderProcessorRepo.Setup(x
                    => x.GetProdut(orderPlaced.ProductId))
                .Returns(product);

            _mockPaymentService.Setup(x => x.ChargePayment(orderPlaced.CreditCard, orderPlaced.Quantity * product.Price)).Returns(true);

            //Act
            var response = _controller.ProcessOrder(orderPlaced) as OkObjectResult ;
            //Assert
            var value = response?.Value as Response<bool>;
            Assert.IsNotNull(response);
            Assert.AreEqual(true, value?.Data);
        }


        private static Product ValidProduct()
        {
            var product = new Product()
                {AvaliableQuantity = 20, Id = 10, Price = 300};
            return product;
        }

        private static Product LessAvailableProduct()
        {
            var product = new Product()
                { AvaliableQuantity = 5, Id = 10, Price = 300 };
            return product;
        }

        private static ProcessOrderDto ValidProcessOrderDto()
        {
            var orderPlaced = new ProcessOrderDto()
            {
                CreditCard = "6011111111111117",
                ProductId = 10,
                Quantity = 10,
                UserId = 2
            };
            return orderPlaced;
        }
    }
}
