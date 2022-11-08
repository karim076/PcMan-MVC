using PcMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcMan.Model.Charachters;

namespace PcMan.Model.Characters
{
    /// <summary>
    /// Player class, derived from Character class
    /// </summary>
    internal class Player : Character, ICollectable
    {
        // Declare all variables needed
        private KeyboardController keyboardController;

        public Player(int top, int left, KeyboardController keyboardController)
        {
            // Set variables to the params
            Left = left;
            Top = top;

            TimeElapsed = new TimeSpan(0, 0, 0, 0, 0);

            Delay = new TimeSpan(0, 0, 0, 0, 100);

            this.keyboardController = keyboardController;

            // Set characters symbol
            Symbol = '@';

            // Set characters color
            Color = ConsoleColor.Cyan;

            Move(0, 0);
        }

        public int GetValue()
        {
            throw new NotImplementedException();
        }

        public void PickUp()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update, gets called continuously while the game is playing
        /// </summary>
        /// 
        public void Update(TimeSpan timeElapsed)
        {
            this.TimeElapsed += timeElapsed;

            if (this.TimeElapsed > Delay)
            {
                bool moved = false;
                // Ket last pressed key from KeyboardController, reset the
                // lastPressedKey to null.
                ConsoleKey lastPressed = keyboardController.ReadKey(true);

                // If up is pressed, move up
                if (lastPressed == ConsoleKey.UpArrow)
                {
                    moved = TryMove(-1, 0);
                }
                // If down is pressed, move down
                else if (lastPressed == ConsoleKey.DownArrow)
                {
                    moved = TryMove(1, 0);
                }
                // If right is pressed, move right
                else if (lastPressed == ConsoleKey.RightArrow)
                {
                    moved = TryMove(0, 1);
                }
                // If left is pressed, move left
                else if (lastPressed == ConsoleKey.LeftArrow)
                {
                    moved = TryMove(0, -1);
                }

                if (moved)
                {
                    // decrease timeElapsed with delay
                    this.TimeElapsed -= Delay;
                }
            }
        }
    }
}
