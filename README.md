# Sms-Service

![GitHub release (latest by date)](https://img.shields.io/badge/C%23%20-%20.Net%20Framework%204.5.2-blueviolet)

Библиотека которая объединяет в себе все сервисы для работы с смс-активацией

|Метод/Сервис| SmsHub.org|Sms-Activate.ru|5sim.net|Onlinesim.ru|Simsms.org|Sms-Reg.com|
|---|:---:|:---:|:---:|:---:|:---:|:---:|
|GetNumbersStatus|+|+|||||
|GetBalance|+|+|||||
|GetNumber|+|+|||||
|GetMultiServiceNumber||+|||||
|SetStatus|+|+|||||
|GetStatus|+|+|||||
|GetPrices|+|+|||||
|GetNumbersStatusAndCostHubFree|+||||||
|GetQiwiRequisites|| + |||||
|GetAdditionalService|| + |||||
|GetRentServicesAndCountries|| * |||||
|GetRentNumber|| * |||||
|GetRentStatus|| * |||||
|SetRentStatus|| * |||||

### Сервисы
#### SmsHub.org
- GetNumbersStatusAndCostHubFreeAsync - метод отснифен на сайте. Лучше использовать его по сравнению с "GetPrices" удобен в плане детальной информации о номерах.

#### Другое 
- CheckStatusAsync - можно использовать для получения сразу уже готово результата. Избавляет нужды постоянно вручную проверять "GetStatus".

### Информация
`+` - Имеется в библиотеке

`*` - В планах добавить

### В планах добавить сервисы:
* sms-activate.ru
* 5sim.net
* smshub.org
* SMS-REG.com
* SimSms.org
* onlinesim.ru
1. Smspva.com
2. virtualsms.ru
3. getsmscode.com
4. sms-acktiwator.ru
5. SMS-AREA.org
6. GetSms.online
7. vak-sms.com
8. cheapsms.ru
9. smska.net
10. sms.ski
11. Give-SMS.com
12. SMS-Online.pro
