using IntelligentInvestor.Intermediary.Abstractions.Domain;

namespace IntelligentInvestor.Intermediary.Abstractions.Application;

public interface IIntermediaryCommandHandler<TCommand> : IIntermediaryRequestHandler<TCommand, ValueTuple>
    where TCommand : IIntermediaryCommand
{
}
