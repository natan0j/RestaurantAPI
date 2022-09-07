using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile //Konstruktor dla mapowań
    {
        public RestaurantMappingProfile() 
        {
            CreateMap<Restaurant, RestaurantDto>() // pierwsza zmienna to obiekt a drugi na jaki mapujemy
                //Z tego tworzymy po prostu oddzielny model jaki sobie potrzebujemy
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>(); //DishDto przydaje sie nam do nowych dań

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address()
                { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
        }
    }
}
