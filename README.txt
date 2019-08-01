Тестовое задание.

Веб сервис на C#. В архиве проект под Visual Studio 2017.
Url по умолчанию: http://localhost:54838/

Сервис имеет два метода:

1) Получает на вход json, который содержит массив объектов, и сохраняет его в базе данных. 
  Запрос: POST /api/Data
  
  
2) Возвращает данные клиенту из таблицы в виде json. 
  Запрос: GET /api/Data
  
  Есть возможность фильтровать возвращаемые данные посредством аргумента Filter адресной строки.
  В качестве значения аргумента передаются операторы сравнения sql.
  Например: Code!=1 and Code<5
  HTTP: GET http://localhost:54838/api/Data?Filter=Code!=1%20and%20Code<5
  
Файл базы данных: WebService\App_Data\Data.mdf

Строка подключения:
  connectionString="Data Source=(localdb)\MSSQLLocalDB; Integrated Security=True; MultipleActiveResultSets=True; AttachDbFilename=|DataDirectory|Data.mdf"

Таблица DataItems:
CREATE TABLE [dbo].[DataItems] (
    [Number] INT            IDENTITY (1, 1) NOT NULL,
    [Code]   INT            NOT NULL,
    [Value]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.DataItems] PRIMARY KEY CLUSTERED ([Number] ASC)
);
  
Client.html - простейшая клиентская html страничка для тестирования сервиса. Работает при запущенном сервисе.

Кнопка Post - вызывает первый метод. Отправляет содержимое текстового окна на сервис.
Кнопка Get - вызывает второй метод. Загружает содержимое базы данных в текстовое окно. В поле Filter можно указать условия для фильтрации данных.
Кнопка Clear - отчищает текстовое окно.

TestData.json - содержит данные для теста в json формате.

Ссылка на github репозиторий: https://github.com/AndreyBobrovIrk/WebService