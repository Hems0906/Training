using System;


//2.Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
//Sample Input:
//"abcd"
//"a"
//"xy"
//Expected Output:
 
//dbca
//a
//yx

namespace CodeChallenge1
{
    class Swap
    {
        static string SwapFirstLast(string str)
        {
            if (str.Length <= 1)
                return str;

            char first = str[0];
            char last = str[str.Length - 1];
            string middle = str.Substring(1, str.Length - 2);

            return last + middle + first;
        }
        static void Main()
        {
            Console.WriteLine(SwapFirstLast("abcd")); 
            Console.WriteLine(SwapFirstLast("a"));    
            Console.WriteLine(SwapFirstLast("xy"));
            Console.Read();
        }

    }
}

  

