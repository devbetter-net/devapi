using Dev.Core.SharedKernel;

namespace Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate.Events;
/// <summary>
/// A domain event that is dispatched whenever a bank is deleted.
/// The DeleteBankService is used to dispatch this event.
/// </summary>
internal sealed class BankDeletedEvent : DomainEventBase
{
    public BankDeletedEvent(Guid bankId)
    {
        BankId = bankId;
    }
    public Guid BankId { get; init; }
}
