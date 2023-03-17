using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Intermediary.Abstractions.Application;

public interface IIntermediaryNotificationHandler<in TNotification> : INotificationHandler<TNotification>
    where TNotification : IIntermediaryNotification
{
}
