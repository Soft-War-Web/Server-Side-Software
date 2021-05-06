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

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Recommendation> Recommendations { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Professionalprofile> Professionalprofiles { get; set; }

        public DbSet<Diet> Diets { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<SpecialtyProfile> SpecialtyProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new NutritionistMap());
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new RecommendationMap());
            modelBuilder.ApplyConfiguration(new SpecialtyMap());
            modelBuilder.ApplyConfiguration(new ProfessionalprofileMap());
            modelBuilder.ApplyConfiguration(new DietMap());
            modelBuilder.ApplyConfiguration(new AppointmentMap());
            modelBuilder.ApplyConfiguration(new SpecialtyProfileMap());
        }
    }
}
