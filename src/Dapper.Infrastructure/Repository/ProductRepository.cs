using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Application;
using Dapper.Contrib.Extensions;
using Dapper.Core.Entities;
using Dapper.Core.Request.Entities;
using Microsoft.Extensions.Configuration;

namespace Dapper.Infrastructure.Repository {
  public class ProductRepository : IProductRepository {
    private readonly IConfiguration _configuration;
    private SqlConnection _connection;
    public ProductRepository (IConfiguration configuration) {
      _configuration = configuration;
      _connection = new SqlConnection (configuration.GetConnectionString ("DefaultConnection"));
    }
    public async Task<int> AddAsync (Product entity) {
      var result = await _connection.InsertAsync (entity);

      return result;
    }

    public async Task<int> DeleteAsync (int id) {
      var result = await _connection.DeleteAsync (new Product { Id = id });

      return id;
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync () {
      var result = await _connection.GetAllAsync<Product> ();
      return result.ToList ();
    }

    public async Task<IReadOnlyList<Product>> GetAllByCriteriaAsync (CriteriaProduct criteria) {
      var sql = @"SELECT * FROM Products WHERE 1 = 1 ";

      if (!string.IsNullOrEmpty (criteria.Name)) {
        sql += " AND Name LIKE CONCAT('%', @Name, '%')";
      }

      var result = await _connection.QueryAsync<Product> (sql, criteria);

      return result.ToList ();
    }

    public async Task<Product> GetByIdAsync (int id) {
      var result = await _connection.GetAsync<Product> (id);

      return result;
    }

    public async Task<int> UpdateAsync (Product entity) {
      var result = await _connection.UpdateAsync (entity);

      return entity.Id;
    }
  }
}