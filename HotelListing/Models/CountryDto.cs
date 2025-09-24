using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CreateCountryDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ShortName { get; set; }

    }
    public class CountryDto : CreateCountryDto
    {
        public int Id { get; set; }
        public virtual IList<HotelDto>? Hotels { get; set; }

    }
}