using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public class Motorcycle : Vehicle
    {
        private int cylinder;

        public int Cylinder { get => cylinder; set => cylinder = value; }

        public Motorcycle(string name, decimal dfPrice, Brands brand, Engine engine, int cylinder)
            : base(name, dfPrice, brand, engine)
        {
            this.cylinder = cylinder;
        }

        public override decimal CalculateTaxes()
        {
            return Math.Truncate(Cylinder * 0.3m);
        }

        public override void DisplayAll()
        {
            Console.WriteLine("Informations sur la moto : {}", Name);
            base.DisplayAll();
            Console.WriteLine("Cylindrée : {0}", Cylinder);
        }
    }
}
