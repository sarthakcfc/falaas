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
            return (this.rank + " of " + this.suit);
        }
    }
}
