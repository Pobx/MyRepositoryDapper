using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Application;
using Dapper.Core.Entities;
using Dapper.Core.Request.Entities;
using Dapper.Core.Response.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers {
  [ApiController]
  [Route ("api/[controller]")]
  public class ProductController : ControllerBase {
    private readonly IUnitOfWork _unitOfWork;
    public ProductController (IUnitOfWork unitOfWork) {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll () {
      var response = new ResponseEntity<IEnumerable<Product>> ();
      var result = await _unitOfWork.Products.GetAllAsync ();

      response.Entity = result;
      response.TotalRows = result.Count ();

      return Ok (response);
    }

    [HttpGet ("GetAllByCriteriaAsync")]
    public async Task<IActionResult> GetAllByCriteriaAsync ([FromQuery] CriteriaProduct criteria) {
      var response = new ResponseEntity<IEnumerable<Product>> ();
      var result = await _unitOfWork.Products.GetAllByCriteriaAsync (criteria);

      response.Entity = result.Skip ((criteria.CurrentPageIndex - 1) * criteria.PageSize).Take (criteria.PageSize).ToList ();
      response.TotalRows = result.Count ();
      response.PageSize = criteria.PageSize;

      return Ok (response);
    }

    [HttpGet ("{id:int}")]
    public async Task<IActionResult> GetById (int id) {
      var response = new ResponseEntity<Product> ();
      response.Entity = await _unitOfWork.Products.GetByIdAsync (id);

      if (response.Entity == null) {
        return NoContent ();
      }

      return Ok (response);
    }

    [HttpPost]
    public async Task<IActionResult> Add ([FromBody] CreateProduct createProduct) {
      var response = new ResponseEntity<Product> ();
      var product = new Product {
        Name = createProduct.Name,
        Description = createProduct.Description,
        Barcode = createProduct.Barcode,
        Rate = createProduct.Rate,
        AddedOn = DateTime.Now
      };

      product.Id = await _unitOfWork.Products.AddAsync (product);
      response.Entity = product;

      return Ok (response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete (int id) {
      var response = new ResponseEntity<Product> ();
      await _unitOfWork.Products.DeleteAsync (id);

      return NoContent ();
    }

    [HttpPut]
    public async Task<IActionResult> Update ([FromBody] UpdateProduct updateProduct) {
      var response = new ResponseEntity<Product> ();
      var product = new Product {
        Id = updateProduct.Id,
        Name = updateProduct.Name,
        Description = updateProduct.Description,
        Barcode = updateProduct.Barcode,
        Rate = updateProduct.Rate,
        AddedOn = updateProduct.AddedOn,
        ModifiedOn = DateTime.Now
      };

      await _unitOfWork.Products.UpdateAsync (product);
      response.Entity = product;

      return Ok (response);
    }

  }
}