using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PcMan.Model.Charachters
{
    internal class Character
    {
        // Declare all variables needed

        // Public positions
        public int Left;
        public int Top;

        // Characters symbol and color
        public char Symbol;
        public ConsoleColor Color;

        public TimeSpan Delay;
        public TimeSpan TimeElapsed;

        public int directionTop;
        public int directionLeft;

        public bool TryMove(int deltaTop, int deltaLeft)
        {
            if (CanMove(deltaTop, deltaLeft))
            {
                Move(deltaTop, deltaLeft);
                return true;
            }
            return false;
        }

        // Method to check wether we can move by given integers for top and left
        /// <summary>
        /// Checks wether it is possible for the character to move by the specified params.
        /// </summary>
        /// <param name="deltaTop"></param>
        /// <param name="deltaLeft"></param>
        /// <returns>
        /// A bool that indicates wether it is possible to move.
        /// </returns>
        public bool CanMove(int deltaTop, int deltaLeft)
        {
            // Check if the next position is possible (0 < left < 70 and 0 < top < 30)
            if (Left + deltaLeft < 0 || Left + deltaLeft > 70 || Top + deltaTop < 0 || Top + deltaTop > 25)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Moves the character by the specified params.
        /// </summary>
        /// <param name="deltaTop"></param>
        /// <param name="deltaLeft"></param>
        public void Move(int deltaTop, int deltaLeft)
        {
            // Set cursor to current position
            Console.SetCursorPosition(Left, Top);

            // Write a blank character
            Console.Write(' ');

            // Set new position
            Top += deltaTop;
            Left += deltaLeft;

            // Set cursor to new position
            Console.SetCursorPosition(Left, Top);

            Top = 0;
            Left = 0;
            // Write the symbol of the character to the screen
            Console.Write(Symbol);

        }
        public void changeDirection()
        {
            bool isMoving = false;

            while (!isMoving)
            {
                directionTop = Game.CurrentGame.RandomBetween(0, 3) - 1;
                directionLeft = Game.CurrentGame.RandomBetween(0, 3) - 1;

                if (directionLeft != 0 || directionTop != 0)
                {
                    isMoving = true;
                }
            }
        }
       
    }
}
