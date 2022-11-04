using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public enum Brands
    { 
        Peugeot,
        Renault,
        Citroen,
        Audi,
        Ferrari
    }

    public abstract class Vehicle : IComparable
    {
        static int nextID = 1;

        private int id;
        private string name;
        private decimal dfPrice;
        private Brands brand;
        private Engine engine;
        private List<Option> options = new List<Option>();

        public int Id { get { return id; } }
        public string Name { get => name; set => name = value; }
        public decimal DfPrice { get => dfPrice; set => dfPrice = value; }
        public Brands Brand { get => brand; set => brand = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public List<Option> Options { get { return options; } }

        public Vehicle()
        {

        }

        public Vehicle(string name, decimal dfPrice, Brands brand, Engine engine)
        {
            this.id = nextID++;
            this.name = name;
            this.dfPrice = dfPrice;
            this.brand = brand;
            this.engine = engine;
        }

        /*Display all vehicle options*/
        public bool DisplayOptions()
        {
            int i = 0;
            Console.WriteLine("Informations sur les options du véhicule : {0}", Name);
            if (Options.Count != 0)
            {
                foreach (Option option in Options)
                {
                    Console.WriteLine("------- {0} -------", i++);
                    option.Display();
                }
            } else
            {
                Console.WriteLine("Ce véhicule n'a aucune options");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        /*Display all vehicle informations*/
        public virtual void DisplayAll()
        {
            Console.WriteLine("Id : {0}", Id);
            Console.WriteLine("Prix HT : {0}", DfPrice);
            Console.WriteLine("Prix TTC : {0}", TotalPrice());
            Console.WriteLine("Marque : {0}", Brand);
            engine.Display();
            DisplayOptions();
        }

        public void AddOption(Option option)
        {
            Options.Add(option);
        }

        public void DeleteOption(Option option)
        {
            Options.Remove(option);
        }

        public abstract decimal CalculateTaxes();

        public decimal TotalPrice()
        {
            decimal vehiclePriceIncludingTaxes = DfPrice + CalculateTaxes();
            decimal optionsPrice = 0;
            foreach (Option option in Options)
            {
                optionsPrice += option.Price;
            }
            return vehiclePriceIncludingTaxes + optionsPrice;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Vehicle vehicle = obj as Vehicle;
            if (vehicle != null)
                return this.dfPrice.CompareTo(vehicle.dfPrice);
            else
                throw new ArgumentException("Object is not a Vehicle");
        }
    }
}
