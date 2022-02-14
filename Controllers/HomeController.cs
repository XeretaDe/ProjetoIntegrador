using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.ViewModels;
using ProjetoIntegrador.Models;

namespace ProjetoIntegrador.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            // Initialization.  
            ModelsViewModel model = new ModelsViewModel();
            model.ArtigosVM = new Articles();


            // Pegar ultimo artigo registrado + os próximos
            model.ReviewsVM = new Reviews();
            //Pegar ultima review

            return View(model);
        }
    }
}
