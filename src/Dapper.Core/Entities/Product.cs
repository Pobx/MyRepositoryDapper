using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Dapper.Core.Entities {
  [Table ("Products")]
  public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Barcode { get; set; }
    public decimal Rate { get; set; }
    public DateTime? AddedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
  }
}