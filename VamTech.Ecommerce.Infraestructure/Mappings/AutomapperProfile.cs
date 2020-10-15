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

            CreateMap<FeatureDto, FeatureDto>();
            CreateMap<FeatureDto, FeatureDto>();

            //CreateMap<ProductFeature, ProductFeatureDto>();
            var prdftMappingExpression = CreateMap<ProductFeature, ProductFeatureDto>();
            prdftMappingExpression.ForMember(dto => dto.FeatureDesc, mc => mc.MapFrom(e => e.Feature.Description));


            CreateMap<ProductFeatureDto, ProductFeature>();
            CreateMap<ProductFeatureDto, ProductFeature>();

            //CreateMap<Product, ProductDto>();
            var prdMappingExpression = CreateMap<Product, ProductDto>();
            prdMappingExpression.ForMember(dto => dto.LongDesc, mc => mc.MapFrom(e => e.Description + "- "+ e.Brand.Description));
          
            CreateMap<ProductDto, Product>();

          


        }
    }
}
