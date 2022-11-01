using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public class Truck : Vehicle
    {
        private int axleNbr;
        private int weight;
        private int volume;

        public int AxleNbr { get => axleNbr; set => axleNbr = value; }
        public int Weight { get => weight; set => weight = value; }
        public int Volume { get => volume; set => volume = value; }

        public Truck(string name, decimal dfPrice, Brands brand, Engine engine, int axleNbr, int weight, int volume)
            : base(name, dfPrice, brand, engine)
        {
            this.axleNbr = axleNbr;
            this.weight = weight;
            this.volume = volume;
        }

        public override decimal CalculateTaxes()
        {
            return AxleNbr * 50;
        }

        public override void DisplayAll()
        {
            Console.WriteLine("Informations sur le camion : {}", Name);
            base.DisplayAll();
            Console.WriteLine("Nombre d'essieu : {0}", AxleNbr);
            Console.WriteLine("Poids : {0}", Weight);
            Console.WriteLine("Volume : {0}", Volume);
        }
    }
}
