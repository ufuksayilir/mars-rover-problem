using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProblem.Responses
{
    public class ResponseBase
    {
        public bool IsOk { get; set; } = false;

        public string Message { get; set; } = "";
    }
}
