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
    public class BillControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Bill> _bills;

        public BillControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _bills = new List<Bill>
            {
                new Bill { BillId = 1, ClientId = 1, Amount= 100, BillDate = DateTime.Parse("2021-06-05T03:49:49.450Z"), Ruc = 10000},
                new Bill { BillId = 2, ClientId = 1, Amount= 100, BillDate = DateTime.Parse("2021-06-05T03:49:49.450Z"), Ruc = 10000},
                new Bill { BillId = 3, ClientId = 1, Amount= 100, BillDate = DateTime.Parse("2021-06-05T03:49:49.450Z"), Ruc = 10000},
                new Bill { BillId = 4, ClientId = 1, Amount= 100, BillDate = DateTime.Parse("2021-06-05T03:49:49.450Z"), Ruc = 10000}
            };
        }

        [Test]
        public async Task GetBills()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.Bills.AddRange(_bills);
                _context.SaveChanges();
                var controller = new BillsController(_context);

                var result = await controller.GetBills();

                Assert.True(typeof(IEnumerable<BillModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostBill()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreateBillModel _bill = new CreateBillModel
                {
                    ClientId = 1,
                    Amount = 100,
                    BillDate = DateTime.Now,
                    Ruc = 100000
                };
                var controller = new BillsController(_context);

                var result = await controller.PostBill(_bill);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }

    }
}
