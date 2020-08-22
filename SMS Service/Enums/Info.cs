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
        /// Возникла ошибка
        /// </summary>
        ERROR,

        /// <summary>
        /// BALANCE - Баланс вашего API-ключа
        /// </summary>
        ACCESS_BALANCE,
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
        /// Неверный API-ключ
        /// </summary>
        BAD_KEY,
        /// <summary>
        /// Общее неправильное формирование запроса
        /// </summary>
        BAD_ACTION,
        /// <summary>
        /// некорректное наименование сервиса
        /// </summary>
        BAD_SERVICE,
        /// <summary>
        /// некорректно указана переадресация
        /// </summary>
        BAD_FORWARD,
        /// <summary>
        /// 'YYYY-m-d H-i-s' - время на которое аккаунт заблокирован
        /// </summary>
        BANNED,
        /// <summary>
        /// ошибка SQL-сервера
        /// </summary>
        ERROR_SQL,
        /// <summary>
        /// Нет номеров с заданными параметрами, попробуйте позже, или поменяйте оператора, страну.
        /// </summary>
        NO_NUMBERS,
        /// <summary>
        /// Закончились деньги на API-ключе
        /// </summary>
        NO_BALANCE,
        /// <summary>
        /// для страны, которую вы используете, недоступна покупка мультисервисов
        /// </summary>
        NOT_AVAILABLE,
        /// <summary>
        /// id активации не существует
        /// </summary>
        NO_ACTIVATION,
        /// <summary>
        /// Ошибка возникает при попытке заказать купленный сервис еще раз
        /// </summary>
        REPEAT_ADDITIONAL_SERVICE,
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
        /// Ожидание повторной отправки смс *. * софт должен нажать повторно выслать смс и выполнить изменение статуса на  6
        /// </summary>
        STATUS_WAIT_RESEND,
        /// <summary>
        /// Код получен (где CODE - код активации)
        /// </summary>
        STATUS_OK,
        /// <summary>
        /// некорректные исключающие префиксы
        /// </summary>
        WRONG_EXCEPTION_PHONE,
        /// <summary>
        /// Не верный идентификатор сервиса
        /// </summary>
        WRONG_SERVICE,
        /// <summary>
        /// Неверный дополнительный сервис (допустимы только сервисы для переадресации)
        /// </summary>
        WRONG_ADDITIONAL_SERVICE,
        /// <summary>
        /// Неверный ID родительской активации
        /// </summary>
        WRONG_ACTIVATION_ID,
        /// <summary>
        /// Ошибка при попытке передать ID активации без переадресации, или же завершенной/не активной активации
        /// </summary>
        WRONG_SECURITY,
    }
}
