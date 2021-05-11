using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OrderProcess.API.Services
{
    public class MockPaymentService :IPaymentService
    {

        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            Debug.WriteLine($"This is for test");
            return true;
            throw new NotImplementedException();
        }
    }
}
