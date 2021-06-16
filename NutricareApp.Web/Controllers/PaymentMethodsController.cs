using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutricareApp.Data;
using NutricareApp.Entities;
using NutricareApp.Web.Models;

namespace NutricareApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public PaymentMethodsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public async Task<IEnumerable<PaymentMethodModel>> GetPaymentMethods()
        {
            var paymentMethods = await _context.PaymentMethods.ToListAsync();
            return paymentMethods.Select(c => new PaymentMethodModel
            {
                PaymentMethodId = c.PaymentMethodId,
                ClientId = c.ClientId,
                CardType = c.CardType,
                ExpirationDateMonth = c.ExpirationDateMonth,
                ExpirationDateYear = c.ExpirationDateYear,
                SecurityCode = c.SecurityCode,
                OwnerFirstName = c.OwnerFirstName,
                OwnerLastName = c.OwnerLastName,
                City = c.City,
                BillingAddress = c.BillingAddress,
                BillingAddressLine2 = c.BillingAddressLine2,
                PostalCode = c.PostalCode,
                Country = c.Country,
                PhoneNumber = c.PhoneNumber
            });
        }

        // GET: api/PaymentMethods/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPaymentMethodById([FromRoute] int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(new PaymentMethodModel
            {
                PaymentMethodId = paymentMethod.PaymentMethodId,
                ClientId = paymentMethod.ClientId,
                CardType = paymentMethod.CardType,
                ExpirationDateMonth = paymentMethod.ExpirationDateMonth,
                ExpirationDateYear = paymentMethod.ExpirationDateYear,
                SecurityCode = paymentMethod.SecurityCode,
                OwnerFirstName = paymentMethod.OwnerFirstName,
                OwnerLastName = paymentMethod.OwnerLastName,
                City = paymentMethod.City,
                BillingAddress = paymentMethod.BillingAddress,
                BillingAddressLine2 = paymentMethod.BillingAddressLine2,
                PostalCode = paymentMethod.PostalCode,
                Country = paymentMethod.Country,
                PhoneNumber = paymentMethod.PhoneNumber
            });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<PaymentMethodModel>> GetPaymentMethodByClient([FromRoute] int id)
        {
            var paymentMethodList = await _context.PaymentMethods.ToListAsync();
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            foreach (PaymentMethod paymentMethod in paymentMethodList)
            {
                if (paymentMethod.ClientId == id)
                    paymentMethods.Add(paymentMethod);
            }

            return paymentMethods.Select(c => new PaymentMethodModel
            {
                PaymentMethodId = c.PaymentMethodId,
                ClientId = c.ClientId,
                CardType = c.CardType,
                ExpirationDateMonth = c.ExpirationDateMonth,
                ExpirationDateYear = c.ExpirationDateYear,
                SecurityCode = c.SecurityCode,
                OwnerFirstName = c.OwnerFirstName,
                OwnerLastName = c.OwnerLastName,
                City = c.City,
                BillingAddress = c.BillingAddress,
                BillingAddressLine2 = c.BillingAddressLine2,
                PostalCode = c.PostalCode,
                Country = c.Country,
                PhoneNumber = c.PhoneNumber
            });
        }

        // PUT: api/PaymentMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutPaymentMethod([FromBody] UpdatePaymentMethodModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.PaymentMethodId <= 0)
                return BadRequest();

            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(c => c.PaymentMethodId == model.PaymentMethodId);

            if (paymentMethod == null)
                return NotFound();

            paymentMethod.PaymentMethodId = model.PaymentMethodId;
            paymentMethod.ClientId = model.ClientId;
            paymentMethod.CardType = model.CardType;
            paymentMethod.ExpirationDateMonth = model.ExpirationDateMonth;
            paymentMethod.ExpirationDateYear = model.ExpirationDateYear;
            paymentMethod.SecurityCode = model.SecurityCode;
            paymentMethod.OwnerFirstName = model.OwnerFirstName;
            paymentMethod.OwnerLastName = model.OwnerLastName;
            paymentMethod.City = model.City;
            paymentMethod.BillingAddress = model.BillingAddress;
            paymentMethod.BillingAddressLine2 = model.BillingAddressLine2;
            paymentMethod.PostalCode = model.PostalCode;
            paymentMethod.Country = model.Country;
            paymentMethod.PhoneNumber = model.PhoneNumber;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        // POST: api/PaymentMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPaymentMethod([FromBody] CreatePaymentMethodModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PaymentMethod paymentMethod = new PaymentMethod
            {
                ClientId = model.ClientId,
                CardType = model.CardType,
                ExpirationDateMonth = model.ExpirationDateMonth,
                ExpirationDateYear = model.ExpirationDateYear,
                SecurityCode = model.SecurityCode,
                OwnerFirstName = model.OwnerFirstName,
                OwnerLastName = model.OwnerLastName,
                City = model.City,
                BillingAddress = model.BillingAddress,
                BillingAddressLine2 = model.BillingAddressLine2,
                PostalCode = model.PostalCode,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber
            };

            _context.PaymentMethods.Add(paymentMethod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod([FromRoute] int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
                return NotFound();

            _context.PaymentMethods.Remove(paymentMethod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        private bool PaymentMethodExists(int id)
        {
            return _context.PaymentMethods.Any(e => e.PaymentMethodId == id);
        }
    }
}
