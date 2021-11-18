using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities.Requests;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class VaccineController : Controller
    {
        private readonly IVaccineService _vaccineService;

        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        public IActionResult Index([FromQuery] PaginationRequest paginationRequest)
        {
            List<Vaccine> vaccines = _vaccineService.GetAll(paginationRequest);

            return View(vaccines);
        }

        public IActionResult Create()
        {

            return View();
        }

        public IActionResult Store([FromForm] CreateVaccineRequest createVaccineRequest)
        {
            _vaccineService.Create(createVaccineRequest);

            return RedirectToAction("Index", "Vaccine");
        }


        public IActionResult Edit([FromRoute] int id)
        {
            Vaccine vaccine = _vaccineService.GetByFunc(u => u.Id == id);

            if(vaccine == null)
            {
                throw new Exception($"Not found Vaccine by id - {id}");
            }

            return View(vaccine);
        }

        public IActionResult Update([FromRoute] int id, [FromForm] UpdateVaccineRequest updateVaccineRequest)
        {
            _vaccineService.Update(id, updateVaccineRequest);

            return RedirectToAction("Index", "Vaccine");
        }

        public IActionResult Remove([FromRoute] int id)
        {
            _vaccineService.Remove(id);

            return RedirectToAction("Index", "Vaccine");
        }

        public IActionResult UploadFromFile([FromForm] UploadFileRequest uploadFileRequest)
        {
            _vaccineService.UploadFile(uploadFileRequest);

            return RedirectToAction("Index", "Vaccine");
        }
    }
}
