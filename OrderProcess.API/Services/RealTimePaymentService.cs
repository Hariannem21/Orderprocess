using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.API.Services
{
    public class RealTimePaymentService : IPaymentService
    {
        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            return true;
            throw new NotImplementedException();
        }
    }
}
