using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionGarage.Core;

namespace EvalGestionGarage
{
    internal class Menu
    {
        private Garage garage;
        private List<Engine> engines;
        private List<Option> options;

        public Garage Garage { get { return garage; } }
        public List<Engine> Engines { get { return engines; } }
        public List <Option> Options { get { return options; } }

        public Menu()
        {

        }

        public Menu(Garage garage)
        {
            this.garage = garage;
        }

        public void Start()
        {
            bool usingApp = true;
            while (usingApp)
            {
                Console.Clear();

                Console.WriteLine("Bienvenue dans le menu de l'application console de garage.");
                Console.WriteLine("");
                Console.WriteLine("**********************************************************");
                Console.WriteLine("");
                Console.WriteLine("Veuillez choisir une action parmis celles ci dessous :");
                Console.WriteLine("1. Afficher les véhicules");
                Console.WriteLine("2. Ajouter un véhicule");
                Console.WriteLine("3. Supprimer un véhicule");
                Console.WriteLine("4. Sélectionner un véhicule");
                Console.WriteLine("5. Afficher les options d'un véhicule");
                Console.WriteLine("6. Ajouter des options à un véhicule");
                Console.WriteLine("6. Supprimer des options à un véhicule");
                Console.WriteLine("6. Afficher les options");
                Console.WriteLine("6. Afficher les marques");
                Console.WriteLine("6. Afficher les types de moteurs");
                Console.WriteLine("6. Charger le garage");
                Console.WriteLine("6. Sauvegarder le garage");
                Console.WriteLine("13. Quitter");
                Console.WriteLine("");

                try
                {
                    int userChoice = GetUserChoiceMenu(1, 13);
                    switch (userChoice)
                    {
                        case 1:
                            DisplayVehicle();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            usingApp = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        public int GetUserChoice()
        {
            int userChoice = 0;
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new FormatException("Le choix saisi n'est pas un nombre", e);
            }
            return userChoice;
        }

        public decimal GetUserDecimalChoice()
        {
            decimal userChoice = 0;
            try
            {
                userChoice = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException e)
            {
                throw new FormatException("Le choix saisi n'est pas un nombre", e);
            }
            return userChoice;
        }

        public int GetUserChoiceMenu(int min, int max)
        {
            int userChoice = GetUserChoice();
            if (userChoice <= max & userChoice >= min)
            {
                return userChoice;
            }
            throw new MenuException(min, max);
        }

        public void DisplayVehicle()
        {
            Console.Clear();
            garage.DisplayAllVehicles();
            Console.ReadKey();
        }
        
        public void AddVehicles()
        {
            Console.Clear();
            Console.WriteLine("Quelle type de véhicule souhaitez vous créer ?");
            Console.WriteLine("1. Voiture");
            Console.WriteLine("2. Camion");
            Console.WriteLine("3. Moto");
            int userVehicleTypeChoice = GetUserChoiceMenu(1, 3);
            Brands chosenBrand = (Brands)userVehicleTypeChoice;

            Console.Clear();
            Console.WriteLine("Entrez son nom : ");
            string vehicleName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Entrez son prix hors taxe : ");
            decimal vehicleDfPrice = GetUserDecimalChoice();

            Console.Clear();
            Console.WriteLine("Choisissez sa marque parmis celles ci dessous :");
            DisplayBrands();
            int userBrandChoiceNbr = GetUserChoiceMenu(1, 5);

            Console.Clear();
            Console.WriteLine("Choisissez un moteur parmis ceux disponibles ci dessous :");
            Engine vehicleEngine = null;
            if (DisplayEngines())
            {
                vehicleEngine = garage.AvalaibleEngines[GetUserChoiceMenu(1, garage.AvalaibleEngines.Count) - 1];
            }

            Console.Clear();
            bool choosingOption = true;
            List<Option> choosenOptions = null;
            while (choosingOption)
            {
                Console.WriteLine("Choisissez une options parmis celles disponibles ci dessous :");
                if (DisplayOptions())
                {
                    choosenOptions.Add(garage.AvalaibleOptions[GetUserChoiceMenu(1, garage.AvalaibleOptions.Count) - 1]);
                } else
                {
                    break;
                }
                Console.WriteLine("Voulez vous ajouter une autre option a votre véhicule ? :");
                Console.WriteLine("1. Oui");
                Console.WriteLine("2. Non");
                int userContinueChoice = GetUserChoiceMenu(1, 2);
                if (userContinueChoice == 2)
                {
                    choosingOption = false;
                }
            }

            if (userVehicleTypeChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("Entrez ses chevaux fiscaux : ");
                int carFiscalHp = GetUserChoice();

                Console.Clear();
                Console.WriteLine("Entrez son nombre de portes : ");
                int carDoorNbr = GetUserChoice();

                Console.Clear();
                Console.WriteLine("Entrez son nombre de sièges : ");
                int carSeatNbr = GetUserChoice();

                Console.Clear();
                Console.WriteLine("Entrez le volume de son coffre : ");
                int carBootVolume = GetUserChoice();

                Car newCar = new Car(vehicleName, vehicleDfPrice, chosenBrand, vehicleEngine, carFiscalHp, carDoorNbr, carSeatNbr, carBootVolume);
                foreach (Option option in choosenOptions)
                {
                    newCar.AddOption(option);
                }

                garage.AddVehicle(newCar);

                Console.WriteLine("La voiture a bien été ajoutée au garage, appuyer sur n'importe quelle touche pour continuer : ");
                Console.ReadKey();
            }
        }

        public void DisplayBrands()
        {
            int i = 1;
            foreach (string brand in Enum.GetNames(typeof(Brands)))
            {
                if (brand != null)
                {
                    Console.WriteLine("{0}. {1}", i, brand);
                    i++;
                }
            }
        }

        public bool DisplayEngines()
        {
            int i = 1;
            foreach (Engine engine in garage.AvalaibleEngines)
            {
                if (engine != null)
                {
                    Console.WriteLine("--{0}--", i);
                    engine.Display();
                    Console.WriteLine("");
                    i++;
                } else
                {
                    Console.WriteLine("Il n'y a pas de moteurs disponibles pour le moments.");
                    Console.WriteLine("Appuyer sur n'importe quelle touche pour continuer.");
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }

        public bool DisplayOptions()
        {
            int i = 1;
            foreach (Option option in garage.AvalaibleOptions)
            {
                if (option != null)
                {
                    Console.WriteLine("--{0}--", i);
                    option.Display();
                    Console.WriteLine("");
                    i++;
                } else
                {
                    Console.WriteLine("Il n'y a pas d'options disponibles pour le moments.");
                    Console.WriteLine("Appuyer sur n'importe quelle touche pour continuer.");
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }
    }
}
