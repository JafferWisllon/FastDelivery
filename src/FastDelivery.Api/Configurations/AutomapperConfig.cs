using AutoMapper;
using FastDelivery.Business;

namespace FastDelivery.Api
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Deliveryman, DeliverymanViewModel>().ReverseMap();
            CreateMap<Recipient, RecipientViewModel>().ReverseMap();
        }
    }
}
