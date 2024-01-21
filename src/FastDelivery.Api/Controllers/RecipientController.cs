using FastDelivery.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipientController : ControllerBase
    {
        [HttpGet]
        public Recipient Get()
        {
            var recipient = new Recipient()
            {
                Id = 1,
                Name = "Home",
                Street = "",
                City = "",
                Complement = "",
                Number = "",
                State = "state",
                ZipCode = ""
            };

            return recipient;
        }
    }
}
