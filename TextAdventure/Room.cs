using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Room
    {
        private List<GameObject> inventory = new List<GameObject>();
        private Dictionary<Room, string> doors = new Dictionary<Room, string>();

        private bool locked = false;
        
        private string name;

        public Room(string name, bool locked = false) // N E S W
        {
            this.name = name;
            this.locked = locked;

            SpawnLoot();
        }

        private void SpawnLoot()
        {
            Medical m = new Medical(2, "car_fak");
            inventory.Add(m);
        }

        public void AddDoors(Room room, string orientation)
        {
            this.doors.Add(room, orientation);
        }

        public Dictionary<Room, string> GetDoors()
        {
            return doors;
        }

        public string GetName()
        {
            return name;
        }

        public List<GameObject> GetInventory()
        {
            return inventory;
        }

        public bool TakeFromInventory(string name, Player p)
        {
            GameObject ToRemove = null;
            bool success = false;

            foreach(GameObject cgm in inventory)
            {
                if(name == cgm.GetName())
                {
                    p.inventory.Add(cgm);
                    ToRemove = cgm;
                    success = true;
                }
            }
            if (success)
            {
                inventory.Remove(ToRemove);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
