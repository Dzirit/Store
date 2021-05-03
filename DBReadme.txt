Для миграции базы данных в первый раз 
view-> other windows -> package manager console
Вводим :
1. Add-Migration InitialCreate -Project Store.Data.Ef -StartupProject Store.Web - добавляем миграцию
Если ошибка The name 'InitialCreate' is used by an existing migration. Удалитте классы в папке Migrations
2. Update-Database -Project Store.Data.Ef -StartupProject Store.Web - бд появляется в субд
