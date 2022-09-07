using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Banck;
using Domain.Entities.Pelicula;
using System.Data.SqlClient;

namespace Infractructure.Context
{
    internal class ApplicationDbContext : IdentityDbContext<Usuarios,Rol,string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
       public DbSet<Usuarios> usuarios { set; get; }
       public DbSet<BanckCards> BanckCards { set; get; }
       public DbSet<Peliculas> Peliculas { set; get; }
      

        public List<Peliculas> MostrarPeliculas()

        {

            string sql = "MOSTRARPELICULAS";
            return this.Peliculas.FromSqlRaw(sql).ToList();

           // return this.Peliculas.FromSql(sql).ToList();

        }

        //ejemplo con parametros

        public Peliculas MostrarPelicula(Guid id)

        {

            String sql = "MOSTRARPELICULA @Id;";

            SqlParameter pamid = new SqlParameter("@ID", id);

            return this.Peliculas.FromSqlRaw(sql, pamid).SingleOrDefault();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
