using ClinicDemo1112.data;
using ClinicDemo1112.Models;

namespace ClinicDemo1112.servicies
{
    public class PatientServicies
    {
        ClinicContext context;

        public PatientServicies()
        {
            context = new ClinicContext();
        }

        public void Insert(PatientDTO patientDTO)
        {
            //context = new ClinicContext();
            Patient patient;
            patient = new Patient();
            patient.Name = patientDTO.Name;
            patient.Phone = patientDTO.Phone;
            patient.BDate = patientDTO.BDate;
            patient.Country_Id = patientDTO.Country_Id;
            patient.Gender = patientDTO.Gender;

            context.Patients.Add(patient);
            context.SaveChanges();
        }


        public List<PatientDTO> LoadByName(string name)
        {
            //context = new ClinicContext();


            //List<Patient> liPatient = (from pat in context.Patients
            //                           where pat.Name == name
            //                           select pat).ToList();


            List<Patient> liPatient = context.Patients.Where(p => p.Name == name).ToList();

            //List<PatientDTO> patients = new List<PatientDTO>();

            //foreach (Patient item in liPatient)
            //{
            //    PatientDTO patientDTO = new PatientDTO();
            //    patientDTO.Name = item.Name;
            //    patientDTO.Country_Id = item.Country_Id;
            //    patientDTO.BDate = item.BDate;
            //    patientDTO.Gender = item.Gender;
            //    patientDTO.Id = item.Id;
            //    patientDTO.Phone = item.Phone;
            //    patients.Add(patientDTO);
            //}

            List<PatientDTO> patients = new List<PatientDTO>();

            foreach (Patient item in liPatient)
            {
                patients.Add(new PatientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    Gender = item.Gender,
                    BDate = item.BDate,
                    Country_Id = item.Country_Id
                });
            }

            return patients;

        }
    }
}
