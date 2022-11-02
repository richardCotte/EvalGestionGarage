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
            bool isVehicleSelected = false;
            Vehicle selectedVehicle = null;
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

                if (selectedVehicle != null)
                {
                    isVehicleSelected = true;
                }

                try
                {
                    int userChoice = GetUserChoiceMenu(1, 13);
                    switch (userChoice)
                    {
                        case 1:
                            DisplayVehicle();
                            break;
                        case 2:
                            AddVehicles();
                            break;
                        case 3:
                            DeleteVehicle();
                            selectedVehicle = null;
                            isVehicleSelected = false;
                            break;
                        case 4:
                            selectedVehicle = SelectVehicle();
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
            int userChoice;
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
            decimal userChoice;
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
            Brands chosenBrand = (Brands)userBrandChoiceNbr;

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

            switch (userVehicleTypeChoice)
            {
                case 1:
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
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Entrez son nombre d'essieu : ");
                    int truckAxleNumbre = GetUserChoice();

                    Console.Clear();
                    Console.WriteLine("Entrez son poids : ");
                    int truckWeight = GetUserChoice();

                    Console.Clear();
                    Console.WriteLine("Entrez son volume : ");
                    int truckVolume = GetUserChoice();

                    Truck newTruck = new Truck(vehicleName, vehicleDfPrice, chosenBrand, vehicleEngine, truckAxleNumbre, truckWeight, truckVolume);
                    foreach (Option option in choosenOptions)
                    {
                        newTruck.AddOption(option);
                    }

                    garage.AddVehicle(newTruck);

                    Console.WriteLine("Le camion a bien été ajouté au garage, appuyer sur n'importe quelle touche pour continuer : ");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Entrez son cylindré : ");
                    int motorcycleCylinder = GetUserChoice();

                    Motorcycle newMotorcycle = new Motorcycle(vehicleName, vehicleDfPrice, chosenBrand, vehicleEngine, motorcycleCylinder);
                    foreach (Option option in choosenOptions)
                    {
                        newMotorcycle.AddOption(option);
                    }

                    garage.AddVehicle(newMotorcycle);

                    Console.WriteLine("La moto a bien été ajoutée au garage, appuyer sur n'importe quelle touche pour continuer : ");
                    Console.ReadKey();
                    break;
            }
        }

        public void DeleteVehicle()
        {
            Console.Clear();
            Console.WriteLine("Choisissez un véhicule à supprimer parmis la liste de véhicules ci-dessous en tapant le chiffre correspondant (celui entre les tirets) : ");
            garage.DisplayAllVehicles();
            int deletedVehicleChoice = GetUserChoiceMenu(0, garage.Vehicles.Count);
            garage.DeleteVehicleFromList(deletedVehicleChoice);
            Console.WriteLine("Le véhicule a bien été supprimé du garage, appuyer sur n'importe quelle touche pour continuer : ");
            Console.WriteLine("(Pensez également à reséléctionner un véhicule si besoin)");
            Console.ReadKey();
        }

        public Vehicle SelectVehicle()
        {
            Console.Clear();
            Console.WriteLine("Choisissez un véhicule sur lequel vous souhaitez réalisé des opérations parmis la liste de véhicules ci-dessous en tapant le chiffre correspondant (celui entre les tirets) : ");
            garage.DisplayAllVehicles();
            int selectedVehicleChoice = GetUserChoiceMenu(0, garage.Vehicles.Count);
            return garage.Vehicles[selectedVehicleChoice];
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
