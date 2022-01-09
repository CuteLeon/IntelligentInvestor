using IntelligentInvestor.Intermediary.Application;
using IntelligentInvestor.Intermediary.Infrastructure;

namespace IntelligentInvestor.Intermediary.Extensions;

public static class IntelligentInvestorIntermediaryExtension
{
    public static IServiceCollection AddIntelligentInvestorIntermediary(this IServiceCollection services)
        => services
            .AddMediatR(typeof(IntelligentInvestorIntermediaryExtension).Assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(IntermediaryPipelineBehavior<,>))
            .AddTransient<IIntermediaryPublisher, IntermediaryPublisher>();
}
