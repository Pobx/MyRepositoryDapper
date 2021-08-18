using System;
using Dapper.Application;
using Dapper.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Infrastructure {
  public static class ServiceRegistration {
    public static void AddInfrastructure (this IServiceCollection service) {
      service.AddScoped<IProductRepository, ProductRepository> ();
      service.AddScoped<IUnitOfWork, UnitOfWork> ();
    }
  }
}