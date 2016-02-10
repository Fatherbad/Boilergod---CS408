using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        const int CREDITS = 100;
        int counter = 0;
        int hold1Toggle = 0;
        int hold2Toggle = 0;
        int hold3Toggle = 0;
        int hold4Toggle = 0;
        int hold5Toggle = 0;
        int betAmount = 1;
        int numCredits = CREDITS;
        bool win = false;

        public Form1()
        {
            InitializeComponent();
            getCards();
            creditLabel.Text = "CREDIT " + numCredits;
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter % 2 == 0)
            {
                dealButton.Visible = false;
                newGameButton.Visible = true;
            }
            getNewCards();
            checkWin();

            card1.Enabled = false;
            card2.Enabled = false;
            card3.Enabled = false;
            card4.Enabled = false;
            card5.Enabled = false;
            betOneButton.Enabled = true;
            betMaxButton.Enabled = true;

            winLoseTimer.Start();

            if (numCredits <= 0 && !win)
            {
                if (MessageBox.Show("You are out of credits. Do you want to play again?", "Video Poker", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    numCredits = CREDITS;
                    creditLabel.Text = "CREDIT " + numCredits;
                }
                else
                {
                    Application.Exit();
                }
            }

            if (betAmount > numCredits)
            {
                betAmount = numCredits;
                betLabel.Text = "BET " + betAmount;
            }
        }

        private void card1_Click(object sender, EventArgs e)
        {
            hold1Toggle++;
            if (hold1Toggle % 2 == 1)
            {
                setHold(1, true);
                hold1.Visible = true;
            }
            else
            {
                setHold(1, false);
                hold1.Visible = false;
            }
        }

        private void card2_Click(object sender, EventArgs e)
        {
            hold2Toggle++;
            if (hold2Toggle % 2 == 1)
            {
                setHold(2, true);
                hold2.Visible = true;
            }
            else
            {
                setHold(2, false);
                hold2.Visible = false;
            }
        }

        private void card3_Click(object sender, EventArgs e)
        {
            hold3Toggle++;
            if (hold3Toggle % 2 == 1)
            {
                setHold(3, true);
                hold3.Visible = true;
            }
            else
            {
                setHold(3, false);
                hold3.Visible = false;
            }
        }

        private void card4_Click(object sender, EventArgs e)
        {
            hold4Toggle++;
            if (hold4Toggle % 2 == 1)
            {
                setHold(4, true);
                hold4.Visible = true;
            }
            else
            {
                setHold(4, false);
                hold4.Visible = false;
            }
        }

        private void card5_Click(object sender, EventArgs e)
        {
            hold5Toggle++;
            if (hold5Toggle % 2 == 1)
            {
                setHold(5, true);
                hold5.Visible = true;
            }
            else
            {
                setHold(5, false);
                hold5.Visible = false;
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            counter++;
            newGameButton.Visible = false;
            dealButton.Visible = true;

            newGame();
            getCards();

            hold1.Visible = false;
            hold2.Visible = false;
            hold3.Visible = false;
            hold4.Visible = false;
            hold5.Visible = false;
            hold1Toggle = 0;
            hold2Toggle = 0;
            hold3Toggle = 0;
            hold4Toggle = 0;
            hold5Toggle = 0;
            setHold(1, false);
            setHold(2, false);
            setHold(3, false);
            setHold(4, false);
            setHold(5, false);

            winLabel.Visible = false;
            gameOverLabel.Visible = false;
            winAmountLabel.Visible = false;

            royalFlushLabel.ForeColor = System.Drawing.Color.Gold;
            straightFlushLabel.ForeColor = System.Drawing.Color.Gold;
            fourKindLabel.ForeColor = System.Drawing.Color.Gold;
            fullHouselabel.ForeColor = System.Drawing.Color.Gold;
            flushLabel.ForeColor = System.Drawing.Color.Gold;
            straightLabel.ForeColor = System.Drawing.Color.Gold;
            threeKindLabel.ForeColor = System.Drawing.Color.Gold;
            twoPairLabel.ForeColor = System.Drawing.Color.Gold;
            jacksBetterLabel.ForeColor = System.Drawing.Color.Gold;

            rf1Label.ForeColor = System.Drawing.Color.Gold;
            rf2Label.ForeColor = System.Drawing.Color.Gold;
            rf3Label.ForeColor = System.Drawing.Color.Gold;
            rf4Label.ForeColor = System.Drawing.Color.Gold;
            rf5Label.ForeColor = System.Drawing.Color.Gold;

            sf1Label.ForeColor = System.Drawing.Color.Gold;
            sf2Label.ForeColor = System.Drawing.Color.Gold;
            sf3Label.ForeColor = System.Drawing.Color.Gold;
            sf4Label.ForeColor = System.Drawing.Color.Gold;
            sf5Label.ForeColor = System.Drawing.Color.Gold;

            fk1Label.ForeColor = System.Drawing.Color.Gold;
            fk2Label.ForeColor = System.Drawing.Color.Gold;
            fk3Label.ForeColor = System.Drawing.Color.Gold;
            fk4Label.ForeColor = System.Drawing.Color.Gold;
            fk5Label.ForeColor = System.Drawing.Color.Gold;

            fh1Label.ForeColor = System.Drawing.Color.Gold;
            fh2Label.ForeColor = System.Drawing.Color.Gold;
            fh3Label.ForeColor = System.Drawing.Color.Gold;
            fh4Label.ForeColor = System.Drawing.Color.Gold;
            fh5Label.ForeColor = System.Drawing.Color.Gold;

            f1Label.ForeColor = System.Drawing.Color.Gold;
            f2Label.ForeColor = System.Drawing.Color.Gold;
            f3Label.ForeColor = System.Drawing.Color.Gold;
            f4Label.ForeColor = System.Drawing.Color.Gold;
            f5Label.ForeColor = System.Drawing.Color.Gold;

            s1Label.ForeColor = System.Drawing.Color.Gold;
            s2Label.ForeColor = System.Drawing.Color.Gold;
            s3Label.ForeColor = System.Drawing.Color.Gold;
            s4Label.ForeColor = System.Drawing.Color.Gold;
            s5Label.ForeColor = System.Drawing.Color.Gold;

            tk1Label.ForeColor = System.Drawing.Color.Gold;
            tk2Label.ForeColor = System.Drawing.Color.Gold;
            tk3Label.ForeColor = System.Drawing.Color.Gold;
            tk4Label.ForeColor = System.Drawing.Color.Gold;
            tk5Label.ForeColor = System.Drawing.Color.Gold;

            tp1Label.ForeColor = System.Drawing.Color.Gold;
            tp2Label.ForeColor = System.Drawing.Color.Gold;
            tp3Label.ForeColor = System.Drawing.Color.Gold;
            tp4Label.ForeColor = System.Drawing.Color.Gold;
            tp5Label.ForeColor = System.Drawing.Color.Gold;

            jb1Label.ForeColor = System.Drawing.Color.Gold;
            jb2Label.ForeColor = System.Drawing.Color.Gold;
            jb3Label.ForeColor = System.Drawing.Color.Gold;
            jb4Label.ForeColor = System.Drawing.Color.Gold;
            jb5Label.ForeColor = System.Drawing.Color.Gold;

            numCredits -= betAmount;
            creditLabel.Text = "CREDIT " + numCredits;

            card1.Enabled = true;
            card2.Enabled = true;
            card3.Enabled = true;
            card4.Enabled = true;
            card5.Enabled = true;
            betOneButton.Enabled = false;
            betMaxButton.Enabled = false;

            winLoseTimer.Stop();
        }

        private void betOneButton_Click(object sender, EventArgs e)
        {
            betAmount++;
            if (betAmount < 6 && betAmount <= numCredits)
            {
                betLabel.Text = "BET " + betAmount;
            }
            else
            {
                betAmount = 1;
                betLabel.Text = "BET " + betAmount;
            }
        }

        private void betMaxButton_Click(object sender, EventArgs e)
        {
            if (numCredits >= 5)
            {
                betAmount = 5;
            }
            else if (numCredits >= 4)
            {
                betAmount = 4;
            }
            else if (numCredits >= 3)
            {
                betAmount = 3;
            }
            else if (numCredits >= 2)
            {
                betAmount = 2;
            }
            else if (numCredits >= 1)
            {
                betAmount = 1;
            }
            betLabel.Text = "BET " + betAmount;
        }

        private void winLoseTimer_Tick(object sender, EventArgs e)
        {
            if (!win)
            {
                winLabel.Visible = false;
                if (gameOverLabel.Visible == false)
                {
                    gameOverLabel.Visible = true;
                }
                else
                {
                    gameOverLabel.Visible = false;
                } 
            }
            else
            {
                gameOverLabel.Visible = false;
                if (winLabel.Visible == false)
                {
                    winLabel.Visible = true;
                }
                else
                {
                    winLabel.Visible = false;
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.Show();
        }
    }
}
