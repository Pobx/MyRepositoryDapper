namespace Dapper.Core.Request.Entities {
  public class Pagination {
    public int CurrentPageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;

  }
}