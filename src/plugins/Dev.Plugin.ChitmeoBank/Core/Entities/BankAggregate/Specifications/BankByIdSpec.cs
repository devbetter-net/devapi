using Dev.Core.Specification;
using Dev.Core.Specification.Builder;

namespace Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate.Specifications;

public class BankByIdSpec : Specification<Bank>
{
    public BankByIdSpec(Guid bankId)
    {
        this.Query.Where(bank => bank.Id == bankId);
    }
}
