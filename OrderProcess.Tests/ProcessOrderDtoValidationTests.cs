using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using OrderProcess.API.Models;

namespace OrderProcess.Tests
{
    [TestFixture]
    public class ProcessOrderDtoValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void NotAllowZeroQuantity()
        {
            //Assemble
            var emp = new ProcessOrderDto
            {
              CreditCard = "6011111111111117",
              ProductId = 1,
              Quantity = 0,
              UserId = 2
            };

            //Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(emp, new ValidationContext(emp), validationResults, true);
            
            //Assert
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void NotAllowInvalidCreditCard()
        {
            //Assemble
            var emp = new ProcessOrderDto
            {
                CreditCard = "601111111111111",
                ProductId = 1,
                Quantity = 10,
                UserId = 2
            };

            //Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(emp, new ValidationContext(emp), validationResults, true);

            //Assert
            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
        }

        [Test]
        public void ValidateProcessOrderDtoValidTest()
        {
            //Assemble
            var emp = new ProcessOrderDto
            {
                CreditCard = "6011111111111117",
                ProductId = 1,
                Quantity = 10,
                UserId = 2
            };

            //Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(emp, new ValidationContext(emp), validationResults, true);

            //Assert
            Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
        }
    }
}