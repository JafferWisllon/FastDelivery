using FastDelivery.Api.Data;
using FastDelivery.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/recipient")]
    public class RecipientController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public RecipientController(ApiDbContext context)
            => _context = context;

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Recipient>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Recipient>>> Get()
        {
            return await _context.Recipients.ToListAsync();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Recipient>> Get(int id)
        {
            var recipient = await _context.Recipients.FindAsync(id);
            if (recipient is null)
                return NotFound();

            return recipient;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Recipient>> Create([FromBody] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                _context.Recipients.Add(recipient);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = recipient.Id }, recipient);
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Update(int id, [FromBody] Recipient request)
        {
            var recipient = await _context.Recipients.FindAsync(id);
            if (recipient is null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Entry(recipient).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipientAlreadyExists(id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var recipient = await _context.Recipients.FindAsync(id);
            if (recipient is null)
                return NotFound();

            _context.Remove(recipient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RecipientAlreadyExists(int id)
        {
            return (_context.Recipients?.Any(r => r.Id == id)).GetValueOrDefault();
        }
    }
}
