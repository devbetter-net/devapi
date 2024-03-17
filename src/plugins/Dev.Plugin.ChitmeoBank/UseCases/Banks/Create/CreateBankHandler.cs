using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;

namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.Create;

public class CreateBankHandler : ICommandHandler<CreateBankCommand, Result<Guid>>
{
    private readonly IRepository<Bank> _bankRepository;

    public CreateBankHandler(IRepository<Bank> bankRepository)
    {
        _bankRepository = bankRepository;
    }
    
    public async Task<Result<Guid>> Handle(CreateBankCommand request,
                                     CancellationToken cancellationToken)
    {
       var newBank = new Bank(request.Name, request.IsActive);
       var createdBank = await _bankRepository.AddAsync(newBank);
       return createdBank.Id;
    }
}
