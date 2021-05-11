using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.API.Services
{
    public interface IPaymentService
    {
        Boolean ChargePayment(string creditCardNumber, decimal amount);
    }
}
