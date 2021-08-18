using System;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Core.Request.Entities {
  public class CreateProduct {
    public int Id { get; set; } = 0;

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Barcode { get; set; }
    public decimal Rate { get; set; }
    public DateTime? AddedOn { get; set; }
  }

  public class UpdateProduct {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Barcode { get; set; }
    public decimal Rate { get; set; }
    public DateTime? AddedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
  }

  public class CriteriaProduct : Pagination {

    public string Name { get; set; }

  }

}