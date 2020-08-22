using SMS_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Models
{
    public class Response
    {
        public Info Info { get; set; }
        public long Id { get; set; }
        public long Number { get; set; }
        public string LastCode { get; set; }
        public string Code { get; set; }
    }
}
