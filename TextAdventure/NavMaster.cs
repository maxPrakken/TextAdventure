using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class NavMaster
    {
        public List<Room> allRooms = new List<Room>();

        public Room curRoom;

        public NavMaster()
        {
            
        }

        public void CreateRooms()
        {
            Room start = new Room("start");
            Room hub = new Room("hub");
            Room living = new Room("living");
            Room kitchen = new Room("kitchen");
            Room garage = new Room("garage");
            Room secret = new Room("secret", true);

            start.AddDoors(hub, "east");

            hub.AddDoors(living, "north");
            hub.AddDoors(kitchen, "south");
            hub.AddDoors(garage, "east");
            hub.AddDoors(start, "west");

            living.AddDoors(hub, "south");

            kitchen.AddDoors(hub, "north");
            kitchen.AddDoors(secret, "east");

            garage.AddDoors(hub, "west");
            garage.AddDoors(secret, "south");

            secret.AddDoors(garage, "north");
            secret.AddDoors(kitchen, "west");

            allRooms.Add(start);
            allRooms.Add(hub);
            allRooms.Add(living);
            allRooms.Add(kitchen);
            allRooms.Add(garage);
            allRooms.Add(secret);

            curRoom = start;
        }
    }
}
