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

        public Garage Garage { get { return garage; } }

        public Menu(Garage garage)
        {
            this.garage = garage;
        }

        public void Start()
        {
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
                Console.WriteLine("7. Supprimer des options à un véhicule");
                Console.WriteLine("8. Afficher les options");
                Console.WriteLine("9. Afficher les marques");
                Console.WriteLine("10. Afficher les types de moteurs");
                Console.WriteLine("11. Charger le garage");
                Console.WriteLine("12. Sauvegarder le garage");
                Console.WriteLine("13. Quitter");
                Console.WriteLine("");

                if (selectedVehicle != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Un véhicule est actuellement séléctioné : ");
                    Console.WriteLine("{0} {1}", selectedVehicle.Brand, selectedVehicle.Name);
                    Console.WriteLine("");
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
                            break;
                        case 4:
                            selectedVehicle = SelectVehicle();
                            break;
                        case 5:
                            if (selectedVehicle != null)
                            {
                                DisplaySelectedVehicleOptions(selectedVehicle);
                            } else
                            {
                                NoSelectedVehicleError();
                            }
                            break;
                        case 6:
                            if (selectedVehicle != null)
                            {
                                AddOptionToSelectedVehicle(selectedVehicle);
                            }
                            else
                            {
                                NoSelectedVehicleError();
                            }
                            break;
                        case 7:
                            if (selectedVehicle != null)
                            {
                                DeleteOptionFromSelectedVehicle(selectedVehicle);
                            }
                            else
                            {
                                NoSelectedVehicleError();
                            }
                            break;
                        case 8:
                            DisplayOptionsMenu();
                            break;
                        case 9:
                            DisplayBrandsMenu();
                            break;
                        case 10:
                            DisplayEnginesType();
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
            if (userChoice <= max & userChoice >= min || min == max & max == userChoice)
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
            int userBrandChoiceNbr = GetUserChoiceMenu(0, 4);
            Brands chosenBrand = (Brands)userBrandChoiceNbr;

            Console.Clear();
            Console.WriteLine("Choisissez un moteur parmis ceux disponibles ci dessous :");
            Engine vehicleEngine = null;
            if (DisplayEngines())
            {
                vehicleEngine = garage.AvalaibleEngines[GetUserChoiceMenu(0, garage.AvalaibleEngines.Count - 1)];
            }

            Console.Clear();
            bool choosingOption = true;
            List<Option> choosenOptions = new List<Option>();
            while (choosingOption)
            {
                Console.WriteLine("Choisissez une options parmis celles disponibles ci dessous :");
                if (DisplayOptions())
                {
                    choosenOptions.Add(garage.AvalaibleOptions[GetUserChoiceMenu(0, garage.AvalaibleOptions.Count - 1)]);
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
                    if (choosenOptions.Count != 0)
                    {
                        foreach (Option option in choosenOptions)
                        {
                            newCar.AddOption(option);
                        }
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
                    if (choosenOptions.Count != 0)
                    {
                        foreach (Option option in choosenOptions)
                        {
                            newTruck.AddOption(option);
                        }
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
                    if (choosenOptions.Count != 0)
                    {
                        foreach (Option option in choosenOptions)
                        {
                            newMotorcycle.AddOption(option);
                        }
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

        public void AddOptionToSelectedVehicle(Vehicle selectedVehicle)
        {
            Console.Clear();
            int choosenOption;
            if (DisplayOptions())
            {
                Console.WriteLine("Choisissez une option à ajouter au véhicule séléctionné parmis la liste ci dessus : ");
                choosenOption = GetUserChoiceMenu(0, garage.AvalaibleOptions.Count);
                selectedVehicle.AddOption(garage.AvalaibleOptions[choosenOption]);
                Console.WriteLine("L'option choisie à correctement été ajoutée au véhicule séléctionné");
                Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
                Console.ReadKey();
            }
        }

        public void DeleteOptionFromSelectedVehicle(Vehicle selectedVehicle)
        {
            Console.Clear();
            int choosenOption;
            if (selectedVehicle.DisplayOptions())
            {
                Console.WriteLine("Choisissez une option à supprimer du véhicule séléctionner parmis la liste ci dessous : ");
                choosenOption = GetUserChoiceMenu(0, selectedVehicle.Options.Count);
                selectedVehicle.DeleteOption(selectedVehicle.Options[choosenOption]);
                Console.WriteLine("L'option choisie à correctement été supprimée du véhicule séléctionné");
                Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
                Console.ReadKey();
            }
        }

        public void DisplaySelectedVehicleOptions(Vehicle selectedVehicle)
        {
            Console.Clear();
            Console.WriteLine("Voici toutes les options du véhicule {0} {1} : ", selectedVehicle.Brand, selectedVehicle.Name);
            selectedVehicle.DisplayOptions();
            Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
            Console.ReadKey();
        }

        public void NoSelectedVehicleError()
        {
            Console.Clear();
            Console.WriteLine("Veuillez d'abord séléctionner un véhicule (fonction 4 du menu)");
            Console.ReadKey();
        }

        public void DisplayBrands()
        {
            int i = 0;
            foreach (string brand in Enum.GetNames(typeof(Brands)))
            {
                if (brand != null)
                {
                    Console.WriteLine("{0}. {1}", i++, brand);
                }
            }
        }

        public void DisplayBrandsMenu()
        {
            Console.Clear();
            Console.WriteLine("Voici la liste des marques disponibles : ");
            DisplayBrands();
            Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
            Console.ReadKey();
        }

        public void DisplayEnginesType()
        {
            Console.Clear();
            Console.WriteLine("Voici la liste des type de moteurs disponibles : ");
            int i = 0;
            foreach (string engineType in Enum.GetNames(typeof(EngineType)))
            {
                if (engineType != null)
                {
                    Console.WriteLine("{0}. {1}", i++, engineType);
                }
            }
            Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
            Console.ReadKey();
        }

        public bool DisplayEngines()
        {
            int i = 0;
            if (garage.AvalaibleEngines.Count != 0)
            {
                foreach (Engine engine in garage.AvalaibleEngines)
                {
                    Console.WriteLine("------- {0} -------", i++);
                    engine.Display();
                    Console.WriteLine("");
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de moteurs disponibles pour le moments.");
                Console.WriteLine("Appuyer sur n'importe quelle touche pour continuer.");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool DisplayOptions()
        {
            int i = 0;
            if (garage.AvalaibleOptions.Count != 0)
            {
                foreach (Option option in garage.AvalaibleOptions)
                {
                    Console.WriteLine("------- {0} -------", i++);
                    option.Display();
                    Console.WriteLine("");
                }
            } else
            {
                Console.WriteLine("Il n'y a pas d'options disponibles pour le moments.");
                Console.WriteLine("Appuyer sur n'importe quelle touche pour continuer.");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public void DisplayOptionsMenu()
        {
            Console.Clear();
            Console.WriteLine("Voici la liste des options disponibles :");
            if (DisplayOptions())
            {
                Console.WriteLine("Appuyez sur n'importe quelle touche pour revenir au menu");
                Console.ReadKey();
            }
        }
    }
}
