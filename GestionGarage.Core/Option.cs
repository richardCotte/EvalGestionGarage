using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public class Option
    {
        static int nextID = 1;

        private int id;
        private string name;
        private decimal price;

        public int Id { get { return id; } }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }

        public Option()
        {

        }

        public Option(string name, decimal price)
        {
            this.id = nextID++;
            this.name = name;
            this.price = price;
        }

        public void Display()
        {
            Console.WriteLine("Information sur l'option : {0}", Name);
            Console.WriteLine("Id : {0}", Id);
            Console.WriteLine("Prix : {0}", Price);
        }
    }
}
