
using AutoMapper;
using Tfg_hotelGestor.DTO_s.Requests;
using Tfg_hotelGestor.DTO_s.Response;
using Tfg_hotelGestor.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerRs>();
        CreateMap<CustomerCreateRq, Customer>();
        CreateMap<CustomerUpdateRq, Customer>();

        CreateMap<CustomerBasicInfo, CustomerBasicInfoRs>();
        CreateMap<CustomerBasicInfoRq , CustomerBasicInfo>();

        CreateMap<CustomerContactRq, CustomerContact>();
        CreateMap<CustomerContact, CustomerContactRs>();

        CreateMap<RoomType, RoomTypeRs>();
        CreateMap<RoomTypeRq,RoomType>();

        CreateMap<Room, RoomRs>();
        CreateMap<RoomRq, Room>();

        CreateMap<Vacancy, VacancyRs>();
        CreateMap<VacancyRq, Vacancy>();

        CreateMap<Invoice, InvoiceRs>();
        CreateMap<InvoiceRq, Invoice>();

        CreateMap<Product, ProductRs>();
        CreateMap<ProductRq, Product>();

        CreateMap<ProductType, ProductTypeRs>();
        CreateMap<ProductTypeRq, ProductType>();
        
        CreateMap<User, UserRs>();
        CreateMap<UserRq, User>();

        CreateMap<UserType, UserTypeRs>();
        CreateMap<UserTypeRq, UserType>();
    }
}
