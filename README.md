# Sms-Service

![GitHub release (latest by date)](https://img.shields.io/badge/C%23%20-%20.Net%20Framework%204.5.2-blueviolet)

Библиотека которая объединяет в себе все сервисы для работы с смс-активацией

|Метод/Сервис| SmsHub.org|Sms-Activate.ru|5sim.net|
|---|:---:|:---:|:---:|
|GetNumbersStatus|+|||
|GetBalance|+|||
|GetNumber|+|||
|SetStatus|+|||
|GetStatus|+|||
|GetPrices|+|||
|GetNumbersStatusAndCostHubFreeAsync|+|||

### Сервисы
#### SmsHub.org
- GetNumbersStatusAndCostHubFreeAsync - метод отснифен на сайте. Лучше использовать его по сравнению с "GetPrices" удобен в плане детальной информации о номерах.

#### Другое 
- CheckStatusAsync - можно использовать для получения сразу уже готово результата. Избавляет нужды постоянно вручную проверять "GetStatus".

### Информация
`+` - Имеется в библиотеке

`*` - В планах добавить
