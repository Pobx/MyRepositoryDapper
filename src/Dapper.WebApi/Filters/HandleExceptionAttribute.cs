using System;
using Dapper.Core.Response.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dapper.WebApi.Filters {
  public class HandleExceptionAttribute : ExceptionFilterAttribute {

    public override void OnException (ExceptionContext context) {
      var response = new ResponseEntity<string> ();

      response.Messages.Add (context.Exception.Message);
      context.Result = new ObjectResult (response) {
        StatusCode = 500
      };

      context.ExceptionHandled = true;

    }
  }
}