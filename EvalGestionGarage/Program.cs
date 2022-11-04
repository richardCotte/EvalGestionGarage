using GestionGarage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalGestionGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            garage.AddEngine(new Engine("v12", EngineType.Essence, 400));
            garage.AddOption(new Option("Caffetière", 20000000));
            Menu menu = new Menu(garage);
            menu.Start();
        }
    }
}
