using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Mappings
{
    /// <summary>
    /// Represents a AutoMapper mapping profile for mapping between entities and DTOs.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Define mappings between Brand and BrandDto
          
            CreateMap<Labour, LabourDto>().ReverseMap();
            CreateMap<Units, UnitDto>().ReverseMap();
            CreateMap<RawMaterial, RawMaterialDto>().ReverseMap();
            CreateMap<PurchaseDetail, PurchaseDetailDto>().ReverseMap();
            CreateMap<Roles, RoleDto>().ReverseMap();
            CreateMap<Stocks, StockDto>().ReverseMap();
            CreateMap<StockUpdate, StockUpdateDto>().ReverseMap();
            CreateMap<MachineLogDetail, MachineLogDetailDto>().ReverseMap();
            CreateMap<MaterialHistory, MaterialHistoryDto>().ReverseMap();
            CreateMap<Attachments, AttachmentDto>().ReverseMap();
            CreateMap<CompanyDetails, CompanyDetailsDto>().ReverseMap();
            CreateMap<Billings, BillingDto>().ReverseMap();
            CreateMap<BillingDetailsWithoutGST, BillingDetailsWithoutGSTDto>().ReverseMap();
            CreateMap<Diesel, DieselDto>().ReverseMap();
            CreateMap<Trip, TripDto>().ReverseMap();


        }
    }
}
