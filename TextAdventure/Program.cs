using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Program
    {
        static string response = "";

        static NavMaster _nm = new NavMaster();

        static Player p = new Player();

        static void Main(string[] args)
        {
            Intro();
            _nm.CreateRooms();

            while (true)
            {
                GetResponse();
            }
        }

        static void GetResponse()
        {
            response = Console.ReadLine();

            ResolveResponse();
        }

        static void ResolveResponse()
        {
            string[] splitResponse = new string[3];

            if (response.Contains(" ")) {
                splitResponse = response.Split(null); 
            }

            if (String.Compare("help", response, StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.Write("here are some handy commands:\n\nHELP : brings up this list of handy commands\n\n" +
                        "SEARCH : searches the current room for stuff you can pickup or use\n\n" +
                        "PICKUP 'OBJECT' : pickes up the object that you're referencing if it is in the room and pickupable\n\n" +
                        "GO 'NORTH/EAST/SOUTH/WEST' : goes to the next room\n\n" +
                        "USE 'OBJECT' : uses the object you selected\n\n" +
                        "DROP 'OBJECT' : droppes the object you selected from your inventory, and adds it to the room's inventory\n\n" +
                        "DOORS : gives you a list of all the doors in the room\n\n" +
                        "INVENTORY : gives you a list of all the items in your inventory\n\n");
            }

            else if (String.Compare("search", response, StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.WriteLine("\nthe " + _nm.curRoom.GetName() + "room contains:");

                foreach (GameObject gm in _nm.curRoom.GetInventory())
                {
                    Console.WriteLine(gm.GetName());
                }
            }

            else if (String.Compare("pickup", splitResponse[0], StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (_nm.curRoom.TakeFromInventory(splitResponse[1], p))
                {
                    Console.WriteLine("\nyou've taken " + splitResponse[1] + " and put it in your inventory!\n");
                } else
                {
                    Console.WriteLine(splitResponse[1] + " is not a item in the inventory of the " + _nm.curRoom.GetName() + " room");
                }
            }

            else if (String.Compare("go", splitResponse[0], StringComparison.OrdinalIgnoreCase) == 0)
            {
                int match = 0;

                foreach (var d in _nm.curRoom.GetDoors())
                {
                    if (String.Compare(splitResponse[1], d.Value, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (d.Key.GetLocked())
                        {
                            if (p.inventory.Count > 0)
                            {
                                foreach (GameObject gm in p.inventory)
                                {
                                    if ("key_" + d.Key.GetName() == gm.GetName())
                                    {
                                        match = 1;
                                        _nm.curRoom = d.Key;
                                        Console.WriteLine("\nYou've unlocked and entered the " + d.Key.GetName() + " room\n");
                                        break;
                                    }
                                    else
                                    {
                                        match = -1;
                                    }
                                }
                            }else
                            {
                                match = -1;
                            }
                        }
                        else
                        {
                            match = 1;
                            _nm.curRoom = d.Key;
                        }
                    }
                }
                if (match == 0)
                {
                    Console.WriteLine("\n" + splitResponse[1] + " is not a valid imput");
                }
                if(match == -1)
                {
                    Console.WriteLine("You do not posses the key to this room");
                }
            }

            else if (String.Compare("use", splitResponse[0], StringComparison.OrdinalIgnoreCase) == 0)
            {
                foreach (GameObject gm in p.inventory)
                {
                    if (String.Compare(gm.GetName(), splitResponse[1], StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if(gm.GetUsable())
                        {
                            gm.Use();
                            break;
                        }
                    }
                }
            }

            else if (String.Compare("drop", splitResponse[0], StringComparison.OrdinalIgnoreCase) == 0)
            {
                GameObject toRemove = null;

                foreach (GameObject gm in p.inventory)
                {
                    if(String.Compare(gm.GetName(), splitResponse[1], StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        toRemove = gm;
                        _nm.curRoom.GetInventory().Add(gm);
                        break;
                    }
                }

                if(toRemove != null)
                {
                    p.inventory.Remove(toRemove);
                    Console.WriteLine("\nyou have dropped " + splitResponse[1] + " on the floor of the room\n");
                }else
                {
                    Console.WriteLine("\n" + splitResponse[1] + " is not a item in your inventory");
                }
            }

            else if (String.Compare("doors", response, StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.WriteLine("\nyou got door(s) on your: \n");

                foreach (var d in _nm.curRoom.GetDoors())
                {
                    Console.WriteLine(d.Value + "\n");
                }
            }

            else if (String.Compare("inventory", response, StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.WriteLine("\nYour inventory consists of...\n");

                foreach(GameObject gm in p.inventory)
                {
                    Console.WriteLine(gm.GetName());
                }
            }
        }

        static void Intro()
        {
            Console.Write("Welcome to this Text Adventure game that has not have a name yet.\n" +
                        "here are some handy commands:\n\nHELP : brings up this list of handy commands\n\n" +
                        "SEARCH : searches the current room for stuff you can pickup or use\n\n" +
                        "PICKUP 'OBJECT' : pickes up the object that you're referencing if it is in the room and pickupable\n\n" +
                        "GO 'NORTH/EAST/SOUTH/WEST' : goes to the next room\n\n" +
                        "USE 'OBJECT' : uses the object you selected\n\n" +
                        "DROP 'OBJECT' : droppes the object you selected from your inventory, and adds it to the room's inventory\n\n" +
                        "DOORS : gives you a list of all the doors in the room\n\n" +
                        "INVENTORY : gives you a list of all the items in your inventory\n\n");
        }
    }
}
