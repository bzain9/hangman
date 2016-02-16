using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            HagmanGame game = new HagmanGame();
            game.play();

            Console.ReadLine();
        }
    }
}
