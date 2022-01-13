using IntelligentInvestor.Application.Repositorys.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Domain.Options;

public class GenericOptionRepository : RepositoryBase<GenericOption>, IGenericOptionRepository
{
    public GenericOptionRepository(
        ILogger<GenericOptionRepository> logger,
        DbContext DbContext)
        : base(logger, DbContext)
    {
    }

    public async Task<GenericOption?> QueryGenericOption(string optionName, string owner = null, string category = null)
        => await this.Set()
            .Where(
                o => (o.OptionName == optionName) &&
                (string.IsNullOrEmpty(o.OwnerLevel) || o.OwnerLevel == owner) &&
                (string.IsNullOrEmpty(o.Category) || o.Category == category))
            .OrderByDescending(o => o.OwnerLevel)
            .ThenByDescending(o => o.Category)
            .FirstOrDefaultAsync();
}
