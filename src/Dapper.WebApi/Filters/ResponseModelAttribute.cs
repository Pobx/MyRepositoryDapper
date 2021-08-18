using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Core.Response.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dapper.WebApi.Filters {
  public class ResponseModelAttribute : ResultFilterAttribute {
    public override void OnResultExecuting (ResultExecutingContext context) {

      var response = new ResponseEntity<object> ();
      response.Entity = null;

      if (!context.ModelState.IsValid) {
        var errorMessages = context.ModelState.Values.SelectMany (value => value.Errors).Select (value => value.ErrorMessage);
        response.Messages = errorMessages.ToList ();
        context.Result = new BadRequestObjectResult (response);
      }
    }
  }
}