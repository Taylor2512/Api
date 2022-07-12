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

namespace Infractructure.Context
{
    internal class ApplicationDbContext : IdentityDbContext<Usuarios,Rol,string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
       public DbSet<Usuarios> usuarios { set; get; }
       public DbSet<BanckCards> BanckCards { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
