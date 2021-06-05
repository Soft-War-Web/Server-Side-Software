using System;
﻿using Microsoft.EntityFrameworkCore;
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
    public class ProfessionalControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Professionalprofile> _professionalprofiles;

        public ProfessionalControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _professionalprofiles = new List<Professionalprofile>
            {

                new Professionalprofile { NutritionistId = 1, ProfessionalExperienceDescription = "Adolescentes con problemas alimenticios", ProfessionalprofileId = 1},
                new Professionalprofile { NutritionistId = 2, ProfessionalExperienceDescription = "Adolescentes con problemas alimenticios", ProfessionalprofileId = 2},
                new Professionalprofile { NutritionistId = 3, ProfessionalExperienceDescription = "Adolescentes con problemas alimenticios", ProfessionalprofileId = 3},
                new Professionalprofile { NutritionistId = 4, ProfessionalExperienceDescription = "Adolescentes con problemas alimenticios", ProfessionalprofileId = 4}
            };
        }

        [Test]
        public async Task GetProfessionalProfile()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Professionalprofiles.AddRange(_professionalprofiles);
                _context.SaveChanges();
                var controller = new ProfessionalprofilesController(_context);

                var result = await controller.GetProfessionalprofiles();

                Assert.True(typeof(IEnumerable<ProfessionalprofileModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostProfessionalProfile()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateProfessionalprofileModel _professionalprofile = new CreateProfessionalprofileModel
                {
                    NutritionistId = 1,
                    ProfessionalExperienceDescription = "Adolescentes con problemas alimenticios"
                };

                var controller = new ProfessionalprofilesController(_context);
                var result = await controller.PostProfessionalprofile(_professionalprofile);

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }

    }
}