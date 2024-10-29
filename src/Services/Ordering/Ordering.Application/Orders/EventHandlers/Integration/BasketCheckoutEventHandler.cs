using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Domain.Enums;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
    public class BasketCheckoutEventHandler
        (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation($"Integration Event handled: {context.Message.GetType().Name}");

            var command = MapToCreateOrderCommand(context.Message);

            await sender.Send(command);
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
        {
            var addressDto = new AddressDto(
                message.FirstName,
                message.LastName,
                message.EmailAddress,
                message.AddressLine,
                message.Country,
                message.State,
                message.ZipCode);

            var paymentDto = new PaymentDto(
                message.CardName,
                message.CardNumber,
                message.Expiration,
                message.CVV,
                message.PaymentMethod);

            var orderId = Guid.NewGuid();

            var orderDto = new OrderDto(
                Id: orderId,
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BillingAddress: addressDto,
                Payment: paymentDto,
                Status: OrderStatus.Pending,
                OrderItems:
                [
                    new OrderItemDto(orderId, new Guid("44C3AC0C-577A-49B0-9495-052827D47CCD"), 2, 800),
                    new OrderItemDto(orderId, new Guid("6F9233B3-A26B-4B61-84A7-44D86E884023"), 1, 1000)
                ]);

            return new CreateOrderCommand(orderDto);
        }
    }
}
