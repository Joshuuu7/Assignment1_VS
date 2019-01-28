using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment1
{
    public class Program
    {
        public enum Race { Orc, Troll, Tauren, Forsaken };

        public enum ItemType
        {
            Helmet, Neck, Shoulders, Back, Chest,
            Wrist, Gloves, Belt, Pants, Boots,
            Ring, Trinket
        };

        private static uint MAX_ILLVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;
        private static string [] GUILDS = { "Knights of Cydonia", "Death and Taxes", "I Just Crit My Pants", "What Have We Here", "Big Dumb Guild", "Honestly", "Sacred Heart" };

        public static void Main(string[] args)
        {
            string welcome = "Welcome to the World of ConflictCraft: Testing Environment";
            string selectedOption = "";
            System.Console.WriteLine();
            System.Console.WriteLine(welcome +  "! \n");
             
            while (selectedOption != "10")
            {
                PrintMainMenu();

                string slacker = "slacker";
                using (StreamWriter outFile = new StreamWriter("output.txt"))
                {
                    slacker = System.Console.ReadLine();
                    if (slacker.CompareTo("1") == 0) 
                    {
                        outFile.WriteLine(slacker);
                        Console.Clear();
                        PrintAllPlayers();
                        PrintMainMenu();
                    }
                    else if (slacker.CompareTo("2") == 0)
                    {
                        outFile.WriteLine(slacker);
                        Console.Clear();
                        PrintAllGuilds();
                        PrintMainMenu();
                    }
                    else
                    {
                        outFile.WriteLine(slacker);
                    }
                    Console.ReadKey();
                }
                Console.Clear();

            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static void PrintMainMenu()
        {
            string welcome = "Welcome to the World of ConflictCraft: Testing Environment";

            System.Console.WriteLine(welcome + ". Please select an option from the list below: \n ");
            System.Console.WriteLine("\t 1.) Print All Players");
            System.Console.WriteLine("\t 2.) Print All Guilds");
            System.Console.WriteLine("\t 3.) List All Gear");
            System.Console.WriteLine("\t 4.) Print Gear List for Player");
            System.Console.WriteLine("\t 5.) Leave Guild");
            System.Console.WriteLine("\t 6.) Join Guild");
            System.Console.WriteLine("\t 7.) Equip Gear");
            System.Console.WriteLine("\t 8.) Unequip Gear");
            System.Console.WriteLine("\t 9.) Award Experience");
            System.Console.WriteLine("\t 10.) Quit");
            System.Console.WriteLine();
        }

        public static void PrintAllPlayers()
        {
            string [] nameArray = { "Dark Master", "Scobomb", "xXSephirothXx" };
            string [] race = { "Forsaken", "Tauren", "Orc" };
            int [] level = { 60, 60, 10 };
            string[] guild = { "Big Dumb Guild", "Death and Taxes", "Death and Taxes" };
            for ( int i = 0; i < nameArray.Length; )
            {
                System.Console.WriteLine(String.Format(" Name: {0, -20} Race: {1, -10} Level: {2, -10} Guild: {3, -10} ", nameArray[i], race[i], level[i], guild[i]));
                i++;
            }
            System.Console.WriteLine();
        }
        
        public static void PrintAllGuilds()
        {
            string reader = "";
            string [] guildWithoutWhiteSpace;
            using (StreamReader inFile = new StreamReader(@"guilds.txt"))
            {
                string guild = "";
                while (!inFile.EndOfStream)
                {
                    reader = inFile.ReadLine().ToString();
                    {
                        // Code from https://stackoverflow.com/questions/7411438/remove-characters-from-c-sharp-string

                        guild = new string((from c in reader where char.IsWhiteSpace(c) || char.IsLetter(c) select c ).ToArray());

                        System.Console.WriteLine("{0: -10}", guild);
                    }
                }
            }
            System.Console.WriteLine();
        }
    }
}
