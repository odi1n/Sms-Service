using SMS_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms_Service.Exceptions
{
    [Serializable]
    public class ErrorParamsException : System.Exception
    {
        private Info Info;
        public ErrorParamsException(string Message) : base(Message) {

            var info = Enum.TryParse<Info>(Message, out Info);
        }
    }
}
