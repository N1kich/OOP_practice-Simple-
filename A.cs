using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_practice
{
    public class A
    {
        public void M()
        {
            Console.WriteLine("Method by A class " + this.GetType().ToString());
        }
        public void C()
        {

        }
    }

    public class B : A
    {
        public new void M()
        {
            Console.WriteLine("Method from B class " + this.GetType().ToString());
        }
    }
}
