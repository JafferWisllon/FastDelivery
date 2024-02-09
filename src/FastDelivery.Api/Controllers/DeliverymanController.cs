using FastDelivery.Api.Data;
using FastDelivery.Api.Models;
using FastDelivery.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Api.Controllers
{
    [ApiController]
    [Route("/api/deliveryman")]
    [Authorize(Roles = "Admin")]
    public class DeliverymanController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DeliverymanController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Deliveryman>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Deliveryman>>> Index()
        {
            return await _context.Deliverymen.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Deliveryman>> Index(int id)
        {
            var deliveryman = await _context.Deliverymen.FirstOrDefaultAsync(x => x.Id == id);
            if (deliveryman is null)
                return NotFound();

            return deliveryman;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Deliveryman>> Create([FromBody] DeliverymanViewModel request)
        {
            if (ModelState.IsValid)
            {
                var deliveryman = new Deliveryman(request.Name, request.AvatarId, request.Email);
                _context.Deliverymen.Add(deliveryman);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Index), new { id = deliveryman.Id }, deliveryman);
            }
            return BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Deliveryman>> Put(int id, [FromBody] DeliverymanViewModel request)
        {
            var deliveryman = await _context.Deliverymen.FirstOrDefaultAsync(x => x.Id == id);
            if (deliveryman is null)
                return NotFound();

            if (ModelState.IsValid)
            {
                deliveryman.AvatarId = request.AvatarId;
                deliveryman.Email = request.Email;
                deliveryman.Name = request.Name;
                deliveryman.UppdatedAt = DateTime.UtcNow;

                _context.Update(deliveryman);
                try
                {
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliverymanAlreadyExists(id))
                        return NotFound();
                    else
                        throw;
                }
            }

            return BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Deliveryman>> Delete(int id)
        {
            var deliveryman = await _context.Deliverymen.FirstOrDefaultAsync(x => x.Id == id);
            if (deliveryman is null)
                return NotFound();

            try
            {
                _context.Remove(deliveryman);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool DeliverymanAlreadyExists(int id)
        {
            return (_context.Deliverymen?.Any(r => r.Id == id)).GetValueOrDefault();
        }
    }
}
