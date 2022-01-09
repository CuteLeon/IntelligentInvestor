using IntelligentInvestor.Intermediary.Domain;

namespace IntelligentInvestor.Intermediary.Application;

public interface IIntermediaryCommandHandler<TCommand> : IIntermediaryRequestHandler<TCommand, ValueTuple>
    where TCommand : IIntermediaryCommand
{
}
