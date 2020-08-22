using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sms_Service
{
    partial class Converts
    {
        internal static string StringToDictionary(Dictionary<string, object> dict)
        {
            string str = string.Empty;

            foreach (KeyValuePair<string, object> entry in dict)
            {
                if (entry.Value != null)
                {
                    if (str.Length > 0) str += "&";
                    if (entry.Value.ToString().Length == 0) continue;

                    var key = entry.Key != null ? entry.Key.ToString() : null;
                    var value = entry.Value != null ? entry.Value.ToString() : null;

                    int? bools = null;
                    try { if ((bool)entry.Value) bools = Convert.ToBoolean(entry.Value).GetHashCode(); value = null; } catch { }

                    str += key + "=" + value + bools;
                }
            }
            return str;
        }

        /// <summary>
        /// Сериализирует данные с класса в строку типа string 
        /// </summary>
        /// <param name="Serial">Что нужно привести в нормальный вид</param>
        /// <returns></returns>
        internal static string JsonSerializer(object Serial)
        {
            var Settings = new JsonSerializerSettings();
            Settings.DefaultValueHandling = DefaultValueHandling.Populate;
            return JsonConvert.SerializeObject(Serial, Settings);
        }

        /// <summary>
        /// Десериализирует данные с json в строку
        /// </summary>
        /// <returns></returns>
        internal static T JsonDeserializ<T>(string Deserial)
        {
            return JsonConvert.DeserializeObject<T>(Deserial);
        }
    }
}
