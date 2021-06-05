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
    public class ClientTestNUnit
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Client> _clients;

        public ClientTestNUnit()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _clients = new List<Client>
            {
                new Client {ClientId = 1, Username = "pepito1", Password = "pepito123", FirstName = "Jose", LastName = "Peralta", Email = "pepito@gmail.com", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Client {ClientId = 2, Username = "pepito2", Password = "pepito123", FirstName = "Jose1", LastName = "Peralta", Email = "pepito@gmail.com", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Client {ClientId = 3, Username = "pepito3", Password = "pepito123", FirstName = "Jose1", LastName = "Peralta", Email = "pepito@gmail.com", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")},
                new Client {ClientId = 4, Username = "pepito4", Password = "pepito123", FirstName = "Jose1", LastName = "Peralta", Email = "pepito@gmail.com", CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")}
            };
        }

        [Test]
        public async Task GetClients()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Clients.AddRange(_clients);
                _context.SaveChanges();
                var controller = new ClientsController(_context);

                var result = await controller.GetClients();

                Assert.True(typeof(IEnumerable<ClientModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostClient()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateClientModel _client = new CreateClientModel
                {
                    Username = "pepito1",
                    Password = "pepito123",
                    FirstName = "Jose",
                    LastName = "Peralta",
                    Email = "pepito@gmail.com",
                    CreatedAt = DateTime.Parse("2021-06-05T03:49:49.450Z")
                };

                var controller = new ClientsController(_context);

                var result = await controller.PostClient(_client);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }

    }
}
