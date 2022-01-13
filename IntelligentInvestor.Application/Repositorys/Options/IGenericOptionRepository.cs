using IntelligentInvestor.Application.Repositorys.Abstractions;

namespace IntelligentInvestor.Domain.Options;

public interface IGenericOptionRepository : IRepositoryBase<GenericOption>
{
    Task<GenericOption?> QueryGenericOption(string optionName, string owner = null, string category = null);
}
