using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Immune.Models;

namespace Immune.Controllers
{
    public class VaccineController : Controller
    {
        private readonly IVaccineRepository _vaccRepository;

        public VaccineController(IVaccineRepository vaccRepository)
        {
            _vaccRepository = vaccRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Vaccine1> vacc = _vaccRepository.GetAllVaccineDest();

            return View(vacc);
        }

        public IActionResult AddCenter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCenter(Vaccine1 model)
        {
            if (ModelState.IsValid)
            {

                
                    Vaccine1 vacc = new Vaccine1
                    {
                        city = model.city,
                        Dose1 = model.Dose1,
                        Dose2 = model.Dose2,
                        Date = model.Date,
                    };
                    _vaccRepository.Add(vacc);
                    IEnumerable<Vaccine1> vac = _vaccRepository.GetAllVaccineDest();
                    return RedirectToAction("Index", vac);

                
                
            }
            return View();
        }

        
    }
}
