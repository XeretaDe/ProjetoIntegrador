#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.DataContext;
using ProjetoIntegrador.Models;
using ProjetoIntegrador.ViewModels;

namespace ProjetoIntegrador.Controllers
{
    public class ArticlesController : Controller
    {

        private readonly Data _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public ArticlesController(Data context,
                                  IWebHostEnvironment hostingEnvironment,
                                  UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
            _environment = hostingEnvironment;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artigos.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Artigos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articles == null)
            {
                return NotFound();
            }
            if (signInManager.IsSignedIn(User))
            {
                return View(articles);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }

            
        }

        // GET: Articles/Create
        public IActionResult Create()
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

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleCreateViewModel articles, Articles Artigo)
        {
            ModelState.Remove("FKUser");
            ModelState.Remove("Username");
            ModelState.Remove("Conteudo");
            ModelState.Remove("Description");
            ModelState.Remove("Imagem");
            ModelState.Remove("Title");
            ModelState.Remove("Id");
    



            if (ModelState.IsValid)
            {
                using (DbCommand cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, UserName, Email FROM aspnetusers WHERE UserName = '" + User.Identity.Name + "'";
                    _context.Database.OpenConnection();
                    using (DbDataReader ddr = cmd.ExecuteReader())
                    {

                        while (ddr.Read())
                        {
                            articles.Username = ddr.GetString("Email");
                            articles.FKUser = ddr.GetString("Id");
                        }
                    }
                    string uniqueFileName = null;
                    if (articles.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + articles.Photo.FileName;
                        string file = Path.Combine(uploadFolder, uniqueFileName);
                        articles.Photo.CopyTo(new FileStream(file, FileMode.Create));
                    }
                    Artigo.Username = articles.Username;
                    Artigo.Description = articles.DescriptionArticle;
                    Artigo.FKuser = articles.FKUser;
                    Artigo.Conteudo = articles.ContentArticle;
                    Artigo.Imagem = uniqueFileName;
                    Artigo.Title = articles.TitleArticle;
                    Artigo.Photo = articles.Photo;

                    await _context.Artigos.AddAsync(Artigo);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("index", "Home");
            }
            return View(articles);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Artigos.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            if (signInManager.IsSignedIn(User))
            {
                ArticleCreateViewModel model = new ArticleCreateViewModel();
                model.DescriptionArticle = articles.Description;
                model.Username = articles.Username;
                model.TitleArticle = articles.Title;
                model.Photo = articles.Photo;
                model.ContentArticle = articles.Conteudo;
                return View(model);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Articles Artigo, ArticleCreateViewModel articles)
        {
            if (id != Artigo.Id)
            {
                return NotFound();
            }

            ModelState.Remove("FKUser");
            ModelState.Remove("Username");
            ModelState.Remove("Conteudo");
            ModelState.Remove("Description");
            ModelState.Remove("Imagem");
            ModelState.Remove("Title");
            ModelState.Remove("Id");
            ModelState.Remove("Photo");




            if (ModelState.IsValid)
            {
                try
                {
                    using (DbCommand cmd = _context.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "SELECT Id, UserName, Email FROM aspnetusers WHERE UserName = '" + User.Identity.Name + "'";
                        _context.Database.OpenConnection();
                        using (DbDataReader ddr = cmd.ExecuteReader())
                        {

                            while (ddr.Read())
                            {
                                articles.Username = ddr.GetString("Email");
                                articles.FKUser = ddr.GetString("Id");
                            }
                        }
                        string uniqueFileName = null;
                        if (articles.Photo != null)
                        {
                            string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + articles.Photo.FileName;
                            string file = Path.Combine(uploadFolder, uniqueFileName);
                            articles.Photo.CopyTo(new FileStream(file, FileMode.Create));
                        }
                        Artigo.Username = articles.Username;
                        Artigo.Description = articles.DescriptionArticle;
                        Artigo.FKuser = articles.FKUser;
                        Artigo.Conteudo = articles.ContentArticle;
                        Artigo.Imagem = uniqueFileName;
                        Artigo.Title = articles.TitleArticle;

                        _context.Artigos.Update(Artigo);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("index", "Home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(Artigo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(articles);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Artigos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articles == null)
            {
                return NotFound();
            }

            if (signInManager.IsSignedIn(User))
            {
                return View(articles);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articles = await _context.Artigos.FindAsync(id);
            _context.Artigos.Remove(articles);
            if (signInManager.IsSignedIn(User))
            {
                await _context.SaveChangesAsync();
                return View(articles);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ArticlesExists(int id)
        {
            return _context.Artigos.Any(e => e.Id == id);
        }
    }
}
