using IntelligentInvestor.Intermediary.Domain;

namespace IntelligentInvestor.Intermediary.Application;

public interface IIntermediaryNotificationHandler<in TNotification> : INotificationHandler<TNotification>
    where TNotification : IIntermediaryNotification
{
}
