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

    public async Task<GenericOption?> GetGenericOptionAsync(string optionName, string owner = null, string category = null)
        => await this.Set()
            .Where(
                o => (o.OptionName == optionName) &&
                (string.IsNullOrEmpty(o.OwnerLevel) || o.OwnerLevel == owner) &&
                (string.IsNullOrEmpty(o.Category) || o.Category == category))
            .OrderByDescending(o => o.OwnerLevel)
            .ThenByDescending(o => o.Category)
            .FirstOrDefaultAsync();

    public async Task<GenericOption> AddOrUpdateGenericOptionAsync(GenericOption option)
    {
        if (await this.Set().AnyAsync(x =>
            x.OptionName == option.OptionName &&
            x.OwnerLevel == option.OwnerLevel &&
            x.Category == option.Category))
            return await this.UpdateAsync(option);
        else
            return await this.AddAsync(option);
    }
}
