using BuildingBlocks.Application.Interfaces.CQRS.Notifications;
using BuildingBlocks.Application.Interfaces.CQRS.Notifications.Handler;

namespace BuildingBlocks.Application.CQRS.Notifications;
public abstract class NotificationHandler<TypeNotification> : INotificationHandler<TypeNotification>
    where TypeNotification : INotification {
    protected abstract Task HandleNotificationAsync(TypeNotification notification, CancellationToken cancellationToken);
    public async Task Handle(TypeNotification notification, CancellationToken cancellationToken) {
        await HandleNotificationAsync(notification, cancellationToken);
    }
}