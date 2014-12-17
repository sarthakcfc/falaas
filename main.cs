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
            //The outer loop variable on this test will serve as the rank.
            for (int rank = 1; rank <= 13; rank++)
            {
                //the inner loop variable serves as the suit number that gets passed in.
                for (int suit = 1; suit <= 4; suit++)
                {
                    //These staements will print out the deck into the console.
                    Deck d = new Deck(rank - 1, suit - 1);
                    Cards c = new Cards(d.getRank(), d.getSuit());
                    Console.WriteLine(c.print());
                }
            }
           
            
        }
    }
}
