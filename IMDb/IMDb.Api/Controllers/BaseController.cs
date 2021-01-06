using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IMDb.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected List<string> GetErrorListFromModelState()
        {
            var errors = new List<string>();
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                errors.Add(errorMsg);
            }
            return errors;
        }
    }
}
