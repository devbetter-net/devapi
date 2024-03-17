
namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.List;

public class ListBanksHandler : IQueryHandler<ListBanksQuery, Result<IEnumerable<BankDto>>>
{
    private readonly IListBanksQueryService _query;

    public ListBanksHandler(IListBanksQueryService query)
    {
        _query = query;
    }

    public async Task<Result<IEnumerable<BankDto>>> Handle(ListBanksQuery request, CancellationToken cancellationToken)
    {
        var result = await _query.ListAsync(request.Skip, request.Take);
        return Result.Success(result);
    }
}
