using IntelligentInvestor.Intermediary.Domain;

namespace IntelligentInvestor.Intermediary.Application;

public interface IIntermediaryEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IIntermediaryEvent
{
    event EventHandler<TEvent> EventRaised;
}
