using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;

namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.Update;

public class UpdateBankHandler : ICommandHandler<UpdateBankCommand, Result<BankDto>>
{
    private readonly IRepository<Bank> _bankRepository;

    public UpdateBankHandler(IRepository<Bank> bankRepository)
    {
        _bankRepository = bankRepository;
    }

    public async Task<Result<BankDto>> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        var existingBank = await _bankRepository.GetByIdAsync(request.BankId);
        if (existingBank == null) return Result.NotFound();
        existingBank.UpdateName(request.Name);
        existingBank.UpdateActiveStatus(request.IsActive);

        await _bankRepository.UpdateAsync(existingBank, cancellationToken);
        return Result.Success(new BankDto(existingBank.Id, existingBank.Name, existingBank.IsActive));
    }
}
