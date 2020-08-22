using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Enums
{
    public enum Status
    {
        /// <summary>
        /// Отменить активацию
        /// </summary>
        CancelActivation = 8,
        /// <summary>
        /// Сообщить, что SMS отправлена (необязательно)
        /// </summary>
        SmsSend = 1,
        /// <summary>
        /// Запросить еще одну смс
        /// </summary>
        RequestMessage = 3,
        /// <summary>
        /// Подтвердить SMS-код и завершить активацию
        /// </summary>
        ConfirmTextMessage = 6,
    }
}
