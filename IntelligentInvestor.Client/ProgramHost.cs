using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Client;

internal class ProgramHost
{
    internal IServiceCollection Services { get; } = new ServiceCollection();

    public IServiceProvider ServiceProvider { get; private set; }

    internal void BuilderServiceProvider() =>
        this.ServiceProvider = this.Services.BuildServiceProvider();
}
