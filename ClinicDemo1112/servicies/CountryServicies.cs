using ClinicDemo1112.data;
using ClinicDemo1112.Models;

namespace ClinicDemo1112.servicies
{
    public class CountryServicies:ICountryService
    {
        ClinicContext context;
        public CountryServicies(ClinicContext _context)
        {
            context = _context;
        }
        public List<CountryDTO> LoadAll()
        {
            //ClinicContext context = new ClinicContext();
            //List<Country> licountry = (from cnt in context.Countries
            //                        select cnt).ToList();

            List<Country> licountry = context.Countries.ToList();

            List<CountryDTO> countries = new List<CountryDTO>();

            foreach (Country country in licountry)
            {
                CountryDTO countryDTO = new CountryDTO();
                countryDTO.Id = country.Id;
                countryDTO.Name = country.Name;
                countries.Add(countryDTO);
            }

            return countries;

        }

        public CountryDTO Load(int Id)
        {
            Country country = context.Countries.Find(Id);

            //CountryDTO countryDTO = new CountryDTO();
            //countryDTO.Id = country.Id;
            //countryDTO.Name = country.Name;

            CountryDTO countryDTO = new CountryDTO()
            {
                Id = country.Id,
                Name = country.Name
            };

            return countryDTO;
        }
    }
}
