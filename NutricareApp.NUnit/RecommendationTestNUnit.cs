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

namespace NutricareApp.NUnit
{
    public class RecommendationControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Recommendation> _recommendations;

        public RecommendationControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _recommendations = new List<Recommendation>
            {
                new Recommendation { RecommendationId = 1, NutritionistId = 1, Name = "recomendacion1", Description = "una recomendacion cualquiera", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Recommendation { RecommendationId = 2, NutritionistId = 2, Name = "recomendacion2", Description = "una recomendacion cualquiera", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Recommendation { RecommendationId = 3, NutritionistId = 3, Name = "recomendacion3", Description = "una recomendacion cualquiera", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Recommendation { RecommendationId = 4, NutritionistId = 4, Name = "recomendacion4", Description = "una recomendacion cualquiera", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z")}
            };
        }

        [Test]
        public async Task GetRecommendationsAsyncReturnAIEnumarableOfRecommendations()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Recommendations.AddRange(_recommendations);
                _context.SaveChanges();
                var controller = new RecommendationsController(_context);

                var result = await controller.GetRecommendations();

                Assert.True(typeof(IEnumerable<RecommendationModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task GetRecommendationByIdAsyncReturnARecommendation()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateRecommendationModel createRecommendationModel = new CreateRecommendationModel
                {
                    Name = "recomendacion5",
                    NutritionistId = 1,
                    Description = "una recomendacion cualquiera",
                    CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"),
                    LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z")
                };
                var controller = new RecommendationsController(_context);

                var result = await controller.GetRecommendationById(1);

                Assert.True(typeof(RecommendationModel).IsInstanceOfType(result));
            }
        }

    }
}