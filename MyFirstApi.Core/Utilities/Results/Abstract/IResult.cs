using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyFirstApi.Core.Utilities.Results.Abstract;

public interface IResult
{
    public bool Success { get; set; }
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
}
