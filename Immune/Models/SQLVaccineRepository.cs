using System.Collections.Generic;

namespace Immune.Models
{
    public class SQLVaccineRepository : IVaccineRepository
    {
        private readonly AppDbContext _context;

        public SQLVaccineRepository(AppDbContext context)
        {
            _context = context;
        }

        Vaccine1 IVaccineRepository.Add(Vaccine1 vaccine)
        {
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
            return vaccine;
        }

        IEnumerable<Vaccine1> IVaccineRepository.GetAllVaccineDest()
        {
            return _context.Vaccines;
        }
        Vaccine1 IVaccineRepository.GetVaccDestCity(string city)
        {
            IEnumerable<Vaccine1> vaccines = _context.Vaccines;
            foreach (Vaccine1 vac in vaccines)
            {
                if (vac.city == city)
                {
                    return vac;
                }
            }
            return null;
        }

        List<string> IVaccineRepository.City()
        {
            IEnumerable<Vaccine1> temp = _context.Vaccines;
            List<string> city = new List<string>();
            foreach (Vaccine1 vac in temp)
            {
                if (!(city.Contains(vac.city)))
                {

                    city.Add(vac.city);
                }

            }
            return city;
        }

        Vaccine1 IVaccineRepository.GetRow(string city, string date)
        {
            IEnumerable<Vaccine1> vacc = _context.Vaccines;
            foreach(Vaccine1 vac in vacc)
            { 
                if(vac.city == city && vac.Date == date)
                {
                    return vac;
                }
            }
            return null;
        }

        void IVaccineRepository.Update(Vaccine1 vaccine)
        {
            var vac = _context.Vaccines.Attach(vaccine);
            vac.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        
    }
}
