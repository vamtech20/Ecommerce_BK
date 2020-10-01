using AutoMapper;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<Offer, OfferDto>();
            CreateMap<OfferDto, Offer>();


            CreateMap<OfferDetail, OfferDetailDto>();
            CreateMap<OfferDetailDto, OfferDetail>();
                        
            CreateMap<OfferType, OfferTypeDto>();
            CreateMap<OfferTypeDto, OfferType>();

            CreateMap<ProductImageDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();





        }
    }
}
