using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public enum EngineType
    {
        Diesel,
        Essence,
        Hybride,
        Electrique
    }

    public class Engine
    {
        static int nextID = 1;

        private int id;
        private string name;
        private EngineType type;
        private int power;

        public int Id { get { return id; } }
        public string Name { get => name; set => name = value; }
        public EngineType Type { get => type; set => type = value; }
        public int Power { get => power; set => power = value; }

        public Engine()
        {

        }

        public Engine(string name, EngineType type, int power)
        {
            this.id = nextID++;
            this.name = name;
            this.type = type;
            this.power = power;
        }

        public void Display()
        {
            Console.WriteLine("Information sur le moteur : {0}", Id);
            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("Type : {0}", Type);
            Console.WriteLine("Puissance : {0}", Power);
        }
    }
}
