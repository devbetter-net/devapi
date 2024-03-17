using Dev.Core.SharedKernel;

namespace Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;

public class Bank : EntityBase, IAggregateRoot
{
    public Bank(string name, bool isActive)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsActive = isActive;
    }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
}
