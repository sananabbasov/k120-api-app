using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstApi.Core.Utilities.Results.Concrete.ErrorResult;

public class ErrorResult: Result
{
    public ErrorResult(HttpStatusCode status) : base(false, status)
    {
    }
    public ErrorResult(HttpStatusCode status, string message) : base(false, status, message)
    {
    }
}
