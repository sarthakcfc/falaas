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
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Deck d = new Deck(i, j);
                    Cards c = new Cards(d.getRank(), d.getSuit());
                    Console.WriteLine(c.print());
                }
            }
           
            
        }
    }
}
