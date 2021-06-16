using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NutricareApp.Data;
using NutricareApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NutricareApp.Web.Controllers;
using NutricareApp.Web.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NutricareApp.NUnit
{
    public class SpecialtyControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Specialty> _specialties;

        public SpecialtyControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _specialties = new List<Specialty>
            {
                new Specialty { SpecialtyId = 1, SpecialtyName = "especialidad", InstitutionName = "nombre1"},
                new Specialty { SpecialtyId = 2, SpecialtyName = "especialidad", InstitutionName = "nombre1"},
                new Specialty { SpecialtyId = 3, SpecialtyName = "especialidad", InstitutionName = "nombre1"},
                new Specialty { SpecialtyId = 4, SpecialtyName = "especialidad", InstitutionName = "nombre1"}
            };
        }

        [Test]
        public async Task GetSpecialties()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Specialties.AddRange(_specialties);
                _context.SaveChanges();
                var controller = new SpecialtiesController(_context);

                var result = await controller.GetSpecialties();

                Assert.True(typeof(IEnumerable<SpecialtyModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostSpecialty()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateSpecialtyModel _specialty = new CreateSpecialtyModel
                {
                    SpecialtyName = "especialidad",
                    InstitutionName = "nombre"
                };
                var controller = new SpecialtiesController(_context);

                var result = await controller.PostSpecialty(_specialty);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }

    }
}
