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


           
            var offdetMappingExpression = CreateMap<OfferDetail, OfferDetailDto>();
            offdetMappingExpression.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Offer.OfferType.Description));
            offdetMappingExpression.ForMember(dto => dto.PayN, mc => mc.MapFrom(e => e.Offer.OfferType.PayN));
            offdetMappingExpression.ForMember(dto => dto.TakeM, mc => mc.MapFrom(e => e.Offer.OfferType.TakeM));
            offdetMappingExpression.ForMember(dto => dto.PercDisc2unity, mc => mc.MapFrom(e => e.Offer.OfferType.PercDisc2unity));
            offdetMappingExpression.ForMember(dto => dto.PercDiscountDirect, mc => mc.MapFrom(e => e.Offer.OfferType.PercDiscountDirect));
            offdetMappingExpression.ForMember(dto => dto.TotalPriceOffer, mc => mc.MapFrom(e => e.Offer.TotalPriceOffer));
            offdetMappingExpression.ForMember(dto => dto.IsActive, mc => mc.MapFrom(e => e.Offer.IsActive));
            offdetMappingExpression.ForMember(dto => dto.ValidFrom, mc => mc.MapFrom(e => e.Offer.ValidFrom));
            offdetMappingExpression.ForMember(dto => dto.ValidTo, mc => mc.MapFrom(e => e.Offer.ValidTo));


            CreateMap<OfferDetailDto, OfferDetail>();
                        
            CreateMap<OfferType, OfferTypeDto>();
            CreateMap<OfferTypeDto, OfferType>();

            CreateMap<ProductImageDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            CreateMap<FeatureDto, FeatureDto>();
            CreateMap<FeatureDto, FeatureDto>();

            
            var prdftMappingExpression = CreateMap<ProductFeature, ProductFeatureDto>();
            prdftMappingExpression.ForMember(dto => dto.FeatureDesc, mc => mc.MapFrom(e => e.Feature.Description));


            CreateMap<ProductFeatureDto, ProductFeature>();
            CreateMap<ProductFeatureDto, ProductFeature>();

            
            var prdMappingExpression = CreateMap<Product, ProductDto>();
          
          


            CreateMap<ProductDto, Product>();

          


        }
    }
}
