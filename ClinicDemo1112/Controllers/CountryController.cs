using ClinicDemo1112.data;
using ClinicDemo1112.Models;
using ClinicDemo1112.servicies;
using Microsoft.AspNetCore.Mvc;

namespace ClinicDemo1112.Controllers
{
    public class CountryController : Controller
    {
        //CountryServicies countryService;

        ICountryService countryService;
        public CountryController(ICountryService _countryService)
        {
            //countryService = new CountryServicies();
            countryService = _countryService;

        }

        public IActionResult Index()
        {
            //ClinicContext context = new ClinicContext();
            ////List<Country> licountry = (from cnt in context.Countries
            ////                        select cnt).ToList();


            //List<Country> licountry = context.Countries.ToList();


            //List<CountryDTO> countries = new List<CountryDTO>();

            //foreach (Country country in licountry)
            //{
            //    CountryDTO countryDTO = new CountryDTO();
            //    countryDTO.Id = country.Id;
            //    countryDTO.Name = country.Name;
            //    countries.Add(countryDTO);
            //}

            //CountryServicies countryService = new CountryServicies();
            List<CountryDTO> countries= countryService.LoadAll();

            return View("CountryList", countries);
        }
    }
}
