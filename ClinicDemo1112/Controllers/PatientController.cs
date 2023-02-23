using ClinicDemo1112.data;
using ClinicDemo1112.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDemo1112.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult NewPatient()
        {

            // read data from country table
            ClinicContext context = new ClinicContext();
            List<Country> licountry = (from cnt in context.Countries
                                    select cnt).ToList();

            vmPatient vm;
            vm = new vmPatient();
            vm.countries = new List<CountryDTO>();

            foreach (Country country in licountry)
            {
                CountryDTO countryDTO = new CountryDTO();
                countryDTO.Id = country.Id;
                countryDTO.Name = country.Name;
                vm.countries.Add(countryDTO);
            }




            return View("NewPatient",vm);
        }

        public IActionResult Save(vmPatient vm)
        {

            ClinicContext context = new ClinicContext();

            Patient patient;
            patient = new Patient();
            patient.Name = vm.Patient.Name;
            patient.Phone = vm.Patient.Phone;
            patient.BDate = vm.Patient.BDate;
            patient.Country_Id = vm.Patient.Country_Id;
            patient.Gender = vm.Patient.Gender;

            context.Patients.Add(patient);
            context.SaveChanges();
            
            List<Country> licountry = (from cnt in context.Countries
                                       select cnt).ToList();

            
            vm.countries = new List<CountryDTO>();

            foreach (Country country in licountry)
            {
                CountryDTO countryDTO = new CountryDTO();
                countryDTO.Id = country.Id;
                countryDTO.Name = country.Name;
                vm.countries.Add(countryDTO);
            }

            return View("NewPatient", vm);
        }
    }
}

