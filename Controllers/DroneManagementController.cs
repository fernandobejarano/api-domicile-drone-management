using Api.Domicile.Drone.Management.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domicile.Drone.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneManagementController : ControllerBase
    {
        /// <summary>
        /// </summary>
        /// <param name="routeFile"></param>
        /// <returns></returns>
        [Route("PostReceiveRoutes")]
        [HttpPost]
        public async Task<IActionResult> PostReceiveRoutes([FromForm] DTORouteFileRequest routesFile)
        {
            return Ok();
        }
    }
