using ClinicDemo1112.data;
using ClinicDemo1112.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicDemo1112.servicies
{
    public class PatientServicies:IPatientService
    {
        ClinicContext context;
        ICountryService countryService;
        public PatientServicies(ClinicContext _context,ICountryService _countryService)
        {
            //context = new ClinicContext();
            context = _context;
            countryService = _countryService;
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
            patient.Path =patientDTO.ProfilePath;
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public void Update(PatientDTO patientDTO)
        {
            //context = new ClinicContext();
            Patient patient;
            patient = new Patient();
            patient.Id = patientDTO.Id;
            patient.Name = patientDTO.Name;
            patient.Phone = patientDTO.Phone;
            patient.BDate = patientDTO.BDate;
            patient.Country_Id = patientDTO.Country_Id;
            patient.Gender = patientDTO.Gender;
            patient.Path = patientDTO.ProfilePath;

            context.Patients.Attach(patient);
            context.Entry(patient).State = EntityState.Modified;
            context.SaveChanges();

        }


        public List<PatientDTO> LoadByName(string name)
        {
            //context = new ClinicContext();


            //List<Patient> liPatient = (from pat in context.Patients
            //                           where pat.Name == name
            //                           select pat).ToList();


            //List<Patient> liPatient = context.Patients.Include("country").Where(p => p.Name == name).ToList();
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
                    Country_Id = item.Country_Id,
                    ProfilePath=item.Path,
                    countryDTO=countryService.Load(item.Country_Id)
                    //countryDTO=new CountryDTO()
                    //{
                    //    Id=item.country.Id,
                    //    Name=item.country.Name
                    //}


                });
            }

            return patients;

        }

        public void Delete(int Id)
        {
            Patient patient = context.Patients.Find(Id);
            context.Patients.Remove(patient);
            context.SaveChanges();
        }

        public PatientDTO Load(int Id)
        {
            Patient patient = context.Patients.Find(Id);
            PatientDTO patientDTO = new PatientDTO()
            {
                Id = patient.Id,
                Name=patient.Name,
                BDate=patient.BDate,
                Country_Id=patient.Country_Id,
                Gender=patient.Gender,
                Phone=patient.Phone,
                ProfilePath=patient.Path
            };

            return patientDTO;
        }   
    }
}
