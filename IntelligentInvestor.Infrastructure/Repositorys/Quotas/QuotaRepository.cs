using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Application.Repositorys.Quotas;
using IntelligentInvestor.Domain.Quotas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Infrastructure.Repositorys.Quotas;

public class QuotaRepository : RepositoryBase<Quota>, IQuotaRepository
{
    public QuotaRepository(
        ILogger<RepositoryBase<Quota>> logger,
        DbContext DbContext)
        : base(logger, DbContext)
    {
    }
}
