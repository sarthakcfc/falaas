using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace falaas
{
    class Deck
    {
        public int rank { get; set; }
        public int suit { get; set; }
        public Deck(int rank, int suit)
        {
            this.rank = rank;
            this.suit = suit;
        }
        public string getRank()
        {
            //Precondition: Must have an integer value, for rank, passed into the class.
            //Postcondition: returns the appropriate rank in accorfance to the passed in integer value.

            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six",
                            "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};


            return ranks[this.rank];
        }
        public string getSuit()
        {
            //Precondition: Must have an integer value passed into the class for the suit.
            //Postcondition: returns the appropriate suit in accorfance to the passed in integer value.

            string[] suits = { "Diamonds", "Spades", "Hearts", "Clubs" };

            return suits[this.suit];
        }
    
        
    }
}
