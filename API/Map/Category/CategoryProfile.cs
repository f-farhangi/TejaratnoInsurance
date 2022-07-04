using API.Entities;
using API.Models;
using AutoMapper;

namespace API.Map
{
    public class CategoryProfile : Profile
    {
        #region Constructor

        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForInsertDto>().ReverseMap();
            CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        }

        #endregion
    }
}
