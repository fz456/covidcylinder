using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpCylinder.BusinessLogic.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace HelpCylinder.Web.Controllers
{
    public class CylinderController : Controller
    {
        public IActionResult Index()
        {
            CylinderBAL cylinderBAL = new CylinderBAL();
            var availableCylinder = cylinderBAL.GetAvailableCylinderList(0);
            return View(availableCylinder);
        }
    }
}
