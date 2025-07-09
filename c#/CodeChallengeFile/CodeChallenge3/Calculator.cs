using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
  
delegate int CalculatorDelegate(int a, int b);
    class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Sub(int x, int y)
        {
            return x - y;
        }
        public static int Mul(int x, int y)
        {
            return x * y;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter First number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            CalculatorDelegate calculator;
            calculator = Calculator.Add;
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.WriteLine("Addition = " + calculator(num1, num2));
            calculator = Calculator.Sub;
            Console.WriteLine("Subtraction = " + calculator(num1, num2));
            calculator = Calculator.Mul;
            Console.WriteLine("Multiplication = " + calculator(num1, num2));
            Console.Read();
        }
    }

}

