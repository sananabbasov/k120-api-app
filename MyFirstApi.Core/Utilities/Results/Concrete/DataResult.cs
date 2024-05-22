using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MyFirstApi.Core.Utilities.Results.Abstract;

namespace MyFirstApi.Core.Utilities.Results.Concrete;

public class DataResult<T> : Result, IDataResult<T>
{

    public T Data { get; set; }


    public DataResult(T data, bool success, HttpStatusCode status, string message) : base(success, status, message)
    {
        Data = data;
    }
    public DataResult(T data, bool success, HttpStatusCode status) : base(success, status)
    {
        Data = data;
    }
}
