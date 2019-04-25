using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Random_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Guess a Number Game!");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");


            for(int i = 0; i<100; i++)
            {
                Console.WriteLine(GenerateRandomNumber());
            }
            
            
            playGame();



        }

        static int getValidInteger()
        {
            Console.WriteLine("I'm thinking of a number between 1 and 100");
            Console.Write("Try to guess it: ");
            string userInput = Console.ReadLine();
            string s = userInput.Trim();
            bool isValid = int.TryParse(s, out int validInteger);

            if (!isValid || (validInteger < 1 || validInteger > 100))
            {
                Console.WriteLine("Hey that is not a number from 1 to 100");
                validInteger = getValidInteger();
            }
            return validInteger;
        }

        static bool inRange(int value)
        {
            return (value >= 1 && value <= 100) ? true : false;
        }

        static void playGame()
        {
            int count = 0;
            int randomNum = GenerateRandomNumber();
            bool correctGuess = false;
            while (!correctGuess)
            {
                count++;
                int userInput = getValidInteger();
                correctGuess = CheckGuess(userInput, randomNum);
                if (correctGuess)
                {
                    DisplayWinMessage(count);
                }
                else if(userInput > randomNum)
                {
                    if(userInput > randomNum + 10)
                    {
                        Console.WriteLine("Way t00 high! Try again n00b!");
                    } else
                    {
                        Console.WriteLine("Too high! Try again!");
                    }
                }
                else
                {
                    if (userInput < randomNum - 10)
                    {
                        Console.WriteLine("Way t00 low! Try again n00b!");
                    }
                    else
                    {
                        Console.WriteLine("Too low! Try again!");
                    }
                }
            }

        }

        public static void DisplayWinMessage(int count)
        {
            string countMessage = "You got it in " + count + " tries";
            string[] ratings =
            {
                "This should never happen!",
                "Maybe you should play the lottery! You win!",
                "Good job! You win!",
                "You suck at this, but hey you won in the end!"
            };
            switch (count)
            {
                case 0:
                    Console.WriteLine(countMessage);
                    Console.WriteLine(ratings[0]);
                    break;
                case 1:
                    Console.WriteLine(countMessage);
                    Console.WriteLine(ratings[1]);
                    break;
                case 2:
                    Console.WriteLine(countMessage);
                    Console.WriteLine(ratings[2]);
                    break;
                default:
                    Console.WriteLine(countMessage);
                    Console.WriteLine(ratings[3]);
                    break;
            }
        }

        public static bool CheckGuess(int userInput, int randomNum)
        {
            if(userInput == randomNum)
            {
                return true;
            }
            return false;
        }

        static int GenerateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        }
    }
}
