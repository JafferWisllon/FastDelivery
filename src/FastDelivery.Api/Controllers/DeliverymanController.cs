using AutoMapper;
using FastDelivery.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FastDelivery.Api
{
    [ApiController]
    [Route("/api/deliveryman")]
    [Authorize(Roles = "Admin")]
    public class DeliverymanController : BaseController
    {
        private readonly IDeliverymanService _service;
        private readonly IDeliverymanRepository _repository;
        private readonly IMapper _mapper;

        public DeliverymanController(IDeliverymanService service, IDeliverymanRepository repository, IMapper mapper, INotifier notifier)
            : base(notifier)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<DeliverymanViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DeliverymanViewModel>>> Index()
        {
            var deliverymen = await _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<DeliverymanViewModel>>(deliverymen));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DeliverymanViewModel>> Index(Guid id)
        {
            var deliveryman = await _repository.GetById(id);
            if (deliveryman is null)
                return NotFound();

            return Ok(_mapper.Map<DeliverymanViewModel>(deliveryman)); ;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DeliverymanViewModel>> Create([FromBody] DeliverymanViewModel request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Add(_mapper.Map<Deliveryman>(request));

            return CustomResponse(HttpStatusCode.Created, request);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<DeliverymanViewModel>> Put(Guid id, [FromBody] DeliverymanViewModel request)
        {
            if (id != request.Id)
            {
                NotifyError("Ids not match");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Update(_mapper.Map<Deliveryman>(request));
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<DeliverymanViewModel>> Delete(Guid id)
        {
            var deliveryman = await _repository.GetById(id);
            if (deliveryman is null)
                return NotFound();

            await _service.Remove(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
