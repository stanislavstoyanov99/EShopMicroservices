﻿namespace Ordering.Application.Orders.EventHandlers
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEvent> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Domain Event handled: {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}
