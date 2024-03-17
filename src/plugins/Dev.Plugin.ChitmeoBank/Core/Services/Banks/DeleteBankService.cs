using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;
using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dev.Plugin.ChitmeoBank.Core.Services.Banks;

public class DeleteBankService : IDeleteBankService
{
    private readonly IRepository<Bank> _bankRepository;
    private readonly IMediator _mediator;
    private readonly ILogger<DeleteBankService> _logger;
    public DeleteBankService(IRepository<Bank> bankRepository,
                             IMediator mediator,
                             ILogger<DeleteBankService> logger)
    {
        _bankRepository = bankRepository;
        _mediator = mediator;
        _logger = logger;
    }
    public async Task<Result> DeleteBank(Guid bankId)
    {
        _logger.LogInformation("Deleting Bank {bankId}", bankId);
        var bankToDelete = await _bankRepository.GetByIdAsync(bankId);
        if (bankToDelete == null) return Result.NotFound();
        await _bankRepository.DeleteAsync(bankToDelete);
        var domainEvent = new BankDeletedEvent(bankId);
        await _mediator.Publish(domainEvent);
        return Result.Success();
    }
}
