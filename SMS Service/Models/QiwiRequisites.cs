using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Models
{
    public class QiwiRequisites
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("wallet")]
        public string Wallet { get; set; }
        [JsonProperty("upToDate")]
        public DateTime UpToDate { get; set; }
        [JsonProperty("Comment")]
        public string Comment { get; set; }
    }
}
