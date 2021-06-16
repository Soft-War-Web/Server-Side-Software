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
    public class ClientsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public ClientsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<IEnumerable<ClientModel>> GetClients()
        {
            var clientList = await _context.Clients.ToListAsync();
            return clientList.Select(c => new ClientModel
            {
                ClientId = c.ClientId,
                Username = c.Username,
                Password = c.Password,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            });
        }

        // GET: api/Clients/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetClientById([FromRoute] int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(new ClientModel
            {
                ClientId = client.ClientId,
                Username = client.Username,
                Password = client.Password,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email                
            });
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutClient([FromBody] UpdateClientModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.ClientId <= 0)
                return BadRequest();

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == model.ClientId);

            if (client == null)
                return NotFound();

            client.Username = model.Username;
            client.Password = model.Password;
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.Email = model.Email;

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

        [HttpPut("[action]/{ClientId}/{RecipeId}")]
        public async Task<IActionResult> AddFavoriteRecipe([FromRoute] int ClientId, [FromRoute] int RecipeId)
        {
            var client = await _context.Clients.Include(c => c.Recipes).SingleAsync(c => c.ClientId == ClientId);
            var recipe = await _context.Recipes.SingleAsync(r => r.RecipeId == RecipeId);
            if (client == null || recipe == null)
            {
                return NotFound();
            }

            client.Recipes.Add(recipe);

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

        [HttpPut("[action]/{ClientId}/{RecipeId}")]
        public async Task<IActionResult> RemoveFavoriteRecipe([FromRoute] int ClientId, [FromRoute] int RecipeId)
        {
            var client = await _context.Clients.Include(c => c.Recipes).SingleAsync(c => c.ClientId == ClientId);
            var recipe = await _context.Recipes.SingleAsync(r => r.RecipeId == RecipeId);
            if (client == null || recipe == null)
            {
                return NotFound();
            }

            client.Recipes.Remove(recipe);

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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] CreateClientModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Client client = new Client
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CreatedAt = model.CreatedAt
            };

            _context.Clients.Add(client);
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

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
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
    }
}
