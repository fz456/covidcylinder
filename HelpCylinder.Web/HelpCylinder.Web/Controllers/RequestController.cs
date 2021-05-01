using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpRequests.BusinessLogic.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace HelpCylinder.Web.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            RequestsBAL requestsBal = new RequestsBAL();
             var requestsList = requestsBal.GetRequestsList();
            return View(requestsList);
        }
    }
}
