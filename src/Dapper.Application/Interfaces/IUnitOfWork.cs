namespace Dapper.Application {
  public interface IUnitOfWork {
    IProductRepository Products { get; }
  }
}