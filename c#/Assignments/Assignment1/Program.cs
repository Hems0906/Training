using System;

namespace Assignment1
{
    class Program
    {
        public static void Main()
        {
             CheckEquality();
             CheckPositiveNegative();
             AllOperations();
             PrintMultiplicationTable();
             SumWithTripleIfEqual();
            Console.Read();
        }

        //   1. Write a C# Sharp program to accept two integers and check whether they are equal or not.

        static void CheckEquality()
        {
            Console.WriteLine(" Check Wheather the Numbers are Equal ");
            Console.Write("Enter 1st number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            int num2 = int.Parse(Console.ReadLine());

            if (num1 == num2)
                Console.WriteLine($"{num1} and {num2} are equal");
            else
                Console.WriteLine($"{num1} and {num2} are not equal");
            Console.WriteLine();
           

        }

        // 2. Write a C# Sharp program to check whether a given number is positive or negative. 

        static void CheckPositiveNegative()
        {
            Console.WriteLine("== Check Positive or Negative ==");
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            string result = (num > 0)
                ? $"{num} is a positive number"
                : (num < 0)
                    ? $"{num} is a negative number"
                    : "The number is zero";

            Console.WriteLine(result + "\n");
          
        }

        // 3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 

        static void AllOperations()
        {
            Console.WriteLine("== Perform Operation (+, -, *, /) ==");
            Console.Write("Input first number: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Input operation (+, -, *, /): ");
            char op = Console.ReadLine()[0];
            Console.Write("Input second number: ");
            double num2 = double.Parse(Console.ReadLine());

            string result = op == '+'
                ? $"{num1} + {num2} = {num1 + num2}"
                : op == '-'
                    ? $"{num1} - {num2} = {num1 - num2}"
                    : op == '*'
                        ? $"{num1} * {num2} = {num1 * num2}"
                        : op == '/' && num2 != 0
                            ? $"{num1} / {num2} = {num1 / num2}"
                            : op == '/' && num2 == 0
                                ? "Division by zero is not allowed."
                                : "Invalid operation";

            Console.WriteLine(result + "\n");
            
        }

        // 4. Write a C# Sharp program that prints the multiplication table of a number as input.
        static void PrintMultiplicationTable()
        {
            Console.WriteLine("== Multiplication Table ==");
            Console.Write("Enter the number: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }

            Console.WriteLine();
        }

        // 5.  Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.

        static void SumWithTripleIfEqual()
        {
            Console.WriteLine("== Sum with Triple if Equal ==");
            Console.Write("Enter first integer: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;
            string result = (num1 == num2)
                ? $"Triple of their sum is: {3 * sum}"
                : $"Sum is: {sum}";

            Console.WriteLine(result + "\n");
        }



    }
}
