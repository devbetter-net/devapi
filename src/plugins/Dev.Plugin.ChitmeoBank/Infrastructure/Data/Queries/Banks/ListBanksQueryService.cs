namespace Dev.Plugin.ChitmeoBank.Infrastructure.Data.Queries.Banks;
public class ListBanksQueryService : IListBanksQueryService
{
    private readonly BankDbContext _dbContext;

    public ListBanksQueryService(BankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<BankDto>> ListAsync(int? skip, int? take)
    {
        var query = _dbContext.Banks.AsQueryable();

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }
        query = query.OrderBy(bank => bank.Name);

        var result = await query.Select(bank => new BankDto(bank.Id, bank.Name, bank.IsActive)).ToListAsync();
        return result;
    }
}
