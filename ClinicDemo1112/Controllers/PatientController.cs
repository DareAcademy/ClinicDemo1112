using ClinicDemo1112.data;
using ClinicDemo1112.Models;
using ClinicDemo1112.servicies;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDemo1112.Controllers
{
    public class PatientController : Controller
    {
        PatientServicies patientService;
        CountryServicies countryService;
        public PatientController()
        {
            patientService = new PatientServicies();
            countryService = new CountryServicies();
        }
        public IActionResult NewPatient()
        {

            //// read data from country table
            //ClinicContext context = new ClinicContext();
            ////List<Country> licountry = (from cnt in context.Countries
            ////                        select cnt).ToList();


            //List<Country> licountry = context.Countries.ToList();
            //vmPatient vm;
            //vm = new vmPatient();
            //vm.countries = new List<CountryDTO>();

            //foreach (Country country in licountry)
            //{
            //    CountryDTO countryDTO = new CountryDTO();
            //    countryDTO.Id = country.Id;
            //    countryDTO.Name = country.Name;
            //    vm.countries.Add(countryDTO);
            //}

            //CountryServicies countryService = new CountryServicies();
            //List<CountryDTO> countries = countryService.LoadAll();

            vmPatient vm=new vmPatient();
            vm.countries= countryService.LoadAll();


            return View("NewPatient",vm);
        }

        public IActionResult Save(vmPatient vm)
        {

            //ClinicContext context = new ClinicContext();

            //Patient patient;
            //patient = new Patient();
            //patient.Name = vm.Patient.Name;
            //patient.Phone = vm.Patient.Phone;
            //patient.BDate = vm.Patient.BDate;
            //patient.Country_Id = vm.Patient.Country_Id;
            //patient.Gender = vm.Patient.Gender;

            //context.Patients.Add(patient);
            //context.SaveChanges();

            //PatientServicies patientService = new PatientServicies();
            patientService.Insert(vm.Patient);

            //List<Country> licountry = (from cnt in context.Countries
            //                           select cnt).ToList();

            //List<Country> licountry = context.Countries.ToList();

            //vm.countries = new List<CountryDTO>();

            //foreach (Country country in licountry)
            //{
            //    CountryDTO countryDTO = new CountryDTO();
            //    countryDTO.Id = country.Id;
            //    countryDTO.Name = country.Name;
            //    vm.countries.Add(countryDTO);
            //}

            //CountryServicies countryService = new CountryServicies();
            vm.countries= countryService.LoadAll();

            return View("NewPatient", vm);
        }

        public IActionResult PatientList()
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            return View(patients);
        }

        public IActionResult SearchPatient()
        {
            //ClinicContext context = new ClinicContext();
            string name = Request.Form["txtSearchPatientName"];

            //PatientServicies patientServicies = new PatientServicies();
            List<PatientDTO> patients = new List<PatientDTO>();
            patients= patientService.LoadByName(name);

            //List<Patient> liPatient = (from pat in context.Patients
            //                           where pat.Name == name
            //                           select pat).ToList();


            //List<Patient> liPatient = context.Patients.Where(p => p.Name == name).ToList();

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

            //List<PatientDTO> patients = new List<PatientDTO>();

            //foreach (Patient item in liPatient)
            //{
            //    patients.Add(new PatientDTO()
            //    {
            //       Id=item.Id,
            //       Name=item.Name,
            //       Phone=item.Phone,
            //       Gender=item.Gender,
            //       BDate=item.BDate,
            //       Country_Id=item.Country_Id
            //    });
            //}



            // get all patient with the name
                return View("PatientList", patients);
        }
    }
}

