using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Player currentPlayer; // calling the player class

        private List<Button> buttons; // creating a LIST or array of buttons
        private Random rand = new Random(); // importing the random number generator class

        private int playerWins = 0; // set the initial player win score to 0
        private int computerWins = 0; // set the initial computer score to 0

        /// <summary>
        /// below is the player class
        /// which has two values: X and O
        /// by doing this we can control the player and AI symbols.
        /// </summary>
        public enum Player
        {
            X,
            O
        }

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void playerClick(object sender, EventArgs e)
        {
        }

        private void AImove(object sender, EventArgs e)
        {
        }

        private void restartGame(object sender, EventArgs e)
        {
            /* this function is linked with the reset button
            when the reset button is clicked
            then this function will trigger the reset game function */
            resetGame();
        }

        private void loadButtons()
        {
            // load all the buttons from the form and put them into the button list
            buttons = new List<Button> {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };
        }

        private void resetGame()
        {
        }

        private void Check()
        {
            // check each of the button with given tag "play"
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true; // set enabled/clickable
                    ((Button)X).Text = "?"; // set text to its origin text on form
                    ((Button)X).BackColor = default(Color); // change the background color to default
                }
            }
            loadButtons(); // add all playable buttons to the list array.
        }
    }
}