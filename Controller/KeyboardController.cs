using PcMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcMan
{
    /// <summary>
    /// The controller class.
    /// </summary>
    internal class KeyboardController
    {
        private ConsoleKey lastPressed;

        /// <summary>
        /// Constructor
        /// </summary>
        public KeyboardController()
        {
            
        }

        /// <summary>
        /// Update, is continuously called while playing the game.
        /// </summary>
        public void Update()
        {
            // If a key was preesed, set lastPressed to that key, else set lastPressed to 0
            if (Console.KeyAvailable)
            {
                lastPressed = Console.ReadKey(true).Key;
            }
        }
        
        public ConsoleKey ReadKey()
        {
            return lastPressed;
        }

        public ConsoleKey ReadKey(bool resetKey)
        {
            if(resetKey)
            {
                ConsoleKey tmp = lastPressed;
                lastPressed = 0;
                return tmp;
            }

            return ReadKey();
        }
    }
}
