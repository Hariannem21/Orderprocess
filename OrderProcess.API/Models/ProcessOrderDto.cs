using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.API.Models
{
    public class ProcessOrderDto
    {
        // public ProcessOrderDto(int productId, int quantity, int userId, string creditCard)
        // {
        //     ProductId = productId;
        //     Quantity = quantity;
        //     UserId = userId;
        //     CreditCard = creditCard;
        // }

        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [CreditCard]
        public string CreditCard { get; set; }
    }
}
