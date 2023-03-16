using ClinicDemo1112.data;
using ClinicDemo1112.Models;
using ClinicDemo1112.servicies;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDemo1112.Controllers
{
    public class PatientController : Controller
    {
        //PatientServicies patientService;
        //CountryServicies countryService;
        IPatientService patientService;
        ICountryService countryService;
        IConfiguration config;
        public PatientController(IPatientService _patientService,ICountryService _countryService,IConfiguration _config)
        {
            //patientService = new PatientServicies();
            //countryService = new CountryServicies();
            patientService = _patientService;
            countryService = _countryService;
            config = _config;


        }
        public IActionResult NewPatient()
        {
            ViewData["IsEdit"] = false;
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

            try
            {
                //string ImageName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Date.ToString() + "_" + vm.Patient.Name + vm.Patient.ProfileImage.FileName.Split('.')[1];
                string ImageName = Guid.NewGuid().ToString() + "." + vm.Patient.ProfileImage.FileName.Split('.')[1];

                vm.Patient.ProfileImage.CopyTo(new FileStream(config["UploadImages"] + ImageName, FileMode.Create));

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

                //if (ModelState.IsValid == true) {
                vm.Patient.ProfilePath = ImageName;
                patientService.Insert(vm.Patient);
                //}

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
                vm.countries = countryService.LoadAll();
                ViewData["IsEdit"] = true;
                return View("NewPatient", vm);
            }
            catch(Exception ex)
            {
                return View();
            }
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

        public IActionResult DeletePatient(int Id)
        {
            patientService.Delete(Id);
            List<PatientDTO> patients = new List<PatientDTO>();
            return View("PatientList", patients);

        }

        public IActionResult EditPatient(int Id)
        {
            ViewData["IsEdit"] = true;
            PatientDTO patientDTO = patientService.Load(Id);
            vmPatient vm = new vmPatient();
            vm.Patient = patientDTO;
            vm.countries = countryService.LoadAll();
            return View("NewPatient",vm);

        }

        public IActionResult Update(vmPatient vm) {

            string ImageName = Guid.NewGuid().ToString() + "." + vm.Patient.ProfileImage.FileName.Split('.')[1];

            vm.Patient.ProfileImage.CopyTo(new FileStream(config["UploadImages"] + ImageName, FileMode.Create));


            vm.Patient.ProfilePath = ImageName;

            patientService.Update(vm.Patient);
            ViewData["IsEdit"] = true;

            vm.countries = countryService.LoadAll();
            return View("NewPatient",vm);
        }
    }
}

