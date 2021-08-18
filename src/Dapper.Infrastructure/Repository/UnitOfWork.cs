using Dapper.Application;

namespace Dapper.Infrastructure.Repository {
    public class UnitOfWork : IUnitOfWork {
      public UnitOfWork(IProductRepository productRepoisitory) {
        Products = productRepoisitory;
      }
      public IProductRepository Products { get; }
    }
}