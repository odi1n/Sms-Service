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
    public class SmsActivate
    {
        public string ApiKey { get; private set; }
        public Info Info { get; private set; }
        private bool _infoException { get; set; }

        private const string _ref = "";
        private const string _mainLink = "https://sms-activate.ru/stubs/handler_api.php";
        private Request _request = new Request();

        public delegate void Answer(object e, Response response);
        public event Answer GetAnswer;

        public SmsActivate(string apiKey, bool infoException = true)
        {
            this.ApiKey = apiKey;
            this._infoException = infoException;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        /// <summary>
        /// Запрос количества доступных номеров
        /// </summary>
        /// <param name="country">страна номера смотрите таблицу</param>
        /// <param name="opertator">сотовый оператор номера, можно указывать несколько через запятую (доступно только для **)</param>
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
        /// Запрос баланса вместе с кэшбэк-счетом:
        /// </summary>
        /// <returns></returns>
        public async Task<Response> GetBalanceAndCashBackAsync()
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getBalanceAndCashBack",
            });

            CheckError(data);
            return GetResponse(data);
        }

        /// <summary>
        /// Заказ номера
        /// </summary>
        /// <param name="service">сервис для заказа смотрите таблицу</param>
        /// <param name="forward">необходимо ли запросить номер с переадресацией</param>
        /// <param name="phoneException">сключающие префиксы для номеров России. Указывать через запятую. Формат записи: код страны и от 3 до 6 цифр маски ( например 7918,7900111). По умолчанию берётся значение, заданное в левом меню.</param>
        /// <param name="operators">сотовый оператор номера, можно указывать несколько через запятую (доступно только для **)</param>
        /// <param name="country">страна номера смотрите таблицу</param>
        /// <returns></returns>
        public async Task<Response> GetNumberAsync(string service, bool forward = false, List<string> phoneException = null, string operators = null, int? country = null)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getNumber",
                ["service"] = service.GetValue(),
                ["forward"] = forward.ToInt32String(),
                ["phoneException"] = phoneException.ToString(),
                ["operator"] = operators.GetValue(),
                ["ref"] = _ref,
                ["country"] = country.GetValue(),
            });

            CheckError(data);
            return GetResponse(data);
        }

        /// <summary>
        /// Заказ номера для нескольких сервисов
        /// </summary>
        /// <param name="service">сервисы для заказа. Указывать через запятую, например "vk,ok,vi,av" смотрите таблицу</param>
        /// <param name="forward">необходимо ли запросить номер с переадресацией</param>
        /// <param name="operators">сотовый оператор номера, можно указывать несколько через запятую (доступно только для **)</param>
        /// <param name="country">страна номера смотрите таблицу</param>
        /// <returns></returns>
        public async Task<Response> GetMultiServiceNumber(List<string> service, bool forward = false,  List<string> operators = null, int? country = null)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getMultiServiceNumber",
                ["service"] = service.ToStrings(),
                ["forward"] = forward.ToInt32String(),
                ["operator"] = operators.ToStrings(),
                ["ref"] = _ref,
                ["country"] = country.GetValue(),
            });

            CheckError(data);
            return GetResponse(data);
        }

        /// <summary>
        /// Изменение статуса активации
        /// </summary>
        /// <param name="id">id активации</param>
        /// <param name="status">статус активации</param>
        /// <param name="forward">номер телефона на который нужно выполнить переадресаци</param>
        /// <returns></returns>
        public async Task<Info> SetStatusAsync(long id, Status status, bool forward = false)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "setStatus",
                ["status"] = status.ToString(),
                ["id"] = id.ToString(),
                ["forward"] = forward.ToInt32String(),
            });

            CheckError(data);
            return data.ToInfo();
        }

        /// <summary>
        /// Получить состояние активации
        /// </summary>
        /// <param name="id">id активации</param>
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
                else if(infoStatus.Info == Info.STATUS_WAIT_RESEND)
                    GetAnswer?.Invoke(this, infoStatus);
                else if (infoStatus.Info == Info.STATUS_CANCEL || infoStatus.Info == Info.STATUS_OK)
                    GetAnswer?.Invoke(this, infoStatus); break;
            }
            return infoStatus;
        }

        /// <summary>
        /// Получить актуальные цены по странам
        /// </summary>
        /// <param name="service">краткое наименование сервиса (необязательно, по умолчанию все сервисы) смотрите таблицу</param>
        /// <param name="country">кодовое наименование страны (необязательно, по умолчанию все страны) смотрите таблицу</param>
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
        /// Получить актуальный кошелек пополнения для Qiwi
        /// </summary>
        /// <returns></returns>
        public async Task<QiwiRequisites> GetQiwiRequisites()
        {
            var data = await _request.GetAsync(_mainLink, new Dictionary<string, object>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getQiwiRequisites",
            });

            return Converts.JsonDeserializ<QiwiRequisites>(data);
        }

        /// <summary>
        /// Дополнительный сервис для номеров с переадресацией
        /// </summary>
        /// <param name="service">краткое наименование сервиса смотрите таблицу</param>
        /// <param name="id">ID родительской активации</param>
        /// <returns></returns>
        public async Task<Response> GetAdditionalService(string service, int id)
        {
            var data = await _request.PostAsync(_mainLink, new Dictionary<string, string>()
            {
                ["api_key"] = ApiKey,
                ["action"] = "getAdditionalService",
                ["service"] = service.GetValue(),
                ["ref"] = _ref,
                ["id"] = id.ToString(),
            });

            CheckError(data);
            return GetResponse(data);
        }

        private Response GetResponse(string data)
        {
            var split = data.Split(':');
            var info = split[0].ToInfo();

            if (info == Info.STATUS_WAIT_RETRY)
                return new Response(){Info = info,LastCode = split[1]};
            else if (info == Info.STATUS_OK)
                return new Response(){Info = info,Code = split[1]};
            else if (info == Info.STATUS_WAIT_CODE || info == Info.STATUS_CANCEL || info == Info.STATUS_CANCEL)
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
            if (data.Contains("BAD") || data.Contains("ERROR") || data.Contains("BANNED") || data.Contains("WRONG_EXCEPTION_PHONE"))
            {
                if (_infoException)
                    throw new ErrorParamsException(data);
                else
                    Info = data.ToInfo();
            }
        }
    }
}
