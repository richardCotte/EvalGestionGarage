using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public class Garage
    {
        private string garageName;
        private List<Vehicle> vehicles = new List<Vehicle>();
        private List<Engine> avalaibleEngines = new List<Engine>();
        private List<Option> avalaibleOptions = new List<Option>();

        public string GarageName { get => garageName; set => garageName = value; }
        public List<Vehicle> Vehicles { get { return vehicles; } }
        public List<Engine> AvalaibleEngines { get { return avalaibleEngines; } }
        public List <Option> AvalaibleOptions { get { return avalaibleOptions; } }

        public Garage()
        {

        }

        public Garage (string garageName)
        {
            this.garageName = garageName;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void DisplayAllVehicles()
        {
            int i = 0;
            Console.WriteLine("Voici la liste de tout les véhicules :");
            if (Vehicles.Count != 0)
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    Console.WriteLine("------- {0} -------", i++);
                    Console.WriteLine("Véhicule : {0} {1}", vehicle.Brand, vehicle.Name);
                    Console.WriteLine("Id : {0}", vehicle.Id);
                    Console.WriteLine("");
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicule dans le garage pour l'instant");
            }
        }

        public void DisplayCars()
        {
            bool isCarInTheGarage = false;
            int i = 0;
            Console.WriteLine("Voici la liste de toutes les voitures :");
            if (Vehicles.Count != 0)
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Car)
                    {
                        Console.WriteLine("------- {0} -------", i++);
                        Console.WriteLine("Voiture : {0} {1}", vehicle.Brand, vehicle.Name);
                        Console.WriteLine("Id : {0}", vehicle.Id);
                        Console.WriteLine("");
                        isCarInTheGarage = true;
                    }
                }
                if (!isCarInTheGarage)
                {
                    Console.WriteLine("Il n'y a pas de voiture dans le garage");
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicule dans le garage pour l'instant");
            }
        }

        public void DisplayMotorcycles()
        {
            bool isMotoInTheGarge = false;
            int i = 0;
            Console.WriteLine("Voici la liste de toutes les motos :");
            if (Vehicles.Count != 0)
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Car)
                    {
                        Console.WriteLine("------- {0} -------", i++);
                        Console.WriteLine("Moto : {0} {1}", vehicle.Brand, vehicle.Name);
                        Console.WriteLine("Id : {0}", vehicle.Id);
                        Console.WriteLine("");
                        isMotoInTheGarge = true;
                    }
                }
                if (!isMotoInTheGarge)
                {
                    Console.WriteLine("Il n'y a pas de moto dans le garage");
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicule dans le garage pour l'instant");
            }
        }

        public void DisplayTrucks()
        {
            bool isTruckInTheGarage = false;
            int i = 0;
            Console.WriteLine("Voici la liste de tous les camions :");
            if (Vehicles.Count != 0)
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle is Car)
                    {
                        Console.WriteLine("------- {0} -------", i++);
                        Console.WriteLine("Camion : {0} {1}", vehicle.Brand, vehicle.Name);
                        Console.WriteLine("Id : {0}", vehicle.Id);
                        Console.WriteLine("");
                        isTruckInTheGarage = true;
                    }
                }
                if (!isTruckInTheGarage)
                {
                    Console.WriteLine("Il n'y a pas de camion dans le garage");
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicule dans le garage pour l'instant");
            }
        }

        public void sortVehicles()
        {
            vehicles.Sort();
        }

        public void AddOption(Option option)
        {
            avalaibleOptions.Add(option);
        }

        public void AddEngine(Engine engine)
        {
            avalaibleEngines.Add(engine);
        }

        public void DeleteVehicleFromList(int vehicleIndex)
        {
            try
            {
                vehicles.RemoveAt(vehicleIndex);
            } catch (Exception e)
            {
                throw new Exception("Aucun véhicule dans la liste à l'index donné", e);
            }
        }
    }
}
