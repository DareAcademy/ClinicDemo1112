using ClinicDemo1112.Models;

namespace ClinicDemo1112.servicies
{
    public interface IPatientService
    {
        void Insert(PatientDTO patientDTO);

        List<PatientDTO> LoadByName(string name);

        void Delete(int Id);

        PatientDTO Load(int Id);

        void Update(PatientDTO patientDTO);
    }
}
