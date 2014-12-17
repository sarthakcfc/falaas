using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace falaas
{
    class main
    {
        public static void Main()
        {
            Cards c = new Cards("Ace", "Spades");
            Console.WriteLine(c.print());
        }
    }
}
