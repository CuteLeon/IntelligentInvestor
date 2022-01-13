using IntelligentInvestor.Application.Repositorys.Abstractions;

namespace IntelligentInvestor.Domain.Options;

public interface IGenericOptionRepository : IRepositoryBase<GenericOption>
{
    Task<GenericOption> AddOrUpdateGenericOptionAsync(GenericOption option);

    Task<GenericOption?> GetGenericOptionAsync(string optionName, string owner = null, string category = null);
}
