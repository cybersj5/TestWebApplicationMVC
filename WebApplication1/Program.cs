// ����������� ������������ ���� �������
namespace WebApplication1
{
    // ������� ����� ���������
    public class Program
    {
        // ����� ����� � ����������
        public static void Main(string[] args)
        {
            // �������� ������� ��� ��������� ����������
            var builder = WebApplication.CreateBuilder(args);

            // ���������� �������� � ��������� ������������
            // ����������� ��������� MVC � ���������������
            builder.Services.AddControllersWithViews();

            // ���������� ������� ����������
            var app = builder.Build();

            // ��������� ��������� ��������� HTTP-��������

            // � ��������-������ ���������� ����������� ���������� ������
            if (!app.Environment.IsDevelopment())
            {
                // ��������������� �� �������� ������ ��� �����������
                app.UseExceptionHandler("/Home/Error");
            }

            // ����������� �������������
            app.UseRouting();

            // ����������� middleware ��� �����������
            app.UseAuthorization();

            // ������������� ����������� ������ (�� ����� wwwroot)
            app.MapStaticAssets();

            // ��������� ��������� �� ���������:
            // {controller}/{action}/{id?} (Home/Index - �� ���������)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();  // �������������� ��������� ��� ����������� ������

            // ������ ����������
            app.Run();
        }
    }
}