using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Greet(string name)
        {
            return Content($"Привет, {name}!");
        }
        public IActionResult UserInfo()
        {
            var user = new User { Name = "Иван Иванов", Age = 30 };
            return View(user);
        }
        public IActionResult Calculator(string operation, int a, int b)
        {
            try
            {
                Console.WriteLine($"{operation}{a}{b}");
                switch (operation)
                {
                    case "Add":
                        return Content($"{a + b}");
                    case "Subtarct":
                        return Content($"{a - b}");
                    case "Multiply":
                        return Content($"{a * b}");
                    case "Divide":
                        return Content($"{a * b}");
                    default:
                        return Content("Лох");
                }
            }
            catch(Exception ex)
            {
                return Content($"{ex.Message}");
            }
        }
    }
}
