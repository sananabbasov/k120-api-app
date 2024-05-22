using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MyFirstApi.Core.Utilities.Results.Abstract;

namespace MyFirstApi.Core.Utilities.Results.Concrete;

public class Result : IResult
{
    public bool Success { get; set; }
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }

    public Result(bool success, HttpStatusCode status, string message)
    {
        Success = success;
        Status = status;
        Message = message;
    }

    public Result(bool success, HttpStatusCode status)
    {
        Success = success;
        Status = status;
    }
}


