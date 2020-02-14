using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Medical : GameObject
    {
        public Medical(int size, string name)
        {
            this.size = size;
            this.name = name;

            usable = true;
        }

        protected override void UseItem()
        {
            Console.WriteLine("you just took meds yo");
        }
    }
}
