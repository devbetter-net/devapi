using Dev.Core.Specification.EntityFrameworkCore;

namespace Dev.Plugin.ChitmeoBank.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(BankDbContext dbContext) : base(dbContext)
  {
  }
}