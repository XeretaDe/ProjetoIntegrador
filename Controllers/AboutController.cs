using Microsoft.AspNetCore.Mvc;

namespace ProjetoIntegrador.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
