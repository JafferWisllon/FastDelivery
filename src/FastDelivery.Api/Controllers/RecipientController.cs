using FastDelivery.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/recipient")]
    public class RecipientController : ControllerBase
    {
        [HttpGet()]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(new Recipient() { Id = 1, Name = "Home" });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok(new Recipient() { Id = id });
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Recipient recipient)
        {
            return Ok(new Recipient() { Id = recipient.Id });
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(int id, [FromBody] Recipient recipient)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
