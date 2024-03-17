using Dev.Core.Result;

namespace Dev.Plugin.ChitmeoBank.Core.Interfaces.Banks;

public interface IDeleteBankService
{
    public Task<Result> DeleteBank(Guid bankId);
}
