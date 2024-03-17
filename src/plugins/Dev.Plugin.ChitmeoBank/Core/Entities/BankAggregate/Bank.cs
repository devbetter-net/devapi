using Dev.Core.SharedKernel;

namespace Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;

public class Bank : EntityBase, IAggregateRoot
{
    public Bank(string name)
    {
        Name = name;
        IsActive = true;
    }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
}
