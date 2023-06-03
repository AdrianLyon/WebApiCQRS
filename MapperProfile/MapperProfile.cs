using AutoMapper;

namespace CQRSPractice.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}