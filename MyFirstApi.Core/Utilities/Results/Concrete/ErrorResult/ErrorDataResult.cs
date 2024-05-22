using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstApi.Core.Utilities.Results.Concrete.ErrorResult;

public class ErrorDataResult<T> : DataResult<T>
{

    public ErrorDataResult(T data,  HttpStatusCode status) : base(data, true, status)
    {
    }

    public ErrorDataResult(T data,  HttpStatusCode status, string message) : base(data, true, status, message)
    {
    }  
}
