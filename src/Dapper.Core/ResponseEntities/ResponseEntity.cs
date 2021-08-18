using System;
using System.Collections.Generic;

namespace Dapper.Core.Response.Entities {
  public class ResponseEntity<T> {
    public T Entity { get; set; }
    public DateTime OnDateTime { get; } = DateTime.Now;
    public List<string> Messages { get; set; }
    public int TotalRows;
    public int PageSize;

    public ResponseEntity () {
      Messages = new List<string> ();
      TotalRows = 0;
      PageSize = 0;
    }
  }
}