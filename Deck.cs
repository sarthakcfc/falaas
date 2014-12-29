using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace falaas
{
    class Deck
    {
        /*public int rank { get; set; }
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
        }*/

        //Creates a Deck when it's called
        private List<Cards> newDeck = new List<Cards>();        //Creates a list to store all the cards in a deck

        public Deck()       //Default Constructor, calls the function to create a deck
        {
            create();
        }

        public void create()    //creates the deck itself. Fills the list with all the card values
        {
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    newDeck.Add(new Cards(rank, suit));
                }
            }
        }

        public void shuffle()
        {
            Random r = new Random();
            int shufflePoint = r.Next(20, 30);
            Cards[] s1 = new Cards[shufflePoint];
            Cards[] s2 = new Cards[52 - shufflePoint];
            int index = 0;
            for (; index < s1.Length; index++)
            {
                s1[index] = newDeck.ElementAt(index);
            }
            index++;
            for (int i = 0; i < s2.Length; i++)
            {
                s2[i] = newDeck.ElementAt(index-1);
                index++;
            }
            newDeck.Clear();
            for (int i = 0; i < 52; i=i+2)
            {
                int getRand = r.Next(0, shufflePoint);
                int getRand2 = r.Next(0, (52 - shufflePoint));
                newDeck.Add(s1[getRand]);
                newDeck.Add(s2[getRand2]);
            }

            for (int i = 0; i < 52; i++)
            {
                int firstCard = r.Next(0, 26);
                int secondCard = r.Next(firstCard, 52);
                swap(firstCard, secondCard);
            }
        }

        public void swap(int i, int j)
        {
            Cards temp = newDeck.ElementAt(i);
            newDeck.Insert(i, newDeck.ElementAt(j));
            newDeck.Insert(j, temp);

        }
       override public string ToString()    // Prints the Deck
        {
            String d = "";
            foreach (Cards c in newDeck)
            {
                d += c.ToString() + "\n";
            }
            return d;
        }
    
        
    }
}
