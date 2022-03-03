using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.DataContext;
using ProjetoIntegrador.Models;
using ProjetoIntegrador.ViewModels;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    public class UserController : Controller
    {
        private readonly Data _contexto;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager,
                                Data contexto)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _contexto = contexto;

        }

        [Route("Register")]
        [HttpGet]
        public ActionResult Create()
        {
            if (signInManager.IsSignedIn(User))
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
                //var user = new User { Login = Usuario.Login, NomeUsuario = Usuario.Nome, Password = Usuario.Password };

                //using (DbCommand cmd = _contexto.Database.GetDbConnection().CreateCommand())
                //{
                //    _contexto.Database.OpenConnection();
                //    await _contexto.Users.AddAsync(user);
                //    await _contexto.SaveChangesAsync();
                //}

                var usuario = new IdentityUser { UserName = Usuario.Login, Email = Usuario.Nome };
                var result = await userManager.CreateAsync(usuario, Usuario.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(usuario, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
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
        public async Task<IActionResult> Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                //using (DbCommand cmd = _contexto.Database.GetDbConnection().CreateCommand())
                //{
                //    cmd.CommandText = "SELECT * FROM users WHERE UserName = '" + model.Login + "'";
                //    _contexto.Database.OpenConnection();
                //    using (DbDataReader ddr = cmd.ExecuteReader())
                //    {
                //        while (ddr.Read())
                //        {
                //            if (model.Password == ddr.GetString("Password"))
                //            {
                //                User user = new User();
                //                user.Logado = true;
                //                user.Login = ddr.GetString("Login");
                //                user.NomeUsuario = ddr.GetString("NomeUsuario");
                //                user.Password = ddr.GetString("Password");
                //                user.IdUser = ddr.GetInt32("IdUser");
                //            }

                //        }
                //    }
                //}
                var result = await signInManager.PasswordSignInAsync(
                                   model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
        //public IActionResult Logout(User usuario)
        //{
        //    usuario.Logado = false;
        //    return RedirectToAction("index", "Home");
        //}
    }
}
