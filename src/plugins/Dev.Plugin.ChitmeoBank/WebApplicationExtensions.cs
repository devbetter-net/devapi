

namespace Dev.Plugin.ChitmeoBank;

public static class WebApplicationExtensions
{
    public static void AddChitmeoBank(this WebApplicationBuilder builder)
    {
        builder.RegisterDatabase();
        builder.RegisterServices();
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
