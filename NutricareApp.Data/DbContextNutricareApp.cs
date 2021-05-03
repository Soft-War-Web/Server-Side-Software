using Microsoft.EntityFrameworkCore;
using NutricareApp.Data.Mapping;
using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Data
{
    public class DbContextNutricareApp : DbContext
    {
        public DbContextNutricareApp(DbContextOptions<DbContextNutricareApp> options): base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Nutritionist> Nutritionists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new NutritionistMap());
        }
    }
}
