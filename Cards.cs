using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace falaas
{
    class Cards
    {
        public String rank { get; set; }
        public String suit { get; set; }


        public Cards(String rank, String suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public String print()
        {
            //Precondition: Requires two strings to passed into the class.,
            //Postcondition: concatenates the two strings in order to make a single card.

            return (this.rank + " of " + this.suit);
        }
    }
}
