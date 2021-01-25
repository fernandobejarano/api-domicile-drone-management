using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domicile.Drone.Management.Controllers
{
    public class DroneManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
