using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Infrastructure.Extensions;

public static class IntelligentInvestorInfrastructureExtension
{
    public static IServiceCollection AddIntelligentInvestorInfrastructure(this IServiceCollection services)
        => services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

    public static IServiceCollection AddIntelligentInvestorDBContext(
        this IServiceCollection services, string connectionString)
        => services.AddDbContext<DbContext, IntelligentInvestorDBContext>(
            options => options
                .UseSqlite(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLazyLoadingProxies(),
            ServiceLifetime.Scoped);
}
