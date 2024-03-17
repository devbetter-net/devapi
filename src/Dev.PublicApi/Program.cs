using Dev.Core.SharedKernel;
using Dev.Plugin.ChitmeoBank;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.AddChitmeoBank();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

const string CORS_POLICY = "CorsPolicy";
var corsOrigins = builder.Configuration.GetSection("CorsWithOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins(corsOrigins);
            corsPolicyBuilder.AllowAnyMethod();
            corsPolicyBuilder.AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(CORS_POLICY);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
