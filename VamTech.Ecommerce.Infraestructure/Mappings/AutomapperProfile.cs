using AutoMapper;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Mappings
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
            //offdetMappingExpression.ForMember(dto => dto.Description, mc => mc.MapFrom(e => e.Offer.OfferType.Description));
            //offdetMappingExpression.ForMember(dto => dto.PayN, mc => mc.MapFrom(e => e.Offer.OfferType.PayN));
            //offdetMappingExpression.ForMember(dto => dto.TakeM, mc => mc.MapFrom(e => e.Offer.OfferType.TakeM));
            //offdetMappingExpression.ForMember(dto => dto.PercDisc2unity, mc => mc.MapFrom(e => e.Offer.OfferType.PercDisc2unity));
            //offdetMappingExpression.ForMember(dto => dto.PercDiscountDirect, mc => mc.MapFrom(e => e.Offer.OfferType.PercDiscountDirect));
          

            CreateMap<OfferDetailDto, OfferDetail>();
                        
            CreateMap<OfferType, OfferTypeDto>();
            CreateMap<OfferTypeDto, OfferType>();

            CreateMap<ProductImageDto, ProductImage>();
            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            CreateMap<FeatureDto, Feature>();
            CreateMap<Feature, FeatureDto>();

            CreateMap<BehaviorDto, Behavior>();
            CreateMap<Behavior, BehaviorDto>();


            var prdftMappingExpression = CreateMap<ProductFeature, ProductFeatureDto>();
            prdftMappingExpression.ForMember(dto => dto.FeatureDesc, mc => mc.MapFrom(e => e.Feature.Description));

            var prdbvMappingExpression = CreateMap<BehaviorProduct, BehaviorProductDto>();
            prdbvMappingExpression.ForMember(dto => dto.BehaviorDesc, mc => mc.MapFrom(e => e.Behavior.Description));

            var prdcatMappingExpression = CreateMap<ProductCategory, ProductCategoryDto>();
            prdcatMappingExpression.ForMember(dto => dto.CategoryDesc, mc => mc.MapFrom(e => e.Subcategory.Category.Description));


            CreateMap<ProductFeatureDto, ProductFeature>();
            CreateMap<BehaviorProductDto, BehaviorProduct>();
            CreateMap<ProductCategoryDto, ProductCategory>();


            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<SubcategoryDto, Subcategory>();
            CreateMap<Subcategory, SubcategoryDto>();


            // var prdMappingExpression = CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<CompanyDto, Company>();
            
            //CreateMap<Company, CompanyDto>();
            var companyMappingExpression = CreateMap<Company, CompanyDto>();
            companyMappingExpression.ForMember(dto => dto.CountryName, mc => mc.MapFrom(e => e.Province.Country.ShortDesc));
            companyMappingExpression.ForMember(dto => dto.ProvinceName, mc => mc.MapFrom(e => e.Province.ShortDesc));
            companyMappingExpression.ForMember(dto => dto.CityName, mc => mc.MapFrom(e => e.City.ShortDesc));

        }
    }
}
