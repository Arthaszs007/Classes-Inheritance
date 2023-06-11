using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance:\n");

            long foundAppliance = long.Parse(Console.ReadLine());
            foreach (var item in Appliances) {
                if (foundAppliance == item.ItemNumber)
                {
                    if (item.Quantity > 0)
                    {
                        Console.WriteLine(item);
                    }
                    else
                        Console.WriteLine("The appliance is not available to be checked out.\n");

                    return;
                }

            }

            Console.WriteLine("No appliances found with that item number.\n");

        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {


            Console.WriteLine("Enter brand to search for:");



            string brand = Console.ReadLine();



            List<Appliance> applist = new List<Appliance>();


            for (int i = 0; i < Appliances.Count; i++){
                if (Appliances[i].Brand == brand)
                {
                    applist.Add(Appliances[i]);
                }
            }



            DisplayAppliancesFromList(applist, applist.Count);


        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {

            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");

            short numDoor = short.Parse(Console.ReadLine());


            List<Appliance> appList = new List<Appliance>();

            

            foreach (var item in Appliances){
                if (item is Refrigerator) {
                    Refrigerator frige = item as Refrigerator;
                     if (frige.Doors == numDoor) {
                        appList.Add(frige);
                    }

                }
            }

            DisplayAppliancesFromList(appList,appList.Count);

        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {

            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)\n");
 
            short batteryValue = short.Parse( Console.ReadLine());

            List<Appliance> appList = new List<Appliance>(); 

            foreach (var item in Appliances){
                if (item is Vacuum) { 
                    Vacuum vacuum = item as Vacuum;
                    if(vacuum.BatteryVoltage == batteryValue) {
                        appList.Add(vacuum);                  
                    }
                }

            }

            DisplayAppliancesFromList(appList,appList.Count);

        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {


            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site)\n");

            string roomType = Console.ReadLine();

            List<Appliance> appList = new List<Appliance>();

            foreach (var item in Appliances)
            {
                if (item is Microwave)
                {
                    Microwave microwave = item as Microwave;
                    if (microwave.RoomType.ToString() == roomType)
                    {
                        appList.Add(microwave);
                    }
                }

            }

            DisplayAppliancesFromList(appList, appList.Count);

        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {



            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n");

            string soundRate = Console.ReadLine();

            List<Appliance> appList = new List<Appliance>();

            foreach (var item in Appliances)
            {
                if (item is Dishwasher)
                {
                    Dishwasher dishwasher = item as Dishwasher;
                    if (dishwasher.SoundRating == soundRate)
                    {
                        appList.Add(dishwasher);
                    }
                }

            }

            DisplayAppliancesFromList(appList, appList.Count);

        }
  
    

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {


            Console.WriteLine("Enter number of appliances:\n");
            string num = Console.ReadLine();
            List<Appliance> appList = new List<Appliance>();
            foreach (var item in Appliances)
            {
                appList.Add(item);
            }

            appList.Sort(new RandomComparer());

            DisplayAppliancesFromList(appList, int.Parse(num));
        }
    }
}
