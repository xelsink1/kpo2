# Общая идея решения
Реализовано консольное приложение для учета личных финансов. Приложение демонстрирует принципы чистой архитектуры, SOLID, GRASP и применение паттернов GoF.

# Основной функционал
Управление счетами, категориями и операциями.
Экспорт данных.
# Принципы SOLID
### 1. Single responsibility
Например, есть классы DBAccountsImpl, DBCategoriesImpl, DBOperationsImpl, они выполняют работу над счетами, категориями, операциями соответственно. То есть отвечают за один функционал.
## 2. Принцип Liskov
Не нарушен.
## 3. Interface Segregation
Интерфейсы разделены DBAccounts, DBCategories, DBOperations.
## 4. Dependency Inversion
Классы работают с абстракциями, а не с реализациями. Например, AccountCommands использует DBAccounts, не зная о DBAccountsImpl.
## 5. Open-сlosed
Возьмем класс DBAccounts, добавив новый функционал на работу текущего кода это никак не повлияет
# Grasp
#### High Cohesion
Компоненты выполняют свою основную задачу, например ConsoleCommands отвечает за ввод различных переменных.
#### Low Coupling
Достигнуто использованием DI контейнера и через зависимости от абстракций DBAccounts, DBCategories, DBOperations.
# Реализованные паттерны GoF
### Фасад
DBAccountsImpl, DBCategoriesImpl, DBOperationsImpl предоставляют интерфейс для работы с хранилищами счетов, категорий и операций.
### Фабрика
AccountCreatorImpl, CategoryCreatorImpl, OperationCreatorImpl фабрики для созданий с валидацией.
# Запуск
Откройте Rider, создаете проект, клонируете в него гит репозиторий, запускаете проект. Если не собралось, тогда надо докачать эти nugget пакеты вручную:
1. Microsoft.Extensions.DependencyInjection
2. SkiaSharp
3. Spectre.Console
4. Spectre.Console.Cli

Теперь точно должно быть все ок.