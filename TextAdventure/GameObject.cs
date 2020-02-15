using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    abstract class GameObject
    {
        protected int size;
        protected string name;
        protected bool usable;

        public void Use()
        {
            if(usable)
            {
                UseItem();
                Console.WriteLine("\n" + name + " has been used\n");
            }else
            {
                Console.WriteLine("This item is not a usable object, try something else!");
            }
        }

        protected abstract void UseItem();

        public int GetSize()
        {
            return size;
        }

        public bool GetUsable()
        {
            return usable;
        }

        public string GetName()
        {
            return name;
        }
    }
}
