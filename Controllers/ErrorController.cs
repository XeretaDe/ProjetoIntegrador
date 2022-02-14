using Microsoft.AspNetCore.Mvc;

namespace ProjetoIntegrador.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
