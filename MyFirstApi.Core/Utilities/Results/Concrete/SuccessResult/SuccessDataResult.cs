using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstApi.Core.Utilities.Results.Concrete.SuccessResult;

public class SuccessDataResult<T> : DataResult<T>
{

    public SuccessDataResult(T data,  HttpStatusCode status) : base(data, true, status)
    {
    }

    public SuccessDataResult(T data,  HttpStatusCode status, string message) : base(data, true, status, message)
    {
    }
}
