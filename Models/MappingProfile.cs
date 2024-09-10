
using AutoMapper;
using CustomApi.Models; // Replace with the correct namespace for Product

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
