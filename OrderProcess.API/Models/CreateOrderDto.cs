namespace OrderProcess.API.Models
{
    public class CreateOrderDto
    {
        public CreateOrderDto(int userId, int productId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
