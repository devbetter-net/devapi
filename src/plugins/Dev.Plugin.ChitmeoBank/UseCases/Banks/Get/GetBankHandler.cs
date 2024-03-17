using Dev.Core.Result;
using Dev.Core.SharedKernel;
using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;
using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate.Specifications;

namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.Get;

public class GetBankHandler : IQueryHandler<GetBankQuery, Result<BankDto>>
{
    private readonly IReadRepository<Bank> _bankRepository;

    public GetBankHandler(IReadRepository<Bank> bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public async Task<Result<BankDto>> Handle(GetBankQuery request, CancellationToken cancellationToken)
    {
        var specBank = new BankByIdSpec(request.BankId);
        var entity = await _bankRepository.FirstOrDefaultAsync(specBank, cancellationToken);
        if (entity == null) return Result.NotFound();
        return Result.Success(new BankDto(entity.Id, entity.Name, entity.IsActive));
    }
}
