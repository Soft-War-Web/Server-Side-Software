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
    public class DietTestNUnit
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Diet> _diets;

        public DietTestNUnit()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _diets = new List<Diet>
            {
                new Diet {DietId = 1, DietName = "Diet1", DietDescription = "DietDescription1", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Diet {DietId = 2, DietName = "Diet2", DietDescription = "DietDescription2", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Diet {DietId = 3, DietName = "Diet3", DietDescription = "DietDescription3", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Diet {DietId = 4, DietName = "Diet4", DietDescription = "DietDescription4", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
            };
        }

        [Test]
        public async Task GetDiets()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Diets.AddRange(_diets);
                _context.SaveChanges();
                var controller = new DietsController(_context);

                var result = await controller.GetDiets();

                Assert.True(typeof(IEnumerable<DietModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostDiet()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateDietModel _diet = new CreateDietModel
                {
                    DietName = "Diet1",
                    DietDescription = "DietDescription1",
                    CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")
                };

                var controller = new DietsController(_context);

                var result = await controller.PostDiet(_diet);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }
    }
}
