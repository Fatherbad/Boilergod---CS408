using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Game
{
    class Deck
    {
        protected static ArrayList deck = new ArrayList();
        const int LB = 1;
        const int UBNAME = 14;
        const int UBSUIT = 5;

        public Deck()
        {
            createNewDeck();
        }

        public static void createNewDeck()
        {
            deck.Clear();
            Console.WriteLine("asdfasdf");
            Random r = new Random();
            //ArrayList deck = new ArrayList();               // ArrayList of Card Objects (52) to make a full deck of cards
            int cardNum;
            int suitNum;

            while (true)
            {
                // Ensure proper number of cards
                if (Card.getNumCards() >= 52)
                {
                    break;
                }

                // Ensure proper number of card names
                while (true)
                {
                    cardNum = r.Next(LB, UBNAME);
                    int numTimes = 0;
                    foreach (Card c in deck)
                    {
                        if (c.cNum == cardNum)
                        {
                            numTimes++;
                        }
                    }
                    if (numTimes < 4)
                    {
                        break;
                    }
                }

                // Ensure proper number of suits
                while (true)
                {
                    suitNum = r.Next(LB, UBSUIT);
                    int numTimes = 0;
                    foreach (Card c in deck)
                    {
                        if (c.sNum == suitNum)
                        {
                            numTimes++;
                        }
                    }
                    if (numTimes < 13)
                    {
                        break;
                    }
                }

                // Ensure no duplicate cards
                int duplicates = 0;
                foreach (Card c in deck)
                {
                    int num = c.cNum;
                    int suit = c.sNum;
                    if ((num == cardNum) && (suit == suitNum))
                    {
                        duplicates++;
                    }
                }
                if (duplicates >= 1)
                {
                    continue;
                }

                // Add card to deck
                deck.Add(new Card(cardNum, suitNum));
            }
            showDeck();
        }

        public static void showDeck()
        {
            for (int i = 0; i < deck.Count; i++)
            {
                Card c = (Card)deck[i];
                Console.WriteLine("{0}:  Name: {1}  Suit: {2}", i, c.cName, c.sName);
            }
        }

        public void testShuffle()
        {
            int numClubs = 0;
            int numDiamonds = 0;
            int numHearts = 0;
            int numSpades = 0;
            for (int i = 0; i < 4; i++)
            {
                foreach (Card c in deck)
                {
                    if (c.sName.Equals("Clubs") && i == 0)
                    {
                        numClubs++;
                    }

                    if (c.sName.Equals("Diamonds") && i == 1)
                    {
                        numDiamonds++;
                    }

                    if (c.sName.Equals("Hearts") && i == 2)
                    {
                        numHearts++;
                    }

                    if (c.sName.Equals("Spades") && i == 3)
                    {
                        numSpades++;
                    }
                }
            }
            Console.WriteLine("{0} clubs", numClubs);
            Console.WriteLine("{0} diamonds", numDiamonds);
            Console.WriteLine("{0} hearts", numHearts);                                                       
            Console.WriteLine("{0} spades", numSpades);
            int numAces = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int numJ = 0;
            int numQ = 0;
            int numK = 0;
            for (int i = 0; i < 7; i++)
            {
                foreach (Card c in deck)
                {
                    if (c.cNum == 1 && i == 0)
                    {
                        numAces++;
                    }

                    if (c.cNum == 2 && i == 1)
                    {
                        num2++;
                    }

                    if (c.cNum == 3 && i == 2)
                    {
                        num3++;
                    }

                    if (c.cNum == 4 && i == 3)
                    {
                        num4++;
                    }

                    if (c.cNum == 11 && i == 4)
                    {
                        numJ++;
                    }

                    if (c.cNum == 12 && i == 5)
                    {
                        numQ++;
                    }

                    if (c.cNum == 13 && i == 6)
                    {
                        numK++;
                    }
                }
            }
            Console.WriteLine("{0} aces", numAces);
            Console.WriteLine("{0} twos", num2);
            Console.WriteLine("{0} threes", num3);
            Console.WriteLine("{0} fours", num4);
            Console.WriteLine("{0} jacks", numJ);
            Console.WriteLine("{0} queens", numQ);
            Console.WriteLine("{0} kings", numK);
        }
    }
}
