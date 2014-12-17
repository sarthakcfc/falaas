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
            //This loop prints out the entire deck with 52 cards in order//
            //The outer loop variable "i" on this test will serve as the rank.
            for (int i = 1; i <= 13; i++)
            {
                //the inner loop variable serves as the suit number that gets passed in.
                for (int j = 1; j <= 4; j++)
                {
                    //These staements will print out the deck into the console.
                    Deck d = new Deck(i - 1, j - 1);
                    Cards c = new Cards(d.getRank(), d.getSuit());
                    Console.WriteLine(c.print());
                }
            }
           
            
        }
    }
}
    }
}

