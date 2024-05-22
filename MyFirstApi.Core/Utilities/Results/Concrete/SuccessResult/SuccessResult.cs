using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstApi.Core.Utilities.Results.Concrete.SuccessResult;

public class SuccessResult : Result
{
    public SuccessResult(HttpStatusCode status) : base(true, status)
    {
    }
    public SuccessResult(HttpStatusCode status, string message) : base(true, status, message)
    {
    }
}
