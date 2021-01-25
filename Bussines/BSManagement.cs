using Api.Domicile.Drone.Management.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domicile.Drone.Management.Bussines
{
    public class BSManagement
    {
        // Globals
        DTODroneRoute route = new DTODroneRoute();
        List<string> ListRoutes = new List<string>();
        string pathFile = AppDomain.CurrentDomain.BaseDirectory;

        public List<string> ReadFile(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    ListRoutes.Add(reader.ReadLine().ToString());
            }
            return ListRoutes;
        }

        public DTODroneRoute MapInitialRoute()
        {
            return new DTODroneRoute()
            {
                CardinalPosition = "N",
                XPosition = 0,
                YPosition = 0
            };
        }

        public DTODroneRoute MoveCardinalPointForward(DTODroneRoute route)
        {
            switch (route.CardinalPosition)
            {
                case "N":
                    route.YPosition += 1;
                    break;
                case "O":
                    route.XPosition -= 1;
                    break;
                case "S":
                    route.YPosition -= 1;
                    break;
                case "E":
                    route.XPosition += 1;
                    break;
                default: return null;
            }
            return route;
        }

        public string CardinalPointValidatorToTheLeft(string cardinalPoint)
        {
            switch (cardinalPoint)
            {
                case "N":
                    return "O";
                case "O":
                    return "S";
                case "S":
                    return "O";
                case "E":
                    return "N";
                default: return null;
            }
        }
    }
}
