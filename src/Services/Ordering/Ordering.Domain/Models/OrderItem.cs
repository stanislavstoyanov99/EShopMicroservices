﻿namespace Ordering.Domain.Models
{
    public class OrderItem : Entity<Guid>
    {
        public OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
        {
            Id = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid ProductId { get; private set; } = default!;

        public int Quantity { get; private set; } = default!;

        public decimal Price { get; private set; } = default!;
    }
}
