namespace Dev.Plugin.ChitmeoBank.UseCases.Banks.List;

public interface IListBanksQueryService
{
    Task<IEnumerable<BankDto>> ListAsync(int? skip, int? take);
}
