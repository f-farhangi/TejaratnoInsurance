using API.Entities;
using API.Models;
using AutoMapper;

namespace API.Map
{
    public class ProductProfile : Profile
    {
        #region Constructor
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.CategoryTitle, opt => opt.MapFrom(src => src.Category.Title))
                .ReverseMap();

            CreateMap<Product, ProductForInsertDto>().ReverseMap();
            CreateMap<Product, ProductForUpdateDto>().ReverseMap();

        }

        #endregion
    }
}
