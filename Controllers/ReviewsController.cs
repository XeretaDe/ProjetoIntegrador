#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.DataContext;
using ProjetoIntegrador.Models;
using ProjetoIntegrador.ViewModels;

namespace ProjetoIntegrador.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly Data _context;
        private readonly IWebHostEnvironment _environment;




        public ReviewsController(Data context,
                                  IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);



        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            if (_context.Users.Last().Logado)
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
        public async Task<IActionResult> Create(ReviewCreateViewModel reviews, Reviews Review)
        {
            ModelState.Remove("FKUser");
            ModelState.Remove("Username");
            ModelState.Remove("Conteudo");
            ModelState.Remove("Description");
            ModelState.Remove("Imagem");
            ModelState.Remove("Title");
            ModelState.Remove("Id");
            ModelState.Remove("Username");
            ModelState.Remove("IdAutor");






            if (ModelState.IsValid)
            {
                using (DbCommand cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT IdUser, NomeUsuario, Login FROM users WHERE NomeUsuario = '" + User.Identity.Name + "'";
                    _context.Database.OpenConnection();
                    using (DbDataReader ddr = cmd.ExecuteReader())
                    {

                        while (ddr.Read())
                        {
                            reviews.Username = ddr.GetString("Login");
                            reviews.FKUser = ddr.GetString("IdUser");
                        }
                    }
                    string uniqueFileName = null;
                    if (reviews.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + reviews.Photo.FileName;
                        string file = Path.Combine(uploadFolder, uniqueFileName);
                        reviews.Photo.CopyTo(new FileStream(file, FileMode.Create));
                    }
                    Review.Username = reviews.Username;
                    Review.Description = reviews.DescriptionReview;
                    Review.IdAutor = reviews.FKUser;
                    Review.ContentReview = reviews.ContentReview;
                    Review.Imagem = uniqueFileName;
                    Review.Title = reviews.TitleReview;
                    Review.Photo = reviews.Photo;

                    await _context.Reviews.AddAsync(Review);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("index", "Home");
            }
            return View(reviews);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            if (_context.Users.Last().Logado)
            {
                ReviewCreateViewModel model = new ReviewCreateViewModel();
                model.DescriptionReview = reviews.Description;
                model.Username = reviews.Username;
                model.TitleReview = reviews.Title;
                model.Photo = reviews.Photo;
                model.ContentReview = reviews.ContentReview;
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
        public async Task<IActionResult> Edit(int id, Reviews Review, ReviewCreateViewModel reviews)
        {
            if (id != Review.Id)
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
            ModelState.Remove("IdAutor");

            if (ModelState.IsValid)
            {
                try
                {
                    using (DbCommand cmd = _context.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "SELECT IdUser, NomeUsuario, Login FROM users WHERE UserName = '" + User.Identity.Name + "'";
                        _context.Database.OpenConnection();
                        using (DbDataReader ddr = cmd.ExecuteReader())
                        {

                            while (ddr.Read())
                            {
                                reviews.Username = ddr.GetString("Login");
                                reviews.FKUser = ddr.GetString("IdUser");
                            }
                        }
                        string uniqueFileName = null;
                        if (reviews.Photo != null)
                        {
                            string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + reviews.Photo.FileName;
                            string file = Path.Combine(uploadFolder, uniqueFileName);
                            reviews.Photo.CopyTo(new FileStream(file, FileMode.Create));
                        }
                        Review.Username = reviews.Username;
                        Review.Description = reviews.DescriptionReview;
                        Review.IdAutor = reviews.FKUser;
                        Review.Grade = reviews.Grade;
                        Review.ContentReview = reviews.ContentReview;
                        Review.Imagem = uniqueFileName;
                        Review.Title = reviews.TitleReview;

                        _context.Reviews.Update(Review);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction("index", "Home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(Review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(reviews);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            if (_context.Users.Last().Logado)
            {
                return View(reviews);
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
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            if (_context.Users.Last().Logado)
            {
                await _context.SaveChangesAsync();
                return View(reviews);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ArticlesExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
