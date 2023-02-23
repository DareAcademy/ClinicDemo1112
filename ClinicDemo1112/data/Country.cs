using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicDemo1112.data
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Patient> liPatient { get; set; }
    }
}
