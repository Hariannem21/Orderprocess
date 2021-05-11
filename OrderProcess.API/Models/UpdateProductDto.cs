using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcess.API.Models
{
    public class UpdateProductDto
    {
        public UpdateProductDto(int updatedInventoryQuantity)
        {
            UpdatedInventoryQuantity = updatedInventoryQuantity;
        }
        public int UpdatedInventoryQuantity { get; set; }
    }
}
