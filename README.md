# Sms-Service

![GitHub release (latest by date)](https://img.shields.io/badge/C%23%20-%20.Net%20Framework%204.5.2-blueviolet)

Библиотека которая объединяет в себе все сервисы для работы с смс-активацией

|Метод/Сервис| SmsHub.org|Sms-Activate.ru|||||
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
* smshub.org
* sms-activate.ru
* sms-acktiwator.ru
* smssms.org
* GetSms.online
* onlinesim.ru
* 5sim.net
* vak-sms.com

* cheapsms.ru
* smska.net
* StuffSms
* sms.ski

1. SMS-REG.com
2. SimSms.org
3. Smspva.com
4. virtualsms.ru
5. getsmscode.com
6. SMS-AREA.org
7. Give-SMS.com
8. SMS-Online.pro
