using FastDelivery.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/recipient")]
    public class RecipientController : ControllerBase
    {
        private readonly IRecipientService _recipientService;
        public RecipientController(IRecipientService recipientService)
            => _recipientService = recipientService;

        //[HttpGet()]
        //[ProducesResponseType(typeof(IEnumerable<Recipient>), StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<Recipient>>> Get()
        //{
        //    return Ok();
        //    //return await _context.Recipients.ToListAsync();
        //}

        //[HttpGet("{id:int}")]
        //[ProducesResponseType(typeof(Recipient), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Recipient>> Get(int id)
        //{
        //    var recipient = await _context.Recipients.FindAsync(id);
        //    if (recipient is null)
        //        return NotFound();

        //    return recipient;
        //}

        //[HttpPost()]
        //[ProducesResponseType(typeof(Recipient), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<Recipient>> Create([FromBody] RecipientViewModel request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var recipient = new Recipient(request.Name, request.Street, request.Number, request.Complement, request.State, request.City, request.ZipCode);
        //        _context.Recipients.Add(recipient);
        //        await _context.SaveChangesAsync();
        //        return CreatedAtAction(nameof(Get), new { id = recipient.Id }, recipient);
        //    }

        //    return BadRequest();
        //}

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> Update(int id, [FromBody] RecipientViewModel request)
        //{
        //    var recipient = await _context.Recipients.FindAsync(id);
        //    if (recipient is null)
        //        return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        recipient.Name = request.Name;
        //        recipient.Street = request.Street;
        //        recipient.State = request.State;
        //        recipient.Number = request.Number;
        //        recipient.Complement = request.Complement;
        //        recipient.City = request.City;
        //        recipient.ZipCode = request.ZipCode;

        //        _context.Update(recipient);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return NoContent();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RecipientAlreadyExists(id))
        //                return NotFound();
        //            else
        //                throw;
        //        }
        //    }
        //    return BadRequest();
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var recipient = await _context.Recipients.FindAsync(id);
        //    if (recipient is null)
        //        return NotFound();

        //    _context.Remove(recipient);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //private bool RecipientAlreadyExists(int id)
        //{
        //    return (_context.Recipients?.Any(r => r.Id == id)).GetValueOrDefault();
        //}
    }
}
