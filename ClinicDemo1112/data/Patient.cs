using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicDemo1112.data
{
    [Table("Patients")]
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }
        public DateTime BDate { get; set; }
        [ForeignKey("country")]
        public int Country_Id { get; set; }

        public Country country { get; set; }
    }
}
