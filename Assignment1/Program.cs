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
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;
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
            gear = new uint[GEAR_SLOTS];
            inventory = new List<uint> ();
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
        }
        public int CompareTo(object alpha)
        {
            Player itemObject = (Player)alpha;
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
            string guild_string = "";
            switch (guildID)
            {
                case 475186:
                    guild_string = "Knights of Cydonia";
                    break;
                case 748513:
                    guild_string = "Death and Taxes";
                    break;
                case 154794:
                    guild_string = "I just crit my pants";
                    break;
                case 928126:
                    guild_string = "What have we here";
                    break;
                case 513487:
                    guild_string = "Big dumb guild";
                    break;
                case 864722:
                    guild_string = "Honestly";
                    break;
                case 185470:
                    guild_string = "Sacred Heart";
                    break;
            }
            return string.Format( "Name: {0, -20} Race: {1, -10} Level: {2, -10} Guild:  {3, -10}", name, race, level, guild_string);
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
        public Item(uint i, string nm, ItemType gear_type, uint il, uint pr, uint st, uint rq, string flv)
        {
            this.id = i;
            this.name = nm;
            this.type = gear_type;
            this.ilvl = il;
            this.primary = pr;
            this.stamina = st;
            this.requirement = rq;
            this.flavor = flv;
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
        public override string ToString()
        {

            const string quote = "\"";
            //string description = quote + flavor + quote;
            return string.Format("({0}) {1} |{2}|  --{3}--\n\t'{4}'", type, name, ILVL, stamina, flavor);
        }
        // Class order for Item : uint i, string nm, ItemType gear_type, uint il, uint pr, uint st, uint rq, string flv
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
            List<Player> player_roster = getAllPlayers();
            List<Item> gears = getAllGear();

            while (selectedOption != "10" || selectedOption != "q" || selectedOption != "Q" || selectedOption != "quit" || selectedOption != "Quit" || selectedOption != "exit" || selectedOption != "Exit")
            {
                PrintMainMenu();
                string slacker = "slacker";
                using (StreamWriter outFile = new StreamWriter("output.txt"))
                {
                    slacker = System.Console.ReadLine();
                    try
                    {
                        if (Convert.ToUInt32(slacker) == 1)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            PrintAllPlayers(player_roster);
                            PrintMainMenu();
                        }
                        else if (Convert.ToUInt32(slacker) == 2)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            PrintAllGuilds();
                            PrintMainMenu();
                        }
                        else if (Convert.ToUInt32(slacker) == 3)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            ListAllGear(gears);
                            PrintMainMenu();
                        }
                        else if (Convert.ToUInt32(slacker) == 4)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            System.Console.WriteLine("Please enter a player name:");
                            string playerName = System.Console.ReadLine().Trim();
                            System.Console.WriteLine("You entered: " + playerName);
                            foreach (Player P in player_roster)
                            {
                                if (P.Name == playerName)
                                {
                                    PrintGearListForPlayer(P, gears);
                                }
                            }
                        }
                        else if (Convert.ToUInt32(slacker) == 5)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            Console.WriteLine("Please enter a player name: ");
                            string player_name = Console.ReadLine().Trim();
                            Console.WriteLine("You entered " + player_name);
                            foreach (Player P in player_roster)
                            {
                                if (P.Name == player_name)
                                {
                                    LeaveGuild(P);
                                }
                            }
                            PrintMainMenu();
                        }
                        else if (Convert.ToUInt32(slacker) == 6)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            string player_name = "name";
                            string guild_to_join = "guild";

                            System.Console.Write("Enter the player name: ");
                            player_name = System.Console.ReadLine();

                            System.Console.Write("Enter the Guild they will join: ");
                            guild_to_join = System.Console.ReadLine();

                            foreach (Player P in player_roster)
                            {
                                if (P.Name == player_name)
                                {
                                    JoinGuild(P, guild_to_join);
                                }
                            }
                            PrintMainMenu();
                        }
                        else if (Convert.ToUInt32(slacker) == 7)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            string player_name = "name";
                            string gear_to_equip = "gear";

                            System.Console.Write("Enter the player name: ");
                            player_name = System.Console.ReadLine();
                            foreach (Player P in player_roster)
                            {
                                if (P.Name == player_name)
                                {
                                    System.Console.WriteLine("Enter the item name: ");
                                    gear_to_equip = System.Console.ReadLine();
                                    EquipGear(P, gear_to_equip);
                                }
                            }

                            PrintMainMenu();
                        }
                        else if (Convert.ToUInt32(slacker) == 7)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            string player_name = "name";
                            string gear_to_equip = "gear";

                            System.Console.Write("Enter the player name: ");
                            player_name = System.Console.ReadLine();
                            foreach (Player P in player_roster)
                            {
                                if (P.Name == player_name)
                                {
                                    System.Console.WriteLine("Enter the item name: ");
                                    gear_to_equip = System.Console.ReadLine();
                                    equipGear(P, gear_to_equip);
                                }
                            }

                            PrintMainMenu();
                        }
                        else if (slacker.CompareTo("8") == 0)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            string player_name = "name";
                            string gear_to_equip = "gear";

                            System.Console.Write("Enter the player name: ");
                            player_name = System.Console.ReadLine();
                            foreach (Player P in player_roster)
                            {
                                if (P.Name == player_name)
                                {
                                    System.Console.WriteLine("Enter the item name: ");
                                    gear_to_equip = System.Console.ReadLine();
                                    UnequipGear(P, gear_to_equip);
                                }
                            }

                            PrintMainMenu();
                        }
                        else if (slacker.CompareTo("9") == 0)
                        {
                            outFile.WriteLine(slacker);
                            Console.Clear();
                            // Enter Player Name
                            System.Console.WriteLine("Please enter a player name:");
                            string playerName = System.Console.ReadLine().Trim();
                            foreach (Player P in player_roster)
                            {
                                if (P.Name == playerName)
                                {
                                    AwardExp(P);
                                }
                            }
                            PrintMainMenu();
                        }
                        else
                        {
                            return;
                        }
                        Console.ReadKey();
                    }
                    catch (System.FormatException fe)
                    {
                        return;
                    }
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

        // Option 4
        public static void PrintGearListForPlayer(Player P, List<Item> gears)
        {
            uint[] gears_array = P.Gear;
            foreach (int g in gears_array)
            {
                foreach (Item i in gears)
                {
                    if (i.ID == g)
                    {
                        Console.WriteLine(i.ToString());
                    }
                }
            }
        }



        // Option 3
        public static void ListAllGear(List<Item> gears)
        {
            foreach (Item g in gears)
            {
                Console.WriteLine(g.ToString());
            }
        }

        public static List<Item> getAllGear()
        {
            List<Item> allGear = new List<Item>();
            using (StreamReader inFile = new StreamReader("equipment.txt"))
            {
                string gearID = "";
                string gearName = "";
                string gearNo1 = "";
                string gearNo2 = "";
                string gearNo3 = "";
                string gearNo4 = "";
                string gearNo5 = "";
                string gearSlogan = "";

                bool readingGearID = true;
                bool readingGearNo1 = false;
                bool readingGearNo2 = false;
                bool readingGearNo3 = false;
                bool readingGearNo4 = false;
                bool readingGearNo5 = false;

                StringBuilder variableBuilder = new StringBuilder();
                ItemType gear_type;
                while (!inFile.EndOfStream)
                {
                    char ch = (char)inFile.Read();
                    int index_of = Program.allPossibleChars.IndexOf(ch);
                    if (index_of == -1)
                    {
                        if (readingGearID)
                        {
                            readingGearID = false;
                            gearID = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            do
                            {
                                ch = (char)inFile.Read();
                                index_of = Program.allPossibleChars.IndexOf(ch);
                            }
                            while (index_of == -1);
                            index_of = -1;
                            while (index_of == -1)
                            {
                                variableBuilder.Append(ch);
                                ch = (char)inFile.Read();
                                index_of = Program.digits.IndexOf(ch);
                            }
                            gearName = variableBuilder.ToString();
                            variableBuilder = new StringBuilder();
                            variableBuilder.Append(ch);
                            readingGearNo1 = true;
                        }
                        else if (readingGearNo1)
                        {
                            gearNo1 = variableBuilder.ToString();
                            readingGearNo1 = false;
                            readingGearNo2 = true;
                            variableBuilder = new StringBuilder();
                        }
                        else if (readingGearNo2)
                        {
                            gearNo2 = variableBuilder.ToString();
                            readingGearNo2 = false;
                            readingGearNo3 = true;
                            variableBuilder = new StringBuilder();
                        }
                        else if (readingGearNo3)
                        {
                            gearNo3 = variableBuilder.ToString();
                            readingGearNo3 = false;
                            readingGearNo4 = true;
                            variableBuilder = new StringBuilder();
                        }
                        else if (readingGearNo4)
                        {
                            gearNo4 = variableBuilder.ToString();
                            readingGearNo4 = false;
                            readingGearNo5 = true;
                            variableBuilder = new StringBuilder();
                        }
                        else if (readingGearNo5)
                        {
                            gearNo5 = variableBuilder.ToString();
                            readingGearNo5 = false;
                            variableBuilder = new StringBuilder();
                            do
                            {
                                ch = (char)inFile.Read();
                                index_of = Program.allPossibleChars.IndexOf(ch);
                            }
                            while (index_of == -1);
                            index_of = -1;
                            while (index_of == -1)
                            {
                                while (index_of == -1)
                                {
                                    variableBuilder.Append(ch);
                                    ch = (char)inFile.Read();
                                    index_of = Program.digits.IndexOf(ch);
                                    if (inFile.EndOfStream)
                                    {
                                        variableBuilder.Append(ch);
                                        gearSlogan = variableBuilder.ToString();
                                        switch (Convert.ToUInt32(gearNo1))
                                        {
                                            case 0:
                                                gear_type = ItemType.Helmet;
                                                break;
                                            case 1:
                                                gear_type = ItemType.Neck;
                                                break;
                                            case 2:
                                                gear_type = ItemType.Shoulders;
                                                break;
                                            case 3:
                                                gear_type = ItemType.Back;
                                                break;
                                            case 4:
                                                gear_type = ItemType.Chest;
                                                break;
                                            case 5:
                                                gear_type = ItemType.Wrist;
                                                break;
                                            case 6:
                                                gear_type = ItemType.Gloves;
                                                break;
                                            case 7:
                                                gear_type = ItemType.Belt;
                                                break;
                                            case 8:
                                                gear_type = ItemType.Pants;
                                                break;
                                            case 9:
                                                gear_type = ItemType.Boots;
                                                break;
                                            case 10:
                                                gear_type = ItemType.Ring;
                                                break;
                                            default:
                                                gear_type = ItemType.Trinket;
                                                break;
                                        }
                                        allGear.Add(new Item(Convert.ToUInt32(gearID), gearName, gear_type, Convert.ToUInt32(gearNo2), Convert.ToUInt32(gearNo3), Convert.ToUInt32(gearNo4), Convert.ToUInt32(gearNo5), gearSlogan));
                                        //System.Console.WriteLine("id: " + gearID + " name: " + gearName + " " + gearNo1 + " " + gearNo2 + " " + gearNo3 + " " + gearNo4 + " " + gearNo5 + " slogan: " + gearSlogan);
                                        return allGear;
                                    }
                                }
                                gearSlogan = variableBuilder.ToString();
                                switch (Convert.ToUInt32(gearNo1))
                                {
                                    case 0:
                                        gear_type = ItemType.Helmet;
                                        break;
                                    case 1:
                                        gear_type = ItemType.Neck;
                                        break;
                                    case 2:
                                        gear_type = ItemType.Shoulders;
                                        break;
                                    case 3:
                                        gear_type = ItemType.Back;
                                        break;
                                    case 4:
                                        gear_type = ItemType.Chest;
                                        break;
                                    case 5:
                                        gear_type = ItemType.Wrist;
                                        break;
                                    case 6:
                                        gear_type = ItemType.Gloves;
                                        break;
                                    case 7:
                                        gear_type = ItemType.Belt;
                                        break;
                                    case 8:
                                        gear_type = ItemType.Pants;
                                        break;
                                    case 9:
                                        gear_type = ItemType.Boots;
                                        break;
                                    case 10:
                                        gear_type = ItemType.Ring;
                                        break;
                                    default:
                                        gear_type = ItemType.Trinket;
                                        break;
                                }
                                allGear.Add(new Item(Convert.ToUInt32(gearID), gearName, gear_type, Convert.ToUInt32(gearNo2), Convert.ToUInt32(gearNo3), Convert.ToUInt32(gearNo4), Convert.ToUInt32(gearNo5), gearSlogan));
                                //System.Console.WriteLine("id: " + gearID + " name: " + gearName + " " + gearNo1 + " " + gearNo2 + " " + gearNo3 + " " + gearNo4 + " " + gearNo5 + " slogan: " + gearSlogan);
                                variableBuilder = new StringBuilder();
                                variableBuilder.Append(ch);
                                readingGearID = true;
                            }
                        }
                    }
                    else
                    {
                        variableBuilder.Append(ch);
                    }
                }
            }
            return allGear;
        }

        // Option 1
        public static void PrintAllPlayers(List<Player> players)
        {
            List<Player> sorted_players = players.OrderBy(o => o.Name).ToList();
            
            foreach (Player Pla in sorted_players)
            {
                Console.WriteLine(Pla.ToString());
            }
        }

        // Option 2
        public static void PrintAllGuilds()
        {
            string reader = "";
            string guildWithoutSpaces = "";
            string[] guilds = { };
            using (StreamReader inFile = new StreamReader(@"guilds.txt"))
            {
                string guild = "";
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
                            System.Console.WriteLine(guildWithoutSpaces);
                        }
                    }
                }
            }
            System.Console.WriteLine();
        }

        public static List<Player> getAllPlayers()
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
                bool readingGear0 = false, readingGear1 = false, readingGear2 = false, readingGear3 = false, readingGear4 = false, readingGear5 = false, readingGear6 = false, readingGear7 = false, readingGear8 = false, readingGear9 = false, readingGear10 = false, readingGear11 = false, readingGear12 = false, readingGear13 = false;

                Race race;

                readingID = true;
                StringBuilder variableBuilder = new StringBuilder();
                uint g_index = 0;
                while (!inFile.EndOfStream)
                {
                    char ch = (char)inFile.Read();
                    int index_of = Program.allPossibleChars.IndexOf(ch);
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
                            readingGear6 = true;
                        }
                        else if (readingGear6)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear6 = false;
                            readingGear7 = true;
                        }
                        else if (readingGear7)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear7 = false;
                            readingGear8 = true;
                        }
                        else if (readingGear8)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear8 = false;
                            readingGear9 = true;
                        }
                        else if (readingGear9)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear9 = false;
                            readingGear10 = true;
                        }
                        else if (readingGear10)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear10 = false;
                            readingGear11 = true;
                        }
                        else if (readingGear11)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear11 = false;
                            readingGear12 = true;
                        }
                        else if (readingGear12)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear12 = false;
                            readingGear13 = true;
                        }
                        else if (readingGear13)
                        {
                            gear[g_index++] = Convert.ToUInt32(variableBuilder.ToString());
                            variableBuilder = new StringBuilder();
                            readingGear13 = false;
                            switch (Convert.ToUInt32(raceString))
                            {
                                case 0:
                                    race = Race.Orc;
                                    break;
                                case 1:
                                    race = Race.Troll;
                                    break;
                                case 2:
                                    race = Race.Tauren;
                                    break;
                                default:
                                    race = Race.Forsaken;
                                    break;
                            }
                            player_roster.Add(new Player(Convert.ToUInt32(idString), nameString, race, Convert.ToUInt32(levelString), Convert.ToUInt32(expString), Convert.ToUInt32(guildString), gear, inventory));
                            gear = new uint[GEAR_SLOTS];
                            g_index = 0;
                            inFile.Read();
                            readingID = true;
                        }
                    }
                    else
                    {
                        variableBuilder.Append(ch);
                    }
                }
                inventory.Add(Convert.ToUInt32(variableBuilder.ToString()));
                switch (Convert.ToUInt32(raceString))
                {
                    case 0:
                        race = Race.Orc;
                        break;
                    case 1:
                        race = Race.Troll;
                        break;
                    case 2:
                        race = Race.Tauren;
                        break;
                    default:
                        race = Race.Forsaken;
                        break;
                }
                gear[g_index] = Convert.ToUInt32(variableBuilder.ToString());
                player_roster.Add(new Player(Convert.ToUInt32(idString), nameString, race, Convert.ToUInt32(levelString), Convert.ToUInt32(expString), Convert.ToUInt32(guildString), gear, inventory));
            }
            return player_roster;
        }

        // Option 5
        public static void LeaveGuild(Player P)
        {
            P.GuildID = 0;
        }

        //Option 6
        public static void JoinGuild(Player P, string guild_to_join)
        {
            string player_name = P.Name;

            using (StreamWriter outFile = new StreamWriter("joinedguilds.txt"))
            {
                uint nextGuildID = 0;
                switch (guild_to_join)
                {
                    case "Knights of Cydonia":
                        nextGuildID = 475186;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    case "Death and Taxes":
                        nextGuildID = 748513;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    case "I Just Crit My Pants":
                        nextGuildID = 154794;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    case "What Have We Here":
                        nextGuildID = 928126;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    case "Big Dumb Guild":
                        nextGuildID = 513487;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    case "Honestly":
                        nextGuildID = 864722;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    case "Sacred Heart":
                        nextGuildID = 185470;
                        System.Console.WriteLine(player_name + " has joined " + guild_to_join.ToString() + "!");
                        break;
                    default:
                        System.Console.Write("FAILURE: No guilds by that name.");
                        System.Console.WriteLine();
                        break;
                }
                P.GuildID = nextGuildID;
            }
        }

        public static void determineType(ItemType type)
        {

            switch (Convert.ToUInt32(type))
            {
                case 0:
                    type = ItemType.Helmet;
                    break;
                case 1:
                    type = ItemType.Neck;
                    break;
                case 2:
                    type = ItemType.Shoulders;
                    break;
                case 3:
                    type = ItemType.Back;
                    break;
                case 4:
                    type = ItemType.Chest;
                    break;
                case 5:
                    type = ItemType.Wrist;
                    break;
                case 6:
                    type = ItemType.Gloves;
                    break;
                case 7:
                    type = ItemType.Belt;
                    break;
                case 8:
                    type = ItemType.Pants;
                    break;
                case 9:
                    type = ItemType.Boots;
                    break;
                case 10:
                    type = ItemType.Ring;
                    break;
                default:
                    type = ItemType.Trinket;
                    break;
            }
        }

        //********************************************************************************
        //
        //                                     equipGear
        //
        //********************************************************************************

        public static void EquipGear(Player player, string item_name)
        {
            uint nextItemId = 0;
            switch (item_name)
            {
                case "Newbie's Helmet":
                    nextItemId = 0001;
                    break;
                case "Newbie's Cloak":
                    nextItemId = 0002;
                    break;
                case "Newbie's Raiment":
                    nextItemId = 0003;
                    break;
                case "Newbie's Gloves":
                    nextItemId = 0004;
                    break;
                case "Newbie's Trousers":
                    nextItemId = 0005;
                    break;
                case "Newbie's Sandals":
                    nextItemId = 0006;
                    break;
                case "Slacker":
                    nextItemId = 1739;
                    break;
                case "Nebula's Skullcrusher":
                    nextItemId = 1337;
                    break;
                case "Helix Nebula":
                    nextItemId = 1338;
                    break;
                case "Nebula's Pauldrons":
                    nextItemId = 1339;
                    break;
                case "Dread Pirate Nebula's Cloak":
                    nextItemId = 1340;
                    break;
                case "Nebula's Resentment":
                    nextItemId = 1341;
                    break;
                case "Nebula's Wristguards":
                    nextItemId = 1342;
                    break;
                case "Nebula's Fury":
                    nextItemId = 1343;
                    break;
                case "The Spire":
                    nextItemId = 1344;
                    break;
                case "Nebula's Legguards":
                    nextItemId = 1345;
                    break;
                case "Nebula's Stompers":
                    nextItemId = 1346;
                    break;
                case "Gamora's Acceptance":
                    nextItemId = 1347;
                    break;
                case "Gamora's Love":
                    nextItemId = 1348;
                    break;
                case "Infinity Gauntlet":
                    nextItemId = 1349;
                    break;
                case "Endgame":
                    nextItemId = 1350;
                    break;
                default:
                    System.Console.Write("FAILURE: No items by that name.");
                    System.Console.WriteLine();
                    break;
            }
            uint[] player_gears = player.Gear;
            foreach (uint g in player_gears) // If they already have it.
            {
                if (g == nextItemId)
                {
                    System.Console.WriteLine(player.Name + " already has that.");
                    return;
                }
            }

            for (uint i = 0; i < GEAR_SLOTS; i++) // If their gears array has openings.
            {
                if (player.Gear[i] == 0)
                {
                    player.Gear[i] = nextItemId;
                    return;
                }
            }
            player.Gear[0] = nextItemId; // Replace the first gear.
        }

        //********************************************************************************
        //
        //                                     equipGear
        //
        //********************************************************************************
        public static void equipGear(Player player, string item_name)
        {
            uint nextItemId = 0;
            switch (item_name)
            {
                case "Newbie's Helmet":
                    nextItemId = 0001;
                    break;
                case "Newbie's Cloak":
                    nextItemId = 0002;
                    break;
                case "Newbie's Raiment":
                    nextItemId = 0003;
                    break;
                case "Newbie's Gloves":
                    nextItemId = 0004;
                    break;
                case "Newbie's Trousers":
                    nextItemId = 0005;
                    break;
                case "Newbie's Sandals":
                    nextItemId = 0006;
                    break;
                case "Slacker":
                    nextItemId = 1739;
                    break;
                case "Nebula's Skullcrusher":
                    nextItemId = 1337;
                    break;
                case "Helix Nebula":
                    nextItemId = 1338;
                    break;
                case "Nebula's Pauldrons":
                    nextItemId = 1339;
                    break;
                case "Dread Pirate Nebula's Cloak":
                    nextItemId = 1340;
                    break;
                case "Nebula's Resentment":
                    nextItemId = 1341;
                    break;
                case "Nebula's Wristguards":
                    nextItemId = 1342;
                    break;
                case "Nebula's Fury":
                    nextItemId = 1343;
                    break;
                case "The Spire":
                    nextItemId = 1344;
                    break;
                case "Nebula's Legguards":
                    nextItemId = 1345;
                    break;
                case "Nebula's Stompers":
                    nextItemId = 1346;
                    break;
                case "Gamora's Acceptance":
                    nextItemId = 1347;
                    break;
                case "Gamora's Love":
                    nextItemId = 1348;
                    break;
                case "Infinity Gauntlet":
                    nextItemId = 1349;
                    break;
                case "Endgame":
                    nextItemId = 1350;
                    break;
                default:
                    System.Console.Write("FAILURE: No items by that name.");
                    System.Console.WriteLine();
                    break;
            }
            uint[] player_gears = player.Gear;
            for (uint i = 0; i < GEAR_SLOTS; i++)
            {
                if (player_gears[i] == nextItemId)
                {
                    player_gears[i] = 0;
                    return;
                }
            }
            System.Console.WriteLine(player.Name + " did not have that to begin with.");
        }

        // Option 8
        
        public static void UnequipGear(Player player, string item_name)
        {
            uint nextItemId = 0;
            switch (item_name)
            {
                case "Newbie's Helmet":
                    nextItemId = 0001;
                    break;
                case "Newbie's Cloak":
                    nextItemId = 0002;
                    break;
                case "Newbie's Raiment":
                    nextItemId = 0003;
                    break;
                case "Newbie's Gloves":
                    nextItemId = 0004;
                    break;
                case "Newbie's Trousers":
                    nextItemId = 0005;
                    break;
                case "Newbie's Sandals":
                    nextItemId = 0006;
                    break;
                case "Slacker":
                    nextItemId = 1739;
                    break;
                case "Nebula's Skullcrusher":
                    nextItemId = 1337;
                    break;
                case "Helix Nebula":
                    nextItemId = 1338;
                    break;
                case "Nebula's Pauldrons":
                    nextItemId = 1339;
                    break;
                case "Dread Pirate Nebula's Cloak":
                    nextItemId = 1340;
                    break;
                case "Nebula's Resentment":
                    nextItemId = 1341;
                    break;
                case "Nebula's Wristguards":
                    nextItemId = 1342;
                    break;
                case "Nebula's Fury":
                    nextItemId = 1343;
                    break;
                case "The Spire":
                    nextItemId = 1344;
                    break;
                case "Nebula's Legguards":
                    nextItemId = 1345;
                    break;
                case "Nebula's Stompers":
                    nextItemId = 1346;
                    break;
                case "Gamora's Acceptance":
                    nextItemId = 1347;
                    break;
                case "Gamora's Love":
                    nextItemId = 1348;
                    break;
                case "Infinity Gauntlet":
                    nextItemId = 1349;
                    break;
                case "Endgame":
                    nextItemId = 1350;
                    break;
                default:
                    System.Console.Write("FAILURE: No items by that name.");
                    System.Console.WriteLine();
                    break;
            }
            uint[] player_gears = player.Gear;
            for (uint i = 0; i < GEAR_SLOTS; i++)
            {
                if (player_gears[i] == nextItemId)
                {
                    player_gears[i] = 0;
                    return;
                }
            }
            System.Console.WriteLine(player.Name + " did not have that to begin with.");
        }

        //********************************************************
        //
        //                                     AwardExp Method
        //
        //********************************************************

        // Option 9
        public static void AwardExp(Player P)
        {

            Console.WriteLine("Enter the amount of experience to award: ");
            uint award = Convert.ToUInt32(Console.ReadLine());
            uint lvl = P.Level;

            award += P.Exp;

            while (P.Level < 60 && award > (P.Level * 1000))
            {
                award = award - (P.Level * 1000);
                P.Level += 1;
                Console.WriteLine("Ding!");
            }
            P.Exp = award;
        }
    }
}
