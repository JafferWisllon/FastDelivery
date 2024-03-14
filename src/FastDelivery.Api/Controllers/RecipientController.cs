using AutoMapper;
using FastDelivery.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FastDelivery.Api
{
    [Authorize]
    [ApiController]
    [Route("api/recipient")]
    public class RecipientController : BaseController
    {
        private readonly IRecipientService _recipientService;
        private readonly IRecipientRepository _recipientRepository;
        private readonly IMapper _mapper;

        public RecipientController(
            IRecipientService recipientService, IRecipientRepository recipientRepository, INotifier notifier,
            IMapper mapper)
                : base(notifier)
        {
            _recipientService = recipientService;
            _recipientRepository = recipientRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Recipient>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RecipientViewModel>>> Get()
        {

            var recipients = await _recipientRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<RecipientViewModel>>(recipients));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecipientViewModel>> Get(Guid id)
        {
            var recipient = await _recipientRepository.GetById(id);
            if (recipient is null)
                return NotFound();

            return Ok(_mapper.Map<RecipientViewModel>(recipient));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Recipient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Recipient>> Create([FromBody] RecipientViewModel request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _recipientService.Add(_mapper.Map<Recipient>(request));
            return CustomResponse(HttpStatusCode.Created, request);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Update(Guid id, [FromBody] RecipientViewModel request)
        {
            if (id != request.Id)
            {
                NotifyError("Ids not match");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _recipientService.Update(_mapper.Map<Recipient>(request));
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var recipient = await _recipientRepository.GetById(id);
            if (recipient is null)
                return NotFound();

            await _recipientService.Remove(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
