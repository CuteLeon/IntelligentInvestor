using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Application.Repositorys.Stocks;
using IntelligentInvestor.Domain.Options;
using IntelligentInvestor.Infrastructure.DBContexts;
using IntelligentInvestor.Infrastructure.Repositorys.Quotas;
using IntelligentInvestor.Infrastructure.Repositorys.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentInvestor.Infrastructure.Extensions;

public static class IntelligentInvestorInfrastructureExtension
{
    public static IServiceCollection AddIntelligentInvestorInfrastructure(this IServiceCollection services)
        => services
            .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .AddTransient<IGenericOptionRepository, GenericOptionRepository>()
            .AddTransient<IStockRepository, StockRepository>()
            .AddTransient<IQuotaRepository, QuotaRepository>();

    public static IServiceCollection AddIntelligentInvestorDBContext(
        this IServiceCollection services, string connectionString)
        => services.AddDbContext<DbContext, IntelligentInvestorDBContext>(
            options => options
                .UseSqlite(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLazyLoadingProxies(),
            ServiceLifetime.Scoped);
}
