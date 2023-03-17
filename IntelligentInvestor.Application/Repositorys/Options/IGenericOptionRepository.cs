using IntelligentInvestor.Application.Repositorys.Abstractions;
using IntelligentInvestor.Domain.Options;

namespace IntelligentInvestor.Application.Repositorys.Options;

public interface IGenericOptionRepository : IRepositoryBase<GenericOption>
{
    Task<GenericOption> AddOrUpdateGenericOptionAsync(GenericOption option);

    Task<GenericOption?> GetGenericOptionAsync(string optionName, string owner = null, string category = null);
}
