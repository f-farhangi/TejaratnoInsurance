using API.Entities;
using API.Models;
using AutoMapper;

namespace API.Map
{
    public class BasketProfile : Profile
    {
        #region Constructor

        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();

            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Product.Title)).ReverseMap();
        }

        #endregion
    }
}
