using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Program
    {
        static void Main()
        {
            Intro();
            while (true) {

            }

        }
        
        static void Intro()
        {
            Console.Write("Welcome to this Text Adventure game that has not have a name yet.\n" +
                        "here are some handy commands:\n\nhelp : brings up this list of handy commands\n\n" +
                        "SEARCH ROOM : searches the current room for stuff you can pickup or use\n\n" +
                        "PICKUP 'OBJECT' : pickes up the object that you're referencing if it is in the room and pickupable\n\n" +
                        "GO 'NORTH/EAST/SOUTH/WEST' : goes to the next room\n");
        }
    }
}
