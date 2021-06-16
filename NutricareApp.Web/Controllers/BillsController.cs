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
    public class BillsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public BillsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<IEnumerable<BillModel>> GetBills()
        {
            var billList = await _context.Bills.ToListAsync();
            return billList.Select(c => new BillModel
            {
                BillId = c.BillId,
                ClientId = c.ClientId,
                Amount = c.Amount,
                Ruc = c.Ruc,
                BillDate = c.BillDate
            });
        }

        // GET: api/Bills/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBillById([FromRoute] int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return Ok(new BillModel
            {
                BillId = bill.BillId,
                ClientId = bill.ClientId,
                Amount = bill.Amount,
                Ruc = bill.Ruc,
                BillDate = bill.BillDate
            });
        }

        [HttpGet("[action]/{fecha1}/{fecha2}")]
        public async Task<IEnumerable<BillModel>> GetBillsBetweenDates([FromRoute] string fecha1, [FromRoute] string fecha2)
        {
            var billList = await _context.Bills.ToListAsync();
            List<Bill> bills = new List<Bill>();

            DateTime f1 = Convert.ToDateTime(fecha1);
            DateTime f2 = Convert.ToDateTime(fecha2);

            foreach (Bill bill in billList)
            {
                if (f1 <= bill.BillDate && bill.BillDate <= f2)
                    bills.Add(bill);
            }

            return bills.Select(c => new BillModel
            {
                BillId = c.BillId,
                ClientId = c.ClientId,
                Amount = c.Amount,
                Ruc = c.Ruc,
                BillDate = c.BillDate
            });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<BillModel>> GetBillByClient([FromRoute] int id)
        {
            var billList = await _context.Bills.ToListAsync();
            List<Bill> bills = new List<Bill>();

            foreach (Bill bill in billList)
            {
                if (bill.ClientId == id)
                    bills.Add(bill);
            }

            return bills.Select(c => new BillModel
            {
                BillId = c.BillId,
                ClientId = c.ClientId,
                Amount = c.Amount,
                Ruc = c.Ruc,
                BillDate = c.BillDate
            });
        }

        // PUT: api/Bills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutBill([FromBody] UpdateBillModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.BillId <= 0)
                return BadRequest();

            var bill = await _context.Bills.FirstOrDefaultAsync(c => c.BillId == model.BillId);

            if (bill == null)
                return NotFound();

            bill.BillId = model.BillId;
            bill.ClientId = model.ClientId;
            bill.Amount = model.Amount;
            bill.Ruc = model.Ruc;
            bill.BillDate = model.BillDate;

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

        // POST: api/Bills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBill([FromBody] CreateBillModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Bill bill = new Bill
            {
                ClientId = model.ClientId,
                Amount = model.Amount,
                Ruc = model.Ruc,
                BillDate = model.BillDate
            };

            _context.Bills.Add(bill);
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

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill([FromRoute] int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
                return NotFound();

            _context.Bills.Remove(bill);
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

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(c => c.ClientId == id);
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.BillId == id);
        }
    }
}
