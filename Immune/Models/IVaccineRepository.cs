using System.Collections.Generic;

namespace Immune.Models
{
    public interface IVaccineRepository
    {
        Vaccine1 Add(Vaccine1 vaccine);

        IEnumerable<Vaccine1> GetAllVaccineDest();

        Vaccine1 GetVaccDestCity(string city);

        Vaccine1 GetRow(string city, string date);

        void Update(Vaccine1 vaccine);

        List<string> City();
    }
}
