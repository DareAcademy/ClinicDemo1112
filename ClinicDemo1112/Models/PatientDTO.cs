using ClinicDemo1112.helpers;
using System.ComponentModel.DataAnnotations;

namespace ClinicDemo1112.Models
{
    public class PatientDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill Patient Name")]
        public string Name { get; set; }

        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string Phone { get; set; }
        [BDateValidation]
        public DateTime BDate { get; set; }
        [Required(ErrorMessage = "Please fill Patient Gender")]
        public string Gender { get; set; }
        public int Country_Id { get; set; }

        public IFormFile ProfileImage { get; set; }
        public string ProfilePath { get; set; }

        public CountryDTO countryDTO { get; set; }

    }
}
