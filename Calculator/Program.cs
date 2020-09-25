using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double digit1, double digit2, string operation)
        {
            double result = double.NaN;

            switch (operation)
            {
                case "a":
                    result = digit1 + digit2;
                    break;
                case "s":
                    result = digit1 - digit2;
                    break;
                case "m":
                    result = digit1 * digit2;
                    break;
                case "d":
                    if (digit2 != 0)
                    {
                        result = digit1 / digit2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string digitInput1 = "";
                string digitInput2 = "";
                double result = 0;

                Console.Write("Type a number, and then press Enter: ");
                digitInput1 = Console.ReadLine();

                double cleanDigit1 = 0;
                while (!double.TryParse(digitInput1, out cleanDigit1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    digitInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: ");
                digitInput2 = Console.ReadLine();

                double cleanDigit2 = 0;
                while (!double.TryParse(digitInput2, out cleanDigit2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    digitInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanDigit1, cleanDigit2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); 
            }
            return;
        }
    }
}