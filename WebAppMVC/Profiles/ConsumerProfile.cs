using AutoMapper;
using WebAppMVC.ViewModels;
using WebAppMVC.Dto;

namespace WebAppMVC.Profiles
{
    public class ConsumerProfile : Profile
    {
        public ConsumerProfile()
        {
            CreateMap<ConsumerViewModel,ViewDto>().ReverseMap();
           
        }

    }
}
