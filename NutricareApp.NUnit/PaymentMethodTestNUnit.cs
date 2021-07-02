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
    public class PaymentMethodControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<PaymentMethod> _paymentMethods;

        public PaymentMethodControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _paymentMethods = new List<PaymentMethod>
            {
                new PaymentMethod { PaymentMethodId = 1, ClientId = 1, CardType = "tarjeta", CardNumber = 1000000000000, City = "Lima", Country = "Perú", ExpirationDateMonth = 05, ExpirationDateYear = 2025, PostalCode = "01503", SecurityCode = 335, BillingAddress = "direccion1", BillingAddressLine2 = "direccion2", OwnerFirstName = "Josue", OwnerLastName = "Cuentas", PhoneNumber = 123456789},
                new PaymentMethod { PaymentMethodId = 2, ClientId = 1, CardType = "tarjeta", CardNumber = 1000000000000, City = "Lima", Country = "Perú", ExpirationDateMonth = 05, ExpirationDateYear = 2025, PostalCode = "01503", SecurityCode = 335, BillingAddress = "direccion1", BillingAddressLine2 = "direccion2", OwnerFirstName = "Josue", OwnerLastName = "Cuentas", PhoneNumber = 123456789},
                new PaymentMethod { PaymentMethodId = 3, ClientId = 1, CardType = "tarjeta", CardNumber = 1000000000000, City = "Lima", Country = "Perú", ExpirationDateMonth = 05, ExpirationDateYear = 2025, PostalCode = "01503", SecurityCode = 335, BillingAddress = "direccion1", BillingAddressLine2 = "direccion2", OwnerFirstName = "Josue", OwnerLastName = "Cuentas", PhoneNumber = 123456789},
                new PaymentMethod { PaymentMethodId = 4, ClientId = 1, CardType = "tarjeta", CardNumber = 1000000000000, City = "Lima", Country = "Perú", ExpirationDateMonth = 05, ExpirationDateYear = 2025, PostalCode = "01503", SecurityCode = 335, BillingAddress = "direccion1", BillingAddressLine2 = "direccion2", OwnerFirstName = "Josue", OwnerLastName = "Cuentas", PhoneNumber = 123456789},
            };
        }

        [Test]
        public async Task GetPaymentMethods()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                _context.PaymentMethods.AddRange(_paymentMethods);
                _context.SaveChanges();
                var controller = new PaymentMethodsController(_context);

                var result = await controller.GetPaymentMethods();

                Assert.True(typeof(IEnumerable<PaymentMethodModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task PostPaymentMethod()
        {
            using (var _context = new DbContextNutricareApp(_options))
            {
                CreatePaymentMethodModel _paymentMethod = new CreatePaymentMethodModel
                {
                    ClientId = 1,
                    CardType = "tarjeta",
                    City = "Lima",
                    Country = "Perú",
                    CardNumber = 1000000000000,
                    ExpirationDateMonth = 05,
                    ExpirationDateYear = 2025,
                    PostalCode = "01503",
                    SecurityCode = 335,
                    BillingAddress = "direccion1",
                    BillingAddressLine2 = "direccion2",
                    OwnerFirstName = "Josue",
                    OwnerLastName = "Cuentas",
                    PhoneNumber = 123456789
                };
                var controller = new PaymentMethodsController(_context);

                var result = await controller.PostPaymentMethod(_paymentMethod);

                _context.SaveChanges();

                Assert.True(typeof(OkResult).IsInstanceOfType(result));
            }
        }

    }
}
