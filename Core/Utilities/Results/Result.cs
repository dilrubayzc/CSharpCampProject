using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Don't Repeat Yourself
        //ctor overload ' ını  yazmış olduk ve o yüzden bir daha ilk ctor da success ' i setlememize gerek kalmadı
        public Result(bool success,string message):this(success)
        {
            Message= message;
        }
        public Result(bool success)
        {
            Success = success;  
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
