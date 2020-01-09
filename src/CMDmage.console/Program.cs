using System;
using System.Collections.Generic;

namespace CMDmage.console
{
    class Program
    {
        public delegate void ActionDelegate(List<string> inputs);
        
        private static bool _EndGame = false;
        private static ActionDelegate _Action = TickWorld;

        static void Main(string[] args)
        {
            ConsoleSetup();

            // Run game
            while (!_EndGame)
            {
                // Get player input
                List<string> inputs = GetPlayerInput();

                // Tick game world
                _Action(inputs);
            }

            TerminateGame();
        }

        private static void TickWorld(List<string> inputs)
        {
            Console.WriteLine("World clock ticked!");
        }

        private static List<string> GetPlayerInput()
        {
            Console.Write(":>");
            string input = Console.ReadLine();
            if (input.Equals("tick"))
            {
                _Action = TickWorld;
            }
            else if (input.Equals("yell"))
            {
                _Action = Yell;
            }
            else if (input.Equals("die"))
            {
                _Action = EndWorld;
            }
            else
            {
                _Action = Confused;
            }
            return new List<string>() {input};
        }

        private static void Confused(List<string> inputs)
        {
            Console.WriteLine(inputs[0] + "..?");
        }

        private static void EndWorld(List<string> inputs)
        {
            Console.WriteLine("The world is ending.. R.I.P.");
            _EndGame = true;
        }

        private static void Yell(List<string> inputs)
        {
            Console.WriteLine("The player screams at the world!");
        }

        private static void TerminateGame()
        {
            Console.ReadKey();
        }

        private static void ConsoleSetup()
        {
            Console.Title = "CMDmage";
        }
    }
}
