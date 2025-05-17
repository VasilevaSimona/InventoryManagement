using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Models;

namespace InventoryManagement.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }

    }
}
