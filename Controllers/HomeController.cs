using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.ViewModels;
using ProjetoIntegrador.Models;
using ProjetoIntegrador.DataContext;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace ProjetoIntegrador.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data _context;
        private readonly IWebHostEnvironment _environment;


        public HomeController(Data context,
                                  IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }
        public ActionResult Index()
        {
            // Initialization.  
            ModelsViewModel model = new ModelsViewModel();
            model.ArtigosVM = new Articles();
            model.ArtigosVM.ListArticles = new List<Articles>();

            using (DbCommand cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "select * from artigos order by id desc limit 5;";
                _context.Database.OpenConnection();
                using (DbDataReader ddr = cmd.ExecuteReader())
                {
                      
                    while (ddr.Read())
                    {
                        Articles artigosVM = new Articles();
                        artigosVM.Id = ddr.GetInt32("Id");
                        artigosVM.Description = ddr.GetString("Description");
                        artigosVM.Conteudo = ddr.GetString("Conteudo");
                        artigosVM.Imagem = ddr.GetString("Imagem");
                        artigosVM.Title = ddr.GetString("Title");

                        model.ArtigosVM.ListArticles.Add(artigosVM);

                    }
                    _context.Database.CloseConnection();
                }
            }

            model.ReviewsVM = new Reviews();
            model.ReviewsVM.ListReviews = new List<Reviews>();
            using (DbCommand cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "select * from reviews order by id desc limit 1;";
                _context.Database.OpenConnection();
                using (DbDataReader ddr = cmd.ExecuteReader())
                {

                    while (ddr.Read())
                    {
                        Reviews reviewsVM = new Reviews();

                        reviewsVM.Description = ddr.GetString("Description");
                        reviewsVM.Id = ddr.GetInt32("Id");
                        reviewsVM.ContentReview = ddr.GetString("Conteudo");
                        reviewsVM.Imagem = ddr.GetString("Image");
                        reviewsVM.Title = ddr.GetString("Title");
                        reviewsVM.Grade = ddr.GetInt32("Score");

                        model.ReviewsVM.ListReviews.Add(reviewsVM);

                    }
                    _context.Database.CloseConnection();
                }
            }

            return View(model);
        }
    }
}
