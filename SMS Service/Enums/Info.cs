using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Enums
{
    public enum Info
    {
        /// <summary>
        /// BALANCE - Баланс вашего API-ключа
        /// </summary>
        ACCESS_BALANCE,
        /// <summary>
        /// Неверный API-ключ
        /// </summary>
        BAD_KEY,
        /// <summary>
        /// ошибка SQL-сервера
        /// </summary>
        ERROR_SQL,
        /// <summary>
        /// Общее неправильное формирование запроса
        /// </summary>
        BAD_ACTION,
        /// <summary>
        /// Нет номеров с заданными параметрами, попробуйте позже, или поменяйте оператора, страну.
        /// </summary>
        NO_NUMBERS,
        /// <summary>
        /// Закончились деньги на API-ключе
        /// </summary>
        NO_BALANCE,
        /// <summary>
        /// Не верный идентификатор сервиса
        /// </summary>
        WRONG_SERVICE,
        /// <summary>
        /// Получили номер, ID активации - ID, сам номер с кодом страны - NUMBER
        /// </summary>
        ACCESS_NUMBER,
        /// <summary>
        /// Готовность ожидания смс
        /// </summary>
        ACCESS_READY,
        /// <summary>
        /// Ожидаем новое смс
        /// </summary>
        ACCESS_RETRY_GET,
        /// <summary>
        /// Активация успешно завершена
        /// </summary>
        ACCESS_ACTIVATION,
        /// <summary>
        /// Активация отменена
        /// </summary>
        ACCESS_CANCEL,
        /// <summary>
        /// некорректное наименование сервиса
        /// </summary>
        BAD_SERVICE,
        /// <summary>
        /// id активации не существует
        /// </summary>
        NO_ACTIVATION,
        /// <summary>
        /// Ожидаем прихода смс
        /// </summary>
        STATUS_WAIT_CODE,
        /// <summary>
        /// Ожидаем еще одно смс, LASTCODE - последнее полученное смс
        /// </summary>
        STATUS_WAIT_RETRY,
        /// <summary>
        /// активация отменена
        /// </summary>
        STATUS_CANCEL,
        /// <summary>
        /// Код получен (где CODE - код активации)
        /// </summary>
        STATUS_OK,
    }
}
