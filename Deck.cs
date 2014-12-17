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
            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six",
                            "Seven", "Eight", "Nine", "Tent", "Jack", "Queen", "King"};


            return ranks[this.rank];
        }
        public string getSuit()
        {
            string[] suits = { "Diamonds", "Spades", "Hearts", "Clubs" };

            return suits[this.suit];
        }
    
        
    }
}
