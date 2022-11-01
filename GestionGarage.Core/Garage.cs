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
        private List<Vehicle> vehicles;
        private List<Engine> avalaibleEngines;
        private List<Option> avalaibleOptions;

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
            vehicles.Add(vehicle);
        }

        public void DisplayAllVehicles()
        {
            Console.WriteLine("Voici la liste de tout les véhicules :");
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine("");
                Console.WriteLine("Véhicule : {0} {1}", vehicle.Brand, vehicle.Name);
                Console.WriteLine("Id : {0}", vehicle.Id);
                Console.WriteLine("");
            }
        }

        public void DisplayCars()
        {
            Console.WriteLine("Voici la liste de toutes les voitures :");
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Voiture : {0} {1}", vehicle.Brand, vehicle.Name);
                    Console.WriteLine("Id : {0}", vehicle.Id);
                    Console.WriteLine("");
                }
            }
        }

        public void DisplayMotorcycles()
        {
            Console.WriteLine("Voici la liste de toutes les motos :");
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Moto : {0} {1}", vehicle.Brand, vehicle.Name);
                    Console.WriteLine("Id : {0}", vehicle.Id);
                    Console.WriteLine("");
                }
            }
        }

        public void DisplayTrucks()
        {
            Console.WriteLine("Voici la liste de tous les camions :");
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Camion : {0} {1}", vehicle.Brand, vehicle.Name);
                    Console.WriteLine("Id : {0}", vehicle.Id);
                    Console.WriteLine("");
                }
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
    }
}
