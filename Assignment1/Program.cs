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

    public class Player : IComparable
    {
        public static uint firstID = 10000;
        private readonly uint id;
        private readonly string name;
        private readonly Race race;
        private uint level;
        private uint exp;
        private uint guildID;
        private uint[] gear;
        private List<uint> inventory;
        private bool v1;
        private bool v2;
        public uint ID
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Race Race
        {
            get
            {
                return race;
            }
        }
        public uint Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        public uint Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
            }
        }
        public uint GuildID
        {
            get
            {
                return guildID;
            }
            set
            {
                guildID = value;
            }
        }
        public uint[] Gear
        {
            get
            {
                return gear;
            }
            set
            {
                gear = value;
            }
        }
        public List<uint> Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }
        public Player()
        {
            id = firstID++;
            name = Name;
            race = Race.Orc;
            level = 10;
            exp = 1;
            guildID = 475186;
            gear = new uint[] { 1, 2, 3, 4, 5, 6 };
            inventory = new List<uint> { };
            //v1 = false;
            //v2 = false;
        }
        public Player(uint id, string name, Race race, uint level, uint exp, uint guildId, uint[] gear, List<uint> inventory)
        {
            this.id = id;
            this.name = name;
            this.race = race;
            this.level = level;
            this.exp = exp;
            this.guildID = guildId;
            this.gear = gear;
            this.inventory = inventory;
            System.Console.WriteLine("I am making a new player. " + name);
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
        public override string ToString()
        {
            //string slacker = "slacker";
            //using (StreamWriter inFile = new StreamWriter("guilds.txt"))
            //{
            //    while (!inFile.EndOfStream)
            //    {
            //        //string reader = "";
            //        char ch = (char)inFile.Read();
            //    }
            //}

            string formattedString = String.Format("Name: {0, -20} Race: {1, -10} Level: {2, -10} Guild: {3, -10}", name, race.ToString(), level, guildID);
            return "Player is playing hard to get! " + formattedString;
        }
    }
    public class Item : IComparable
    {
        private readonly uint id;
        private string name;
        private ItemType type;
        private uint ilvl;
        private uint primary;
        private uint stamina;
        private uint requirement;
        private string flavor;
        public Item()
        {
            name = "Newbie's Helmettttt";
            ilvl = 0;
            //type = 1;
            primary = 10;
            stamina = 10;
            requirement = 1;
            flavor = "Every adventure has humble beginnings!";
        }
        public Item(uint i, string nm, uint il, uint pr, uint st, uint rq, string flv)
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
        public ItemType Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
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

        private static readonly string alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string digits = "1234567890";
        private static readonly string allPossibleChars = alphabetUpper + alphabetLower + digits;

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
            System.Console.WriteLine(welcome + "! \n");
            while (selectedOption != "10" || selectedOption != "q" || selectedOption != "Q" || selectedOption != "quit" || selectedOption != "Quit" || selectedOption != "exit" || selectedOption != "Exit")
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
            List<Player> player_roster = new List<Player>();
            using (StreamReader inFile = new StreamReader("players.txt"))
            {

                string idString = "";
                string nameString = "";
                string raceString = "";
                string levelString = "";
                string expString = "";
                string guildString = "";
                uint[] gear = new uint[GEAR_SLOTS];
                List<uint> inventory = new List<uint>();

                bool readingID = false;
                bool readingName = false;
                bool readingRace = false;
                bool readingLevel = false;
                bool readingExp = false;
                bool readingGuild = false;
                bool readingGear0 = false, readingGear1 = false, readingGear2 = false, readingGear3 = false, readingGear4 = false, readingGear5 = false;
                bool readingInventory0 = false, readingInventory1 = false, readingInventory2 = false, readingInventory3 = false, readingInventory4 = false;
                bool readingInventory5 = false, readingInventory6 = false, readingInventory7 = false;
                Race race;

                readingID = true;
                StringBuilder variableBuilder = new StringBuilder();
                while (!inFile.EndOfStream)
                {
                    //string reader = "";
                    char ch = (char)inFile.Read();


                    uint g_index = 0;



                    int index_of = Program.allPossibleChars.IndexOf(ch);
                    //System.Console.WriteLine("index_of = " + index_of + " at " + ch);
                    if (index_of == -1)
                    {
                        if (readingID)
                        {
                            idString = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            readingID = false;
                            readingName = true;
                        }
                        else if (readingName)
                        {
                            nameString = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            readingName = false;
                            readingRace = true;
                        }
                        else if (readingRace)
                        {
                            raceString = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            readingRace = false;
                            readingLevel = true;
                        }
                        else if (readingLevel)
                        {
                            levelString = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            readingLevel = false;
                            readingExp = true;
                        }
                        else if (readingExp)
                        {
                            expString = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            readingExp = false;
                            readingGuild = true;
                        }
                        else if (readingGuild)
                        {
                            guildString = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            readingGuild = false;
                            readingGear0 = true;
                        }
                        else if (readingGear0)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear0 = false;
                            readingGear1 = true;
                        }
                        else if (readingGear1)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear1 = false;
                            readingGear2 = true;
                        }
                        else if (readingGear2)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear2 = false;
                            readingGear3 = true;
                        }
                        else if (readingGear3)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear3 = false;
                            readingGear4 = true;
                        }
                        else if (readingGear4)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear4 = false;
                            readingGear5 = true;
                        }
                        else if (readingGear5)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear5 = false;
                            readingInventory0 = true;
                        }
                        else if (readingInventory0)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory0 = false;
                            readingInventory1 = true;
                        }
                        else if (readingInventory1)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory1 = false;
                            readingInventory2 = true;
                        }
                        else if (readingInventory2)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory2 = false;
                            readingInventory3 = true;
                        }
                        else if (readingInventory3)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory3 = false;
                            readingInventory4 = true;
                        }
                        else if (readingInventory4)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory4 = false;
                            readingInventory5 = true;
                        }
                        else if (readingInventory5)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory5 = false;
                            readingInventory6 = true;
                        }
                        else if (readingInventory6)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory6 = false;
                            readingInventory7 = true;
                        }
                        else if (readingInventory7)
                        {
                            inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                            variableBuilder = new StringBuilder();
                            readingInventory7 = false;
                            /*System.Console.WriteLine("I am done with the player.");
                            System.Console.WriteLine("idString = " + idString);
                            System.Console.WriteLine("nameString = " + nameString);*/
                            switch (raceString)
                            {
                                case "0":
                                    race = Race.Orc;
                                    break;
                                case "1":
                                    race = Race.Troll;
                                    break;
                                case "2":
                                    race = Race.Tauren;
                                    break;
                                default:
                                    race = Race.Forsaken;
                                    break;
                            }
                            //Player Pl = new Player(Convert.ToUInt32(idString), nameString, race, Convert.ToUInt32(levelString), Convert.ToUInt32(expString), Convert.ToUInt32(guildString), gear, inventory);
                            //System.Console.WriteLine("P string is " + Pl.ToString());
                            //player_roster.Add(new Player(Convert.ToUInt32(idString), nameString, race, Convert.ToUInt32(levelString), Convert.ToUInt32(expString), Convert.ToUInt32(guildString), gear, inventory));
                            //System.Console.WriteLine();
                            player_roster.Add(new Player(Convert.ToUInt32(idString), nameString, race, Convert.ToUInt32(levelString), Convert.ToUInt32(expString), Convert.ToUInt32(guildString), gear, inventory));
                            //System.Console.WriteLine("nameStrin    g: " + nameString);
                            /*foreach (Player P in player_roster)
                            {
                                System.Console.WriteLine("Player is within: " + P.ToString());
                            }*/
                            inFile.Read();
                            readingID = true;
                        }
                    }
                    else
                    {
                        variableBuilder.Append(ch);
                        //System.Console.WriteLine("variableBuilder " + variableBuilder.ToString() + " " + readingID);
                    }
                }
                inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                /*System.Console.WriteLine("I am done with the player.");
                System.Console.WriteLine("idString = " + idString);
                System.Console.WriteLine("nameString = " + nameString);*/
                switch (raceString)
                {
                    case "0":
                        race = Race.Orc;
                        break;
                    case "1":
                        race = Race.Troll;
                        break;
                    case "2":
                        race = Race.Tauren;
                        break;
                    default:
                        race = Race.Forsaken;
                        break;
                }
                player_roster.Add(new Player(Convert.ToUInt32(idString), nameString, race, Convert.ToUInt32(levelString), Convert.ToUInt32(expString), Convert.ToUInt32(guildString), gear, inventory));
            }

            foreach (Player Pla in player_roster)
            {
                System.Console.WriteLine(Pla.ToString());
            }

        }

        public static void PrintAllGuilds()
        {
            string reader = "";
            string[] guildWithoutWhiteSpace;

            using (StreamReader inFile = new StreamReader(@"guilds.txt"))
            {
                string guild = "";
                string guildWithoutSpaces = "";
                while (!inFile.EndOfStream)
                {
                    reader = inFile.ReadLine().ToString();
                    {
                        {
                            // Code from https://stackoverflow.com/questions/7411438/remove-characters-from-c-sharp-string 

                            guild = new string((from c in reader where char.IsWhiteSpace(c) || char.IsLetter(c) select c).ToArray());
                            char[] ch = guild.ToCharArray();
                            ch[0] = ' ';
                            guildWithoutSpaces = new string(ch);
                            //System.Console.WriteLine("{0: -10}", guild);
                            System.Console.WriteLine(guildWithoutSpaces);
                            System.Console.WriteLine();

                        }
                    }
                }
            }
        }
    }
}