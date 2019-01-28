using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public enum ItemType
    {
        Helmet, Neck, Shoulders, Back, Chest,
        Wrist, Gloves, Belt, Pants, Boots,
        Ring, Trinket
    };

    public enum Race { Orc = 0, Troll = 1, Tauren = 2, Forsaken = 3 };

    public class Player
    {
        readonly uint id;
        readonly string name;
        //readonly Racial race;
        uint level;
        uint guildID;
        uint[] gear;
        List<uint> inventory;
        bool v1;
        bool v2;
    }

    public class Item : IComparable
    {
        private readonly uint id;
        private string name;
        //private ItemType type;
        private uint ilvl;
        private uint primary;
        private uint stamina;
        private uint requirement;
        private string flavor;

        public Item ()
        {

            //string reader = "";
            //using (StreamReader inFile = new StreamReader("players.txt"))
            //{
            //    while (!inFile.EndOfStream)
            //    {
            //        string playerName = "";
            //        reader = inFile.ReadLine().ToString();
            //        {
            //            playerName = new string((from c in reader where char.IsLetter(c) select c).ToArray());
            //        }
            //    }
            //}

            name = "Newbie's Helmettttt";
            ilvl = 0;
            //type = 1;
            primary = 10;
            stamina = 10;
            requirement = 1;
            flavor = "Every adventure has humble beginnings!";
        }

        public Item( uint i, string nm, uint il, uint pr, uint st, uint rq, string flv )
        {
            id = i;
            name = nm;
            ilvl = il;
            primary = pr;
            stamina = st;
            requirement = rq;
            flavor = flv;
        }

        public uint ID
        {
            get { return id; }
        }

        //public ItemType Type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}

        public string Name // This is my public property
        {
            get { return name; } // The attribute
            set { name = value; } // "value" is the default name to the assignment operand 
        }

        public uint ILVL
        {
            get { return ilvl; }
            set { ilvl = value; }
        }

        public uint Primary
        {
            get { return primary; }
            set { primary = value; }
        }

        public uint Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }

        public uint Requirement
        {
            get { return requirement; }
            set { requirement = value; }
        }

        public string Flavor
        {
            get { return flavor; }
            set { flavor = value; }
        }

        public int CompareTo(object alpha)
        {
            Item itemObject = (Item)alpha;

            int value = itemObject.Name.CompareTo(this.Name);

            if (value == 1)
                return 1;
            else if (value == -1)
                return -1;
            else
                return 0;
        }
    }

    public class Program
    {
        private static uint MAX_ILLVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;

        public static void Main(string[] args)
        {
            string welcome = "Welcome to the World of ConflictCraft: Testing Environment";
            string selectedOption = "";

            System.Console.WriteLine();
            System.Console.WriteLine(welcome +  "! \n");
             
            while ( selectedOption != "10" || selectedOption != "q" || selectedOption != "Q" || selectedOption != "quit" || selectedOption != "Quit" || selectedOption != "exit" || selectedOption != "Exit" )
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
                        Console.ReadKey();
                    }
                    else if (slacker.CompareTo("2") == 0)
                    {
                        outFile.WriteLine(slacker);
                        Console.Clear();
                        PrintAllGuilds();
                        PrintMainMenu();
                        Console.ReadKey();
                    }
                    else
                    {
                        outFile.WriteLine(slacker);
                        Console.ReadKey();
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
            //string [] race = { "Forsaken", "Tauren", "Orc" };
            //int [] level = { 60, 60, 10 };
            //string[] guild = { "Big Dumb Guild", "Death and Taxes", "Death and Taxes" };
            //for ( int i = 0; i < nameArray.Length; )
            //{
            //    System.Console.WriteLine(String.Format(" Name: {0, -20} Race: {1, -10} Level: {2, -10} Guild: {3, -10} ", nameArray[i], race[i], level[i], guild[i]));
            //    i++;
            //}

            string reader = "";
            using (StreamReader inFile = new StreamReader("players.txt"))
            {
                string playerName = "";
                string raceType = "";
                while (!inFile.EndOfStream)
                {
                    reader = inFile.ReadLine().ToString();
                    {
                        playerName = new string((from c in reader where char.IsLetter(c) select c).ToArray());
    
                        //string raceType = new string (reader.ToCharArray().Where(char.IsDigit));
                        //raceType = new string(reader.ToCharArray().Where(char.IsDigit).ToArray());
                        //int[] raceNumberCategory = Convert.ToInt32(raceType);
                        //race = new Race((from c in reader where char.IsDigit(c) select c).ToArray()).ToString();

                        System.Console.WriteLine(" Name: {0, -20} Race: {1, -10} Level: {2, -10} Guild: {3, -10}", playerName, /*((Race)raceNumberCategory).ToString()*/7, 3, 4);
                    }
                }
            }
            System.Console.WriteLine();
        }
        
        public static void PrintAllGuilds()
        {
            string reader = "";
            using (StreamReader inFile = new StreamReader(@"guilds.txt"))
            {
                string guild = "";
                string guildWithoutSpaces = "";
                while (!inFile.EndOfStream)
                {
                    reader = inFile.ReadLine().ToString();
                    {
                        // Code reference: https://stackoverflow.com/questions/7411438/remove-characters-from-c-sharp-string

                        guild = new string((from c in reader where char.IsWhiteSpace(c) || char.IsLetter(c) select c ).ToArray());

                        // Code reference: https://www.arclab.com/en/kb/csharp/replace-or-remove-char-in-string-by-index.html
                        char[] ch = guild.ToCharArray();
                        ch[0] = ' ';
                        guildWithoutSpaces = new string(ch);

                        System.Console.WriteLine(guildWithoutSpaces);
                    }
                }
            }
            System.Console.WriteLine();
        }
    }
}
