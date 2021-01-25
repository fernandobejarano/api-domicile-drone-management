using Api.Domicile.Drone.Management.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domicile.Drone.Management.Bussines
{
    public class BSManagement
    {
        // Globals
        DTODroneRoute route = new DTODroneRoute();
        List<string> ListRoutes = new List<string>();
        string pathFile = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\net5.0", "ResultFiles");
        string path = string.Empty;
        int cont = 0;

        public void FileManagement(DTORouteFileRequest routesFile)
        {
            foreach (var order in routesFile.route)
            {
                cont++;
                ListRoutes = ReadFile(order);
                if (ListRoutes != null)
                {
                    WritePathResult("out0" + cont);
                    ValidatorRules(ListRoutes);
                }
            }
        }

        public void WritePathResult(string filename)
        {
            string result = string.Empty;
            path = string.Format("{0}{1}.txt", pathFile, filename);
            if (!Directory.Exists(path))
                File.WriteAllText(path, "==Reporte de entregas==");
        }

        public void EditPathResult(string pathfile, string textResult)
        {
            if (!Directory.Exists(path))
                File.AppendAllText(pathfile, Environment.NewLine + textResult);
        }

        public List<string> ReadFile(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    ListRoutes.Add(reader.ReadLine().ToString());
            }
            return ListRoutes;
        }

        public void ValidatorRules(List<string> routes)
        {
            string letter = string.Empty;
            foreach (var item in routes)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    letter = item[i].ToString();
                    if ((i == 0) && (route.CardinalPosition == null))
                        route = ValidatorByLetter(MapInitialRoute(), letter);
                    else if (i > 0 || (route.CardinalPosition != null))
                        route = ValidatorByLetter(route, letter);
                }
                EditPathResult(path, string.Format("({0},{1}) {2}", route.XPosition, route.YPosition, HomologateCardinalPosition(route.CardinalPosition)));
            }
        }

        public string HomologateCardinalPosition(string cardinalPosition)
        {
            switch (cardinalPosition)
            {
                case "N":
                    return "Dirección Norte";
                case "S":
                    return "Dirección Sur";
                case "E":
                    return "Dirección Este";
                case "O":
                    return "Dirección Oeste";
                default:
                    return null;
            }
        }


        public DTODroneRoute ValidatorByLetter(DTODroneRoute route, string letter)
        {
            switch (letter)
            {
                case "A":
                    return MoveCardinalPointForward(route);
                case "I":
                    route.CardinalPosition = CardinalPointValidatorToTheLeft(route.CardinalPosition);
                    break;
                case "D":
                    route.CardinalPosition = CardinalPointValidatorToTheRight(route.CardinalPosition);
                    break;
                default:
                    break;
            }
            return route;
        }

        public string CardinalPointValidatorToTheRight(string cardinalPoint)
        {
            switch (cardinalPoint)
            {
                case "N":
                    return "E";
                case "E":
                    return "S";
                case "S":
                    return "E";
                case "O":
                    return "N";
                default: return null;
            }

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

        public DTODroneRoute MapInitialRoute()
        {
            return new DTODroneRoute()
            {
                CardinalPosition = "N",
                XPosition = 0,
                YPosition = 0
            };
        }
    }
}
