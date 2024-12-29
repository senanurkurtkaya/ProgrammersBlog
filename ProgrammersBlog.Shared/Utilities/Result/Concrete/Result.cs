using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Result.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus ResultStatus)
        {
            ResultStatus = ResultStatus;
        }

        public Result(ResultStatus ResultStatus , string message)
        {
            ResultStatus = ResultStatus;
            Message = message;
        }

        public Result(ResultStatus ResultStatus, string message ,Exception exception)
        {
            ResultStatus = ResultStatus;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get;  }

        public string Message { get; }

        public Exception Exception { get; }
        Exception IResult.Exception { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
