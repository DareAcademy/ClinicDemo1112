using System.ComponentModel.DataAnnotations;

namespace ClinicDemo1112.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please fill Country Name")]
        public string Name { get; set; }

    }
}
