using PcMan.Model.Charachters;
using PcMan.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcMan.Model
{
    internal class Game
    {
        public static Game CurrentGame;
        private Random random;

        private KeyboardController keyboardController;
        private int gameSpeed;
        private bool isRunning;

        private DateTime endTime;
        private DateTime startTime;

        private TimeSpan timeElapsed;

        private Player player;
        private List<Enemy> enemys;
        private List<Bouncer> bouncers;

        public Game()
        {
            keyboardController = new KeyboardController();
            gameSpeed = 1;
            isRunning = true;
            random = new Random();

            CurrentGame = this;

            bouncers = new List<Bouncer>();
            enemys = new List<Enemy>();
            bouncers.Add(new Bouncer(0, 0));
            player = new Player(10,10, keyboardController);
            //enemys.Add(new Enemy(10, 10));
            
        }

        public void Play()
        {
            while (isRunning)
            {
                Update();
            }
        }

        public void Update()
        {
            // Calculate how long previous update took
            timeElapsed = endTime - startTime;

            // Register start of "update"
            startTime = DateTime.Now;

            // Chage the timeElapsed, based on the game speed
            timeElapsed *= gameSpeed;

            // Call the update method for all updateble objects
            keyboardController.Update();
            player.Update(timeElapsed);
            foreach (Bouncer bouncer in bouncers)
            {
                bouncer.Update(timeElapsed);
            }
            foreach (Enemy enemy in enemys)
            {
                enemy.Update(timeElapsed);
            }
            endTime = DateTime.Now;

        }

        public int RandomBetween(int a, int b)
        {
            return random.Next(a, b);
        }

        public float RandomBetween(float a, float b)
        {
            return (float)random.NextDouble() * (b - a) + a;
        }
    }
}
