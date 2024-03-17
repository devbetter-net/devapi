global using Dev.Core.SharedKernel;
global using Dev.Core.Result;
global using Dev.Core.GuardClauses;
global using Dev.Core.Specification;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using Dev.Plugin.ChitmeoBank.Core.Interfaces.Banks;
global using Dev.Plugin.ChitmeoBank.Core.Services.Banks;
global using Dev.Plugin.ChitmeoBank.Infrastructure.Data;
global using Dev.Plugin.ChitmeoBank.Infrastructure.Data.Queries.Banks;

global using Dev.Plugin.ChitmeoBank.UseCases.Banks;