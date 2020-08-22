using Sms_Service;
using Sms_Service.Exceptions;
using SMS_Service.Enums;
using SMS_Service.Models;
using SMS_Service.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service
{
    public class SmsHub
    {
        public string ApiKey { get; private set; }
        public Info Info { get; private set; }
        private bool _infoException { get; set; }

        private const string _mainLink = "https://smshub.org/stubs/handler_api.php";
        private Request _request = new Request();

        public delegate void Answer(object e, Response response);
        public event Answer GetAnswer;

        public SmsHub(string apiKey, bool infoException = true)
        {
            this.ApiKey = apiKey;
            this._infoException = infoException;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        /// <summary>
        /// Запрос количества доступных номеров
        /// </summary>
        /// <param name="country">Страна номера, если не задан, то будет выбран номер той страны, которая последний раз была выбрана в левом меню</param>
        /// <param name="opertator">Оператор номера, если не задан, то будет выбран тот оператор, который последний раз была выбран в левом меню</param>
        /// <returns></returns>
        public async Task<NumberStatus> GetNumberStatusAsync(int? country = null, string opertator = null)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"]=ApiKey,
                ["action"] = "getNumbersStatus",
                ["country"] = country.GetValue(),
                ["operator"] = opertator.GetValue(),
            });
            return Converts.JsonDeserializ<NumberStatus>(data);
        }

        /// <summary>
        /// Запрос баланса
        /// </summary>
        /// <returns></returns>
        public async Task<Response> GetBalanceAsync()
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getBalance",
            });

            CheckError(data);
            return GetResponse(data);
        }

        /// <summary>
        /// Заказать номер телефона
        /// </summary>
        /// <param name="service">Сервис, номер для которого необходимо получить</param>
        /// <param name="operators">Сотовый оператор номер которого необходимо получить</param>
        /// <param name="country">Страна номер которой необходимо получить</param>
        /// <returns></returns>
        public async Task<Response> GetNumberAsync(string service, string operators = null, int? country = null)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getNumber",
                ["service"] = service.GetValue(),
                ["operator"] = operators.GetValue(),
                ["country"] = country.GetValue(),
            });

            CheckError(data);
            return GetResponse(data);
        }

        /// <summary>
        /// Изменить статус
        /// </summary>
        /// <param name="id">ID активации, полученное при запросе номера</param>
        /// <param name="status">Статус который необходимо передать активации</param>
        /// <returns></returns>
        public async Task<Info> SetStatusAsync(long id , Status status)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "setStatus",
                ["id"] = id.ToString(),
                ["status"] = status.ToString(),
            });

            CheckError(data);
            return data.ToInfo();
        }

        /// <summary>
        /// Получить ответ статуса. Получить сразу ответ
        /// </summary>
        /// <param name="id">ID активации, полученное при запросе номера</param>
        /// <returns></returns>
        public async Task<Response> CheckStatusAsync(long id)
        {
            Response infoStatus;
            while (true)
            {
                infoStatus = await GetStatusAsync(id);

                if (infoStatus.Info == Info.STATUS_WAIT_CODE)
                    continue;
                else if (infoStatus.Info == Info.STATUS_WAIT_CODE)
                    GetAnswer?.Invoke(this, infoStatus);
                else if (infoStatus.Info == Info.STATUS_CANCEL || infoStatus.Info == Info.STATUS_OK)
                    GetAnswer?.Invoke(this, infoStatus); break;
            }
            return infoStatus;
        }

        /// <summary>
        /// Получить статус
        /// </summary>
        /// <param name="id">ID активации, полученное при запросе номера</param>
        /// <returns></returns>
        public async Task<Response> GetStatusAsync(long id)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getStatus",
                ["id"] = id.ToString(),
            });

            CheckError(data);

            return GetResponse(data);
        }

        /// <summary>
        /// Запросить все цены
        /// </summary>
        /// <param name="service">Сервис, номер для которого необходимо получить</param>
        /// <param name="country">Страна номера</param>
        /// <returns></returns>
        public async Task<Dictionary<int, Price>> GetPriceAsync(string service = null,  int? country = null)
        {
            var data = await _request.GetAsync(_mainLink, new Dictionary<string, object>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getPrices",
                ["service"] = service.GetValue(),
                ["country"] = country.GetValue(),
            });

            return Converts.JsonDeserializ<Dictionary<int, Price>>(data);
        }

        /// <summary>
        /// Запросить все цены, запрос с сайта
        /// </summary>
        /// <param name="country">Страна номера</param>
        /// <returns></returns>
        public async Task<NumbersStatusAndCostHubFree> GetNumbersStatusAndCostHubFreeAsync(int? country = null)
        {
            var data = await _request.GetAsync(_mainLink, new Dictionary<string, object>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getNumbersStatusAndCostHubFree",
                ["country"] = country.GetValue(),
            });

            return Converts.JsonDeserializ<NumbersStatusAndCostHubFree>(data);
        }

        private Response GetResponse(string data)
        {
            var split = data.Split(':');
            var info = split[0].ToInfo();

            if (info == Info.STATUS_WAIT_RETRY)
                return new Response(){Info = info,LastCode = split[1]};
            else if (info == Info.STATUS_OK)
                return new Response(){Info = info,Code = split[1]};
            else if (info == Info.STATUS_WAIT_CODE || info == Info.STATUS_CANCEL)
                return new Response() { Info = info };

            return new Response()
            {
                Info = info,
                Id = Convert.ToInt64(split[1]),
                Number = Convert.ToInt64(split[2])
            };
        }

        private void CheckError(string data)
        {
            if (data.Contains("BAD") || data.Contains("ERROR") || data.Contains("NO_ACTIVATION"))
            {
                if (_infoException)
                    throw new ErrorParamsException(data);
                else
                    Info = data.ToInfo();
            }
        }
    }
}
