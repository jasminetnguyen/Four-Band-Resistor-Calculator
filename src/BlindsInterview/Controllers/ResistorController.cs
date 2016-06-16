using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BlindsInterview.Services.Models;

namespace BlindsInterview.Controllers {
    [Route("api/[controller]")]
    public class ResistorController : Controller {
        private ResistorService _resistorService;

        public ResistorController(ResistorService resistorService) {
            _resistorService = resistorService;
        }

        [HttpGet]
        public ActionResult Get() {

            var resistorsList = _resistorService.GetAllResistors();

            return Json(resistorsList);
        }
        
        [HttpPost]
        public ActionResult Post(string bandOne, string bandTwo, string multiplier, string tolerance) {
            var averageVal = _resistorService.CalculateOhmValue(bandOne, bandTwo, multiplier, tolerance);
            var toler = _resistorService.GetResistor(tolerance);


            return Json (new SolutionDTO {
                 Tolerance = toler.Tolerance,
                 AverageValue = averageVal
            });
        }

    }
}
