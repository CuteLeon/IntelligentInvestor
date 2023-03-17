using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Intermediary.Abstractions.Application;

public interface IIntermediaryEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IIntermediaryEvent
{
    event EventHandler<TEvent> EventRaised;
}
