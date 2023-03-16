using ClinicDemo1112.Models;

namespace ClinicDemo1112.servicies
{
    public interface ICountryService
    {
        List<CountryDTO> LoadAll();
        CountryDTO Load(int Id);
    }
}
