using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace falaas
{
    /*
     * Creates an Enum of Ranks. Predefined Constants for Cards
     */
    public enum ranks
    {
        Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13
    }

    /*
     * Creates an Enum for suits. Predefined Constants for Cards
     */
    public enum suits
    {
        Spades = 1, Club = 2, Heart = 3, Diamond = 4
    }

    /*
     * Class for Cards. Creates a card from the two predefined enums. 
     */
    class Cards
    {
        public suits suit { get; private set; }
        public ranks rank { get; private set; }


        public Cards(int rank, int suit)    //Constructor, takes in two integer (for rank and suit)
        {
            this.rank = (ranks)rank;
            this.suit = (suits)suit;
        }

        public String ToString()
        {
            //Precondition: Requires two integers to passed into the class.,
            //Postcondition: concatenates the two strings in order to make a single card.

            return (this.rank + " of " + this.suit);
        }
    }
}
