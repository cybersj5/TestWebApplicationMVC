// Определение пространства имен проекта
namespace WebApplication1
{
    // Главный класс программы
    public class Program
    {
        // Точка входа в приложение
        public static void Main(string[] args)
        {
            // Создание билдера для настройки приложения
            var builder = WebApplication.CreateBuilder(args);

            // Добавление сервисов в контейнер зависимостей
            // Регистрация поддержки MVC с представлениями
            builder.Services.AddControllersWithViews();

            // Построение объекта приложения
            var app = builder.Build();

            // Настройка конвейера обработки HTTP-запросов

            // В продакшн-режиме используем специальный обработчик ошибок
            if (!app.Environment.IsDevelopment())
            {
                // Перенаправление на страницу ошибки при исключениях
                app.UseExceptionHandler("/Home/Error");
            }

            // Подключение маршрутизации
            app.UseRouting();

            // Подключение middleware для авторизации
            app.UseAuthorization();

            // Сопоставление статических файлов (из папки wwwroot)
            app.MapStaticAssets();

            // Настройка маршрутов по умолчанию:
            // {controller}/{action}/{id?} (Home/Index - по умолчанию)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();  // Дополнительная настройка для статических файлов

            // Запуск приложения
            app.Run();
        }
    }
}