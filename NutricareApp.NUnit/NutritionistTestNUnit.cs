using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NutricareApp.Data;
using NutricareApp.Entities;
using NutricareApp.Web.Controllers;
using NutricareApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace NutricareApp.NUnit
{
    public class NutritionistTestNUnit
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Nutritionist> _nutritionists;

        public NutritionistTestNUnit()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _nutritionists = new List<Nutritionist>
            {
                new Nutritionist {NutritionistId = 1, Username = "pepito1", Password = "pepito123", FirstName = "Jose", LastName = "Peralta", Email = "pepito@gmail.com", CnpNumber = 123456, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Nutritionist {NutritionistId = 2, Username = "pepito2", Password = "pepito123", FirstName = "Jose", LastName = "Peralta", Email = "pepito@gmail.com", CnpNumber = 123456, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Nutritionist {NutritionistId = 3, Username = "pepito3", Password = "pepito123", FirstName = "Jose", LastName = "Peralta", Email = "pepito@gmail.com", CnpNumber = 123456, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Nutritionist {NutritionistId = 4, Username = "pepito4", Password = "pepito123", FirstName = "Jose", LastName = "Peralta", Email = "pepito@gmail.com", CnpNumber = 123456, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")}
            };
        }

        [Test]
        public async Task GetNutritionists()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Nutritionists.AddRange(_nutritionists);
                _context.SaveChanges();
                var controller = new NutritionistsController(_context);

                var result = await controller.GetNutritionists();

                Assert.True(typeof(IEnumerable<NutritionistModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostNutritionist()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateNutritionistModel _nutritionist = new CreateNutritionistModel
                {
                    Username = "pepito1",
                    Password = "pepito123",
                    FirstName = "Jose",
                    LastName = "Peralta",
                    Email = "pepito@gmail.com",
                    CnpNumber = 123456,
                    CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")
                };

                var controller = new NutritionistsController(_context);

                var result = await controller.PostNutritionist(_nutritionist);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }
    }
}
