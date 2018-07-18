using System;
using System.Text;

namespace TablesSquaresCubes
{
    class Program
    {
        static void Main(string[] args)
        {
            // flag to keep the program running
            bool isRunning = true;
            do
            {
                // variables
                string userName;
                int userNumber;
                // Greet the user
                Console.WriteLine("Hello there and welcome! This program will help you learn your squares and cubes!");
                // Ask for and store the userName
                userName = UserInput.SetUserName();
                // Ask for and stor the userNumber
                userNumber = UserInput.SetUserNumber(userName);
                Display(userNumber);
                // ask the user if they would like to play again - if Y keep running - if N isRunning becomes false
                isRunning = UserInput.PlayAgain(userName);
                if (!isRunning)
                {
                    Console.WriteLine($"Thanks for playing {userName}! Goodbye!");
                }
            } while (isRunning);
        }

        // seperate class and methods for user input for practice
        public static class UserInput
        {
            // Method to get the users name
            public static string SetUserName()
            {
                Console.WriteLine("So what should I call you by?");
                string userName = Console.ReadLine();
                Console.WriteLine($"Ok then {userName} it is!");
                return userName;
            }
            // Method to get the users integer
            public static int SetUserNumber(string userName)
            {
                Console.WriteLine($"Please enter an integer {userName}");
                string userNumber = Console.ReadLine();
                if (IsValidInt(userNumber))
                {
                    return int.Parse(userNumber);
                }
                return SetUserNumber(userName);
            }
            // Method to ask the user if they would like to run the program again
            public static bool PlayAgain(string userName)
            {
                Console.WriteLine($"Would you like to run the program again {userName}? ( y/n ) ");
                try
                {
                    char playAgain = char.Parse(Console.ReadLine().ToLower().Trim());
                    if (playAgain == 'y')
                    {
                        return true;
                    }
                    else if (playAgain == 'n')
                    {
                        return false;
                    }
                    else
                    {
                        return PlayAgain(userName);
                    }
                }
                catch (Exception)
                {
                    // if the user does not enter y or n ask again recursively
                    return PlayAgain(userName);
                }
            }
        }
        // Methods to calculate squared and cubed
        public static class Calculations
        {
            // squared method
            public static int CalculateSquared(int userNumber)
            {
                return userNumber * userNumber;
            }
            // cubed method
            public static int CalculateCubed(int userNumber)
            {
                return (userNumber * userNumber) * userNumber;
            }
        }
        // method to display the answers and format the strings into a table
        public static void Display(int userNumber)
        {
            // string builder for the header of the table
            var sb = new StringBuilder();
            sb.Append(String.Format("{0,-10} {1,-10} {2,-10}\n", "Number", "Squared", "Cubed"));
            sb.Append(String.Format("{0,-10} {0,-10} {0,-10}\n", "======="));;
            Console.WriteLine(sb);

            for (int i = 1; i <= userNumber; i++)
            {
                // store the calculations in variables
                int squared = Calculations.CalculateSquared(i);
                int cubed = Calculations.CalculateCubed(i);
                // string builder for the actual table and answers
                var answers = new StringBuilder();
                answers.Append(String.Format("{0, -10} {1, -10} {2, -10}", i, squared, cubed));
                Console.WriteLine(answers);
            }
        }
        // Method to validate that input is an int
        public static bool IsValidInt(string userNumber)
        {
            return int.TryParse(userNumber, out int isInt);
        }
    }
}
