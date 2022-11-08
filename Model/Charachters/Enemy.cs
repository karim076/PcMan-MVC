using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcMan.Model.Charachters;

namespace PcMan.Model.Charachters
{
    internal class Enemy : Character
    {
        public Enemy(int top, int left)
        {
            this.Top = top;
            this.Left = left;
            // Set variables to the params
            Delay = new TimeSpan(0, 0, 0, 0, 2000);
            TimeElapsed = new TimeSpan(0, 0, 0, 0, 0);

            Console.SetCursorPosition(0, 0);
            Console.Write(Top + "," + Left);

            // Set characters symbol
            Symbol = 'M';

            // Set characters color
            Color = ConsoleColor.Red;

            Random rnd = new Random();
            int num = rnd.Next(1, 100);

            Move(num, num);
        }
        // hier
        public void Update(TimeSpan timeElapsed)
        {
            Random rnd = new Random();
            this.TimeElapsed += timeElapsed;
            int Top = rnd.Next(1, 100);
            int Left = rnd.Next(1, 100);

            if (this.TimeElapsed > Delay)
            {
                bool moved = TryMove(-this.Top + Top, -this.Left +Left);

                if (moved)
                {
                    // decrease timeElapsed with delay
                    this.TimeElapsed -= Delay;
                }
            }

        }

    }
}
