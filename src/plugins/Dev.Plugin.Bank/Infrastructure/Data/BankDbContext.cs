using System.Reflection;
using Dev.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Bank.Infrastructure.Data;

public class BankDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public BankDbContext(DbContextOptions<BankDbContext> options,
       IDomainEventDispatcher? dispatcher)
         : base(options)
    {
        _dispatcher = dispatcher;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_dispatcher == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges() =>
          SaveChangesAsync().GetAwaiter().GetResult();
}
