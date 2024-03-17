

using System.Reflection;
using Dev.Plugin.ChitmeoBank.Core.Entities.BankAggregate;
using Dev.Plugin.ChitmeoBank.UseCases.Banks.Create;
using Dev.Plugin.ChitmeoBank.UseCases.Banks.List;

namespace Dev.Plugin.ChitmeoBank;

public static class WebApplicationExtensions
{
    public static void AddChitmeoBank(this WebApplicationBuilder builder)
    {
        builder.ConfigureMediatR();
        builder.RegisterDatabase();
        builder.RegisterServices();
    }
    private static void ConfigureMediatR(this WebApplicationBuilder builder)
    {
        var mediatRAssemblies = new[]
            {
            Assembly.GetAssembly(typeof(Bank)), // Core
            Assembly.GetAssembly(typeof(CreateBankCommand)) // UseCases
            };
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
    }
    private static void RegisterDatabase(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("BankConnection")!;
        //mysql
        builder.Services.AddDbContext<BankDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );
    }
    private static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        builder.Services.AddScoped<IListBanksQueryService, ListBanksQueryService>();
        builder.Services.AddScoped<IDeleteBankService, DeleteBankService>();
    }
}
