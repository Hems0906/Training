using System;

//3.Write a C# Sharp program to check the largest number among three given integers.
 
//Sample Input:
//1,2,3
//1,3,2
//1,1,1
//1,2,2
//Expected Output:
//3
//3
//1
//2

namespace CodeChallenge1
{
    class MaxVal
    {
        static int MaxValue(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        static void Main()
        {
            Console.WriteLine(MaxValue(1, 2, 3)); 
            Console.WriteLine(MaxValue(1, 3, 2)); 
            Console.WriteLine(MaxValue(1, 1, 1));
            Console.WriteLine(MaxValue(1, 2, 2));
            Console.Read();
        }
    }
}