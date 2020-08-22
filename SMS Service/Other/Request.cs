using Sms_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Other
{
    public class Request
    {
        private HttpClient _httpClient = new HttpClient();

        internal async Task<string> PostAsync(string link, Dictionary<string, string> requestContent)
        {
            HttpContent content = new FormUrlEncodedContent(requestContent);
            var Response = await _httpClient.PostAsync(link, content);
            return await ToText(Response);
        }

        internal async Task<string> PostAsync(string link, KeyValuePair<string, string>[] requestContent)
        {
            HttpContent content = new FormUrlEncodedContent(requestContent);
            var Response = await _httpClient.PostAsync(link, content);
            return await ToText(Response);
        }

        internal async Task<string> GetAsync(string link, Dictionary<string, object> requestContent)
        {
            var Response = await _httpClient.GetAsync(link +"?" + Converts.StringToDictionary(requestContent));
            return await ToText(Response);
        }

        internal async Task<string> ToText(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }
    }
}
