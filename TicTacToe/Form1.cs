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
            Button button = (Button)sender; // which button was clicked
            currentPlayer = Player.X; // set player to X
            button.Text = currentPlayer.ToString(); // set button text to player X
            button.Enabled = false; // disable button when clicked
            button.BackColor = System.Drawing.Color.Cyan; // change the player colour to Cyan
            buttons.Remove(button); // remove the button from the BUTTONS LIST so the AI cant overlap with player.
            Check(); // check if the player won
            AImoves.Start(); // start the AI timer
        }

        /// <summary>
        /// The CPU will randomly choose a button from the list to click.
        /// While the array is greater than 0 the CPU will operate in this game
        /// if array is less than 0 it will stop playing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AImove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // generate a rand number in all available buttons

                /* numbers being assigned to each button.
                 * when rand number generated, look into buttons list.
                 * then select number, i.e. 4 then select 4th button in list. */
                buttons[index].Enabled = false;

                Player currentPlayer = Player.O; // set AI to O
                buttons[index].Text = currentPlayer.ToString(); // display O on the button
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index); // remove button from list
                Check(); // check at last if AI wins anything
                AImoves.Stop();
            }
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

        private void Check()
        {
            /* in this function we will check if the player othe AI has won
             * we have two very large if statements with the WIN CASES */
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Player Wins!");
                playerWins++;
                playerLabel.Text = "Player Wins- " + playerWins;
                resetGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
              || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
              || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
              || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
              || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
              || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
              || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                AImoves.Stop();
                MessageBox.Show("AI wins!");
                computerWins++;
                aiLabel.Text = "AI Wins- " + computerWins;
                resetGame();
            }
        }
    }
}