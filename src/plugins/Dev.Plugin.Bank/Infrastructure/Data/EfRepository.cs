using Dev.Core.SharedKernel;
using Dev.Core.Specification.EntityFrameworkCore;

namespace Dev.Plugin.Bank.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(BankDbContext dbContext) : base(dbContext)
    {
    }
}
