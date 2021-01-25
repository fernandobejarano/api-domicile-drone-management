using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domicile.Drone.Management.DTO
{
    public class DTORouteFileRequest
    {
        public List<IFormFile> route { get; set; }
    }

    public class DTODroneRoute
    {
        public string CardinalPosition { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }

    }
}
