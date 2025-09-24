using HotelListing.Entities;
using HotelListing.Models;

namespace HotelListing.Configurations
{
    public class MapperInitializer : AutoMapper.Profile
    {
        public MapperInitializer()
        {
                CreateMap<Country, CountryDto>().ReverseMap();
                CreateMap<Country, CreateCountryDto>().ReverseMap();
                CreateMap<Hotel, HotelDto>().ReverseMap();
                CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        }
    }
}
