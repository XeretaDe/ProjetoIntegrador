using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Models;
using ProjetoIntegrador.ViewModels;

namespace ProjetoIntegrador.DataContext
{
    public class Data : DbContext
    {

        public Data(DbContextOptions<Data> options)
        : base(options)
        {

        }

        public DbSet<Articles> Artigos { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ProjetoIntegrador.ViewModels.RegisterUser> RegisterUser { get; set; }

    }
}
