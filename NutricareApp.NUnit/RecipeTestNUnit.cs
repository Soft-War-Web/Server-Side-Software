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
    public class RecipeControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Recipe> _recipes;

        public RecipeControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            Nutritionist nutritionist = new Nutritionist();
            _recipes = new List<Recipe>
            {
                new Recipe { RecipeId = 1, NutritionistId = 1, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), Description = "receta de chaufa bajo en calorías", Favorite = 150, Ingredients = "ingredientes", LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z"), Name = "Chaufa bajo en calorías", Preparation = "preparation"},
                new Recipe { RecipeId = 2, NutritionistId = 2, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), Description = "receta de chaufa bajo en calorías", Favorite = 150, Ingredients = "ingredientes", LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z"), Name = "Chaufa bajo en calorías", Preparation = "preparation"},
                new Recipe { RecipeId = 3, NutritionistId = 3, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), Description = "receta de chaufa bajo en calorías", Favorite = 150, Ingredients = "ingredientes", LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z"), Name = "Chaufa bajo en calorías", Preparation = "preparation"},
                new Recipe { RecipeId = 4, NutritionistId = 4, CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"), Description = "receta de chaufa bajo en calorías", Favorite = 150, Ingredients = "ingredientes", LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z"), Name = "Chaufa bajo en calorías", Preparation = "preparation"}
            };
        }

        [Test]
        public async Task GetRecipe()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Recipes.AddRange(_recipes);
                _context.SaveChanges();
                var controller = new RecipesController(_context);

                var result = await controller.GetRecipes();

                Assert.True(typeof(IEnumerable<RecipeModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostRecipe()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateRecipeModel _recipe = new CreateRecipeModel
                {
                    Name = "Chaufa",
                    NutritionistId = 1,
                    CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z"),
                    Description = "descripcion",
                    Ingredients = "ingredientes",
                    LastModification = DateTime.Parse("2021-06-05T03:49:49.450Z"),
                    Preparation = "preparacion"
                };
                var controller = new RecipesController(_context);

                var result = await controller.PostRecipe(_recipe);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }

    }
}