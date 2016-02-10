using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Card
    {
        int cardNum;            // Number of card (1 - 13)
        string cardName;        // Name of card (Ace (A) - King (K))
        int suitNum;            // Number of suit (1 - 4)
        string suitName;        // Name of suit (Club, Diamond, Heart, Spade)

        static int numCards = 0;  // Total number of cards

        public Card(int cardNum, int suitNum)
        {
            this.cardNum = cardNum;
            this.suitNum = suitNum;

            // Determine card name
            switch (cardNum)
            {
                case 1:
                    cardName = "A";
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    cardName = Convert.ToString(cardNum);
                    break;
                case 11:
                    cardName = "J";
                    break;
                case 12:
                    cardName = "Q";
                    break;
                case 13:
                    cardName = "K";
                    break;
            }

            // Determine suit name
            switch (suitNum)
            {
                case 1:
                    suitName = "Clubs";
                    break;
                case 2:
                    suitName = "Diamonds";
                    break;
                case 3:
                    suitName = "Hearts";
                    break;
                case 4:
                    suitName = "Spades";
                    break;
            }

            numCards++;
        }

        public string cName
        {
            get { return cardName; }
        }

        public string sName
        {
            get { return suitName; }
        }

        public int cNum
        {
            get { return cardNum; }
        }

        public int sNum
        {
            get { return suitNum; }
        }

        public static int getNumCards()
        {
            return numCards;
        }

        public static void setNumCards(int num)
        {
            numCards = num;
        }
    }
}