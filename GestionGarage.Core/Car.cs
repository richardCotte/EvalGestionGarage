using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGarage.Core
{
    public class Car : Vehicle
    {
        private int fiscalHp;
        private int doorNbr;
        private int seatNbr;
        private int carBootVolume;

        public int FiscalHp { get => fiscalHp; set => fiscalHp = value; }
        public int DoorNbr { get => doorNbr; set => doorNbr = value; }
        public int SeatNbr { get => seatNbr; set => seatNbr = value; }
        public int CarBootVolume { get => carBootVolume; set => carBootVolume = value; }

        public Car(string name, decimal dfPrice, Brands brand, Engine engine, int fiscalHp, int doorNbr, int seatNbr, int carBootVolume)
            : base(name, dfPrice, brand, engine)
        {
            this.fiscalHp = fiscalHp;
            this.doorNbr = doorNbr;
            this.seatNbr = seatNbr;
            this.carBootVolume = carBootVolume;
        }

        public override decimal CalculateTaxes()
        {
            return fiscalHp * 10;
        }

        public override void DisplayAll()
        {
            Console.WriteLine("Informations sur la voiture : {}", Name);
            base.DisplayAll();
            Console.WriteLine("Nombre de chevaux fiscaux : {0}", FiscalHp);
            Console.WriteLine("Nombre de portes : {0}", DoorNbr);
            Console.WriteLine("Nombre de sièges : {0}", SeatNbr);
            Console.WriteLine("Volume du coffre : {0}m³", CarBootVolume);
        }
    }
}
