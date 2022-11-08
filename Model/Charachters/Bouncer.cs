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
    internal class Bouncer : Character
    {        
        public Bouncer(int top, int left)
        {
            // Set variables to the params
            Left = left;
            Top = top;

            Delay = new TimeSpan(0,0,0,0,300);
            TimeElapsed = new TimeSpan(0,0,0,0,0);

            changeDirection();

            if (directionTop > 1 || directionLeft > 1 || directionTop < -1 || directionLeft < -1 || (directionLeft == 0 && directionTop == 0))
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(directionTop + "," + directionLeft);

                throw new Exception("Invalid direction");
            }

            // Set characters symbol
            Symbol = 'X';

            // Set characters color
            Color = ConsoleColor.Yellow;

            Move(0, 0);
        }

        /// <summary>
        /// Update, gets called continuously while the game is playing
        /// </summary>
        public void Update(TimeSpan timeElapsed)
        {
            this.TimeElapsed += timeElapsed;

            if (this.TimeElapsed > Delay)
            {
                bool moved = TryMove(directionTop, directionLeft);

                if(moved)
                {
                    // decrease timeElapsed with delay
                    this.TimeElapsed -= Delay;
                }
                else
                {
                    changeDirection();
                }
            }
        }


        /// <summary>
        /// Tries to move the charachter by the specified params. 
        /// </summary>
        /// <param name="deltaTop"></param>
        /// <param name="deltaLeft"></param>
        /// <returns>
        /// A bool that indicates wether the character has been succesfully moved.
        /// </returns>
        //public bool TryMove(int deltaTop, int deltaLeft)
        //{
        //    if (CanMove(deltaTop, deltaLeft))
        //    {
        //        Move(deltaTop, deltaLeft);
        //        return true;
        //    }
        //    return false;
        //}

        //// Method to check wether we can move by given integers for top and left
        ///// <summary>
        ///// Checks wether it is possible for the character to move by the specified params.
        ///// </summary>
        ///// <param name="deltaTop"></param>
        ///// <param name="deltaLeft"></param>
        ///// <returns>
        ///// A bool that indicates wether it is possible to move.
        ///// </returns>
        //public bool CanMove(int deltaTop, int deltaLeft)
        //{
        //    // Check if the next position is possible (0 < left < 70 and 0 < top < 30)
        //    if (Left + deltaLeft < 0 || Left + deltaLeft > 70 || Top + deltaTop < 0 || Top + deltaTop > 25)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// Moves the character by the specified params.
        ///// </summary>
        ///// <param name="deltaTop"></param>
        ///// <param name="deltaLeft"></param>
        //public void Move(int deltaTop, int deltaLeft)
        //{
        //    // Set cursor to current position
        //    Console.SetCursorPosition(Left, Top);

        //    // Write a blank character
        //    Console.Write(' ');

        //    // Set new position
        //    Top += deltaTop;
        //    Left += deltaLeft;

        //    // Set cursor to new position
        //    Console.SetCursorPosition(Left, Top);

        //    // Write the symbol of the character to the screen
        //    Console.Write(Symbol);

        //}

    }
}
