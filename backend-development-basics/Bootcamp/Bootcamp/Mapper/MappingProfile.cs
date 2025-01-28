using AutoMapper;
using Bootcamp.DTOs;
using Bootcamp.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bootcamp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bootcamper, BootcamperDto>()
                .ForMember(dest => dest.MentorName, opt => opt.MapFrom(src => src.Mentor.Name));

            CreateMap<CreateBootcamperDto, Bootcamper>();

            CreateMap<Mentor, MentorDto>()
                .ForMember(dest => dest.Bootcampers, opt => opt.MapFrom(src => src.Bootcampers.Select(b => b.Name).ToList()));

            CreateMap<CreateMentorDto, Mentor>();
        }
    }
}
