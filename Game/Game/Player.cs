using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    class Player : Deck
    {
        static ArrayList hand = new ArrayList();

        public Player() : base()
        {
            // Take the first 5 cards of the deck and put into hand
            // Remove those cards from the deck
            hand.Clear();
            for (int i = 0; i < 5; i++)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
            }
        }

        public static void showHand()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Card c = (Card) hand[i];
                Console.WriteLine("{0}:  Name: {1}  Suit: {2}", i, c.cName, c.sName);
            }
        }

        public static ArrayList getHand()
        {
            return hand;
        }

        public static ArrayList getDeck()
        {
            return deck;
        }

        public static void getNewHand(bool[] cardIndicesReq)
        {
            for (int i = 0; i < 5; i++)
            {
                if (cardIndicesReq[i])          // If this card needs to be replaced because it is held
                {
                    hand.RemoveAt(i);
                    hand.Insert(i, deck[0]);
                    deck.RemoveAt(0);
                }
            }
        }

        public static void playerNewGame()
        {
            Card.setNumCards(0);
            //new Player();
            createNewDeck();
            hand.Clear();
            for (int i = 0; i < 5; i++)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
            }
            showHand();
        }
    }

    public partial class Form1
    {
        bool card1Hold = false;
        bool card2Hold = false;
        bool card3Hold = false;
        bool card4Hold = false;
        bool card5Hold = false;

        public ArrayList testHand()
        {
            ArrayList hand = new ArrayList();
            Card c1 = new Card(10, 2);
            Card c2 = new Card(1, 1);
            Card c3 = new Card(11, 1);
            Card c4 = new Card(12, 4);
            Card c5 = new Card(13, 1);
            hand.Add(c1);
            hand.Add(c2);
            hand.Add(c3);
            hand.Add(c4);
            hand.Add(c5);

            return hand;
        }

        protected void checkWin()
        {
            int amount = 0;
            win = true;
            ArrayList hand = Player.getHand();
            //ArrayList hand = testHand();

            // Check for pair, three of a kind, four of a kind, 2 pair, full house
            int count = 0;
            foreach (Card c in hand)
            {
                int num = c.cNum;
                count = 0;
                foreach (Card cc in hand)
                {
                    if (num == cc.cNum)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    count = 0;
                    foreach (Card ccc in hand)
                    {
                        if (ccc.cNum == num)
                        {
                            continue;
                        }
                        int num2 = ccc.cNum;
                        count = 0;
                        foreach (Card cccc in hand)
                        {
                            if (num2 == cccc.cNum)
                            {
                                count++;
                            }
                        }
                        if (count == 2)
                        {
                            //winLabel.Text = "Two pair";
                            winLabel.Visible = true;
                            twoPairLabel.ForeColor = System.Drawing.Color.White;
                            winAmountLabel.Visible = true;
                            amount = 2 * betAmount;
                            winAmountLabel.Text = "WIN " + amount;
                            numCredits += amount;
                            creditLabel.Text = "CREDIT " + numCredits;
                            switch (betAmount)
                            {
                                case 1:
                                    tp1Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 2:
                                    tp2Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 3:
                                    tp3Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 4:
                                    tp4Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 5:
                                    tp5Label.ForeColor = System.Drawing.Color.White;
                                    break;
                            }
                            return;
                        }
                        if (count == 3)
                        {
                            //winLabel.Text = "Full house";
                            winLabel.Visible = true;
                            fullHouselabel.ForeColor = System.Drawing.Color.White;
                            winAmountLabel.Visible = true;
                            amount = 9 * betAmount;
                            winAmountLabel.Text = "WIN " + amount;
                            numCredits += amount;
                            creditLabel.Text = "CREDIT " + numCredits;
                            switch (betAmount)
                            {
                                case 1:
                                    fh1Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 2:
                                    fh2Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 3:
                                    fh3Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 4:
                                    fh4Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 5:
                                    fh5Label.ForeColor = System.Drawing.Color.White;
                                    break;
                            }
                            return;
                        }
                    }

                    //winLabel.Text = "Pair";
                    //winLabel.Visible = true;
                    //break;
                    //return;
                }
                if (count == 3)
                {
                    count = 0;
                    foreach (Card ccc in hand)
                    {
                        if (ccc.cNum == num)
                        {
                            continue;
                        }
                        int num2 = ccc.cNum;
                        count = 0;
                        foreach (Card cccc in hand)
                        {
                            if (num2 == cccc.cNum)
                            {
                                count++;
                            }
                        }
                        if (count == 2)
                        {
                            //winLabel.Text = "Full house";
                            winLabel.Visible = true;
                            fullHouselabel.ForeColor = System.Drawing.Color.White;
                            winAmountLabel.Visible = true;
                            amount = 9 * betAmount;
                            winAmountLabel.Text = "WIN " + amount;
                            numCredits += amount;
                            creditLabel.Text = "CREDIT " + numCredits;
                            switch (betAmount)
                            {
                                case 1:
                                    fh1Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 2:
                                    fh2Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 3:
                                    fh3Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 4:
                                    fh4Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 5:
                                    fh5Label.ForeColor = System.Drawing.Color.White;
                                    break;
                            }
                            return;
                        }
                    }

                    //winLabel.Text = "Three of a kind";
                    winLabel.Visible = true;
                    threeKindLabel.ForeColor = System.Drawing.Color.White;
                    winAmountLabel.Visible = true;
                    amount = 3 * betAmount;
                    winAmountLabel.Text = "WIN " + amount;
                    numCredits += amount;
                    creditLabel.Text = "CREDIT " + numCredits;
                    switch (betAmount)
                    {
                        case 1:
                            tk1Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 2:
                            tk2Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 3:
                            tk3Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 4:
                            tk4Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 5:
                            tk5Label.ForeColor = System.Drawing.Color.White;
                            break;
                    }
                    return;
                }
                if (count == 4)
                {
                    //winLabel.Text = "Four of a kind";
                    winLabel.Visible = true;
                    fourKindLabel.ForeColor = System.Drawing.Color.White;
                    winAmountLabel.Visible = true;
                    amount = 25 * betAmount;
                    winAmountLabel.Text = "WIN " + amount;
                    numCredits += amount;
                    creditLabel.Text = "CREDIT " + numCredits;
                    switch (betAmount)
                    {
                        case 1:
                            fk1Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 2:
                            fk2Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 3:
                            fk3Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 4:
                            fk4Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 5:
                            fk5Label.ForeColor = System.Drawing.Color.White;
                            break;
                    }
                    return;
                }
            }

            // Check for a straight, straight flush, royal flush
            foreach (Card c in hand)
            {
                // Handle possible straight with ace
                ArrayList al = new ArrayList();
                foreach (Card cc in hand)
                {
                    al.Add(cc.cNum);
                }
                al.Sort();
                if (al[0].Equals(1) && al[1].Equals(10) && al[2].Equals(11) && al[3].Equals(12) && al[4].Equals(13))
                {
                    // Check if the Straight is a Straight Flush
                    Card ccc = (Card)hand[0];
                    bool flush = true;
                    foreach (Card cccc in hand)
                    {
                        if (ccc.sNum != cccc.sNum)
                        {
                            flush = false;
                            break;
                        }
                    }
                    if (flush)
                    {
                        //winLabel.Text = "Straight Flush";
                        winLabel.Visible = true;
                        straightFlushLabel.ForeColor = System.Drawing.Color.White;
                        winAmountLabel.Visible = true;
                        amount = 50 * betAmount;
                        winAmountLabel.Text = "WIN " + amount;
                        numCredits += amount;
                        creditLabel.Text = "CREDIT " + numCredits;
                        switch (betAmount)
                        {
                            case 1:
                                sf1Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 2:
                                sf2Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 3:
                                sf3Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 4:
                                sf4Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 5:
                                sf5Label.ForeColor = System.Drawing.Color.White;
                                break;
                        }
                        return;
                    }

                    //winLabel.Text = "Straight";
                    winLabel.Visible = true;
                    straightLabel.ForeColor = System.Drawing.Color.White;
                    winAmountLabel.Visible = true;
                    amount = 4 * betAmount;
                    winAmountLabel.Text = "WIN " + amount;
                    numCredits += amount;
                    creditLabel.Text = "CREDIT " + numCredits;
                    switch (betAmount)
                    {
                        case 1:
                            s1Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 2:
                            s2Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 3:
                            s3Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 4:
                            s4Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 5:
                            s5Label.ForeColor = System.Drawing.Color.White;
                            break;
                    }
                    return;
                }

                int num = c.cNum;
                int n = num;

            restart:
                foreach (Card cc in hand)
                {
                    if (cc.cNum == n)
                    {
                        continue;
                    }
                    if (cc.cNum == n + 1)
                    {
                        n++;
                        if (n - num == 4)
                        {
                            // Check if the Straight is a Straight Flush
                            Card ccc = (Card)hand[0];
                            bool flush = true;
                            foreach (Card cccc in hand)
                            {
                                if (ccc.sNum != cccc.sNum)
                                {
                                    flush = false;
                                    break;
                                }
                            }
                            if (flush)
                            {
                                //winLabel.Text = "Straight Flush";
                                winLabel.Visible = true;
                                straightFlushLabel.ForeColor = System.Drawing.Color.White;
                                winAmountLabel.Visible = true;
                                amount = 50 * betAmount;
                                winAmountLabel.Text = "WIN " + amount;
                                numCredits += amount;
                                creditLabel.Text = "CREDIT " + numCredits;
                                switch (betAmount)
                                {
                                    case 1:
                                        sf1Label.ForeColor = System.Drawing.Color.White;
                                        break;
                                    case 2:
                                        sf2Label.ForeColor = System.Drawing.Color.White;
                                        break;
                                    case 3:
                                        sf3Label.ForeColor = System.Drawing.Color.White;
                                        break;
                                    case 4:
                                        sf4Label.ForeColor = System.Drawing.Color.White;
                                        break;
                                    case 5:
                                        sf5Label.ForeColor = System.Drawing.Color.White;
                                        break;
                                }
                                return;
                            }

                            //winLabel.Text = "Straight";
                            winLabel.Visible = true;
                            straightLabel.ForeColor = System.Drawing.Color.White;
                            winAmountLabel.Visible = true;
                            amount = 4 * betAmount;
                            winAmountLabel.Text = "WIN " + amount;
                            numCredits += amount;
                            creditLabel.Text = "CREDIT " + numCredits;
                            switch (betAmount)
                            {
                                case 1:
                                    s1Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 2:
                                    s2Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 3:
                                    s3Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 4:
                                    s4Label.ForeColor = System.Drawing.Color.White;
                                    break;
                                case 5:
                                    s5Label.ForeColor = System.Drawing.Color.White;
                                    break;
                            }
                            return;
                        }
                        goto restart;
                    }
                }
            }

            // Check for a flush
            foreach (Card c in hand)
            {
                int suit = c.sNum;
                bool flush = true;

                foreach (Card cc in hand)
                {
                    if (suit != cc.sNum)
                    {
                        flush = false;
                        break;
                    }
                }

                if (flush)
                {
                    // Check if the Straight Flush is a Royal Flush
                    int tens = 0;
                    int jacks = 0;
                    int queens = 0;
                    int kings = 0;
                    int aces = 0;
                    foreach (Card c5 in hand)
                    {
                        if (c5.cNum == 10)
                        {
                            tens++;
                        }
                        if (c5.cNum == 11)
                        {
                            jacks++;
                        }
                        if (c5.cNum == 12)
                        {
                            queens++;
                        }
                        if (c5.cNum == 13)
                        {
                            kings++;
                        }
                        if (c5.cNum == 1)
                        {
                            aces++;
                        }
                    }
                    if (tens == 1 && jacks == 1 && queens == 1 && kings == 1 && aces == 1)
                    {
                        //winLabel.Text = "ROYAL FLUSH!!";
                        winLabel.Visible = true;
                        royalFlushLabel.ForeColor = System.Drawing.Color.White;
                        winAmountLabel.Visible = true;
                        amount = 250 * betAmount;
                        winAmountLabel.Text = "WIN " + amount;
                        numCredits += amount;
                        creditLabel.Text = "CREDIT " + numCredits;
                        switch (betAmount)
                        {
                            case 1:
                                rf1Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 2:
                                rf2Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 3:
                                rf3Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 4:
                                rf4Label.ForeColor = System.Drawing.Color.White;
                                break;
                            case 5:
                                rf5Label.ForeColor = System.Drawing.Color.White;
                                amount = 4000;
                                winAmountLabel.Text = "WIN " + amount;
                                break;
                        }
                        return;
                    }

                    //winLabel.Text = "Flush";
                    winLabel.Visible = true;
                    flushLabel.ForeColor = System.Drawing.Color.White;
                    winAmountLabel.Visible = true;
                    amount = 6 * betAmount;
                    winAmountLabel.Text = "WIN " + amount;
                    numCredits += amount;
                    creditLabel.Text = "CREDIT " + numCredits;
                    switch (betAmount)
                    {
                        case 1:
                            f1Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 2:
                            f2Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 3:
                            f3Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 4:
                            f4Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 5:
                            f5Label.ForeColor = System.Drawing.Color.White;
                            break;
                    }
                    return;
                }
            }

            // Check for Jacks or Better
            foreach (Card c in hand)
            {
                int num = c.cNum;
                if ((num < 11) && (num != 1))
                {
                    continue;
                }
                count = 0;

                foreach (Card cc in hand)
                {
                    if (cc.cNum == num)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    //winLabel.Text = "Jacks or Better";
                    winLabel.Visible = true;
                    jacksBetterLabel.ForeColor = System.Drawing.Color.White;
                    winAmountLabel.Visible = true;
                    amount = 1 * betAmount;
                    winAmountLabel.Text = "WIN " + amount;
                    numCredits += amount;
                    creditLabel.Text = "CREDIT " + numCredits;
                    switch (betAmount)
                    {
                        case 1:
                            jb1Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 2:
                            jb2Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 3:
                            jb3Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 4:
                            jb4Label.ForeColor = System.Drawing.Color.White;
                            break;
                        case 5:
                            jb5Label.ForeColor = System.Drawing.Color.White;
                            break;
                    }
                    return;
                }
            }

            // The hand is not a winner
            win = false;
            gameOverLabel.Visible = true;
        }

        protected void newGame()
        {
            Player.playerNewGame();
        }

        protected void setHold(int cardNum, bool hold)
        {
            switch (cardNum)
            {
                case 1:
                    card1Hold = hold;
                    break;
                case 2:
                    card2Hold = hold;
                    break;
                case 3:
                    card3Hold = hold;
                    break;
                case 4:
                    card4Hold = hold;
                    break;
                case 5:
                    card5Hold = hold;
                    break;
            }
        }

        public void getNewCards()
        {
            bool[] cardIndices = { false, false, false, false, false };
            if (!card1Hold)
                cardIndices[0] = true;
            if (!card2Hold)
                cardIndices[1] = true;
            if (!card3Hold)
                cardIndices[2] = true;
            if (!card4Hold)
                cardIndices[3] = true;
            if (!card5Hold)
                cardIndices[4] = true;
            Player.getNewHand(cardIndices);
            getCards();
        }

        public void getCards()
        {
            ArrayList hand = Player.getHand();
            //card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/deck_1.png");

            for (int i = 0; i < 5; i++)
            {
                Card c = (Card)hand[i];
                int num = c.cNum;
                int suit = c.sNum;
                switch (num)
                {
                    case 1:                     // Ace
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ace_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 2:                     // Two
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/two_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 3:                     // Three
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/three_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 4:                     // Four
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/four_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 5:                     // Five
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/five_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 6:                     // Six
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/six_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 7:                     // Seven
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/seven_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 8:                     // Eight
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/eight_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 9:                     // Nine
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/nine_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 10:                    // Ten
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/ten_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 11:                    // Jack
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/jack_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 12:                    // Queen
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/queen_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 13:                    // King
                        switch (suit)
                        {
                            case 1:             // Clubs
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_clubs.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_clubs.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_clubs.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_clubs.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_clubs.png");
                                        break;
                                }
                                break;
                            case 2:             // Diamonds
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_diamonds.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_diamonds.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_diamonds.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_diamonds.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_diamonds.png");
                                        break;
                                }
                                break;
                            case 3:             // Hearts
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_hearts.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_hearts.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_hearts.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_hearts.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_hearts.png");
                                        break;
                                }
                                break;
                            case 4:             // Spades
                                switch (i)
                                {
                                    case 0:
                                        card1.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_spades.png");
                                        break;
                                    case 1:
                                        card2.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_spades.png");
                                        break;
                                    case 2:
                                        card3.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_spades.png");
                                        break;
                                    case 3:
                                        card4.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_spades.png");
                                        break;
                                    case 4:
                                        card5.Image = Image.FromFile("C:/Users/Student/Desktop/Dewey/Game/Game/Images/Cards/king_spades.png");
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}