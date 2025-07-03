using System;


namespace CodeChallenge2
{
    class ThirdQuestion
    {
        static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }
        }

        static void Main()
        {
            Console.Write("Enter an integer: ");
            int inputNumber = int.Parse(Console.ReadLine());

            try
            {
                CheckNumber(inputNumber);
                Console.WriteLine("The number is valid.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

            }
            Console.Read();
        }
    }
}
