using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Core.Entities;
using Dapper.Core.Request.Entities;

namespace Dapper.Application {
  public interface IProductRepository : IGenericRepository<Product>
  {
    Task<IReadOnlyList<Product>> GetAllByCriteriaAsync (CriteriaProduct criteria);
  }
}