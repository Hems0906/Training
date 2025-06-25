using System;


//1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.

//Sample Input:
//"Python", 1
//"Python", 0
//"Python", 4
//Expected Output:
//Pthon
//ython
//Pythn

namespace CodeChallenge1
{
    class Position
    {
        static string RemoveElements(string str, int position)
        {
            return str.Remove(position, 1);
        }

        static void Main()
        {
            Console.WriteLine(RemoveElements("Python", 1));
            Console.WriteLine(RemoveElements("Python", 0));
            Console.WriteLine(RemoveElements("Python", 4));
            Console.Read();
        }
       
    }
}
