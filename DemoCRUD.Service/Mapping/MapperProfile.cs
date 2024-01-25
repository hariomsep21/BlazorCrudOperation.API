using AutoMapper;
using DemoCRUD.DTO.ModelDtos;
using DemoCRUD.Model.Models;


namespace DealerApp.Service.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Students, StudentsDto>();
            CreateMap<Students, StudentsDto>().ReverseMap();

        }

    }
}
