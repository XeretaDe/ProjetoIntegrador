using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.DataContext;
using ProjetoIntegrador.Models;
using ProjetoIntegrador.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    public class UserController : Controller
    {
        private readonly Data _contexto;

        public UserController(Data contexto)
        {

            _contexto = contexto;
        }

        [Route("Register")]
        [HttpGet]
        public ActionResult Create()
        {
            if (_contexto.Users.Last().Logado)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        // POST: HomeController/Create
        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterUser Usuario)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Login = Usuario.Login, NomeUsuario = Usuario.Nome, Password = Usuario.Password };

                using (DbCommand cmd = _contexto.Database.GetDbConnection().CreateCommand())
                {
                    _contexto.Database.OpenConnection();
                    await _contexto.Users.AddAsync(user);
                    await _contexto.SaveChangesAsync();
                }

            }
            return View(User);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                bool Logged = false; 
                using (DbCommand cmd = _contexto.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM users WHERE Login = '" + model.Login + "'";
                    _contexto.Database.OpenConnection();
                    using (DbDataReader ddr = cmd.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            if (model.Password == ddr.GetString("Password"))
                            {
                                Logged = true;
                                User user = new User();
                                user.Logado = true;
                                user.Login = ddr.GetString("Login");
                                user.NomeUsuario = ddr.GetString("NomeUsuario");
                                user.Password = ddr.GetString("Password");
                                user.IdUser = ddr.GetString("IdUser");

                                user.UserLogado = new List<User>();
                                user.UserLogado.Add(user);
                            }

                        }
                    }
                }
                if (Logged)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout(User usuario)
        {
            User user = new User();
            user.UserLogado.Remove(usuario);
            return RedirectToAction("index", "Home");
        }
    }
}
