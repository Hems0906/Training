using System;


namespace Assignment2
{
    class Program
    {
       public static void Main()
        {
            //SwapingOfNumbers();
            //RepeatingOfData();
            // DayFinder();
            // FirstArray();
            //Valuation();
            // CopyofElements();
           // str1();
           // str2();
            str3();
            Console.Read();
        }
        #region
        // 1. Write a C# Sharp program to swap two numbers.

        static void SwapingOfNumbers()
        {
            int a = 5, b = 25;
            Console.WriteLine($"The Given Numbers a = {a} and b = {b} ");

            int c = a;
                a = b;
                b = c;

            Console.WriteLine($"The Given Numbers after swaping a = {a} and b = {b} ");
        }

        // 2. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.

        static void RepeatingOfData()
        {
            Console.Write("Enter a Number: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine($"{num}  {num}  {num}  {num}");
            Console.WriteLine($"{num}{num}{num}{num}");
            Console.WriteLine($"{num}  {num}  {num}  {num}");
            Console.WriteLine($"{num}{num}{num}{num}");
        }
        //Test Data:
        //Enter a digit: 25

        // Output:
        //25 25 25 25
        //25252525
        //25 25 25 25
        //25252525

        //3. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

        static void DayFinder()
        {
            Console.Write("Enter a Number Of The Day: ");
            int num = int.Parse(Console.ReadLine());

            string result = (num == 1)
                ? "Monday"
                : (num == 2)
                    ? "Tuesday"
                    : (num == 3)
                        ? "Wednesday"
                        : (num == 4)
                            ? "Thursday"
                            : (num == 5) 
                                ? "Friday"
                                : (num == 6)
                                    ? "Saturday"
                                    :(num == 7)
                                       ? "Sunday"
                                       : "The Given Number is Invalid";

            Console.WriteLine(result);

        }

        //Test Data / input: 2
        // Output :

        //Tuesday
        #endregion

        #region
        // Arrays  :

        //1.    Write a  Program to assign integer values to an array  and then print the following

        //    a.Average value of Array elements
        //    b.Minimum and Maximum value in an array 

        public static void  FirstArray()
        {
            int[] arr = { 10, 20, 30, 40, 50 };

            int sum = 0, min = arr[0] ,max = arr[0];

            for (int i = 0; i < arr.Length; i++) 
            {
                sum += arr[i];
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }

            double avg = (double)sum / arr.Length;

            Console.WriteLine("Average: " + avg);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);

        }


        //2.	Write a program in C# to accept ten marks and display the following
        //	  a.	Total
        //    b.	Average
        //    c.	Minimum marks
        //    d.    Maximum marks
        //    e.Display marks in ascending order
        //    f.Display marks in descending order

        static void Valuation()
        {

            int[] marks = new int[10];
            Console.WriteLine("Enter the 10 Marks:");
            for (int i = 0; i < 10; i++)
                marks[i] = Convert.ToInt32(Console.ReadLine());

            int total = 0, min = marks[0], max = marks[0];

            for (int i = 0; i < 10; i++)
            {
                total += marks[i];
                if (marks[i] < min)
                    min = marks[i];
                if (marks[i] > max)
                    max = marks[i];
            }
            Console.WriteLine("Total: " + total);
            Console.WriteLine("Average: " + (double)total / 10);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
             
            for(int i =0; i < marks.Length-1; i++)
            {
                for (int j = i + 1; j < marks.Length; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        int x = marks[i];
                        marks[i] = marks[j];
                        marks[j] = x;

                    }
                }
                
            }

            Console.WriteLine("Ascending Order:");
            foreach (int mark in marks)
                Console.Write(mark + " ");

            Console.WriteLine("\nDescending Order:");
            for (int i = marks.Length - 1; i >= 0; i--)
                Console.Write(marks[i] + " ");

        }


        //3.  Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)

        static void CopyofElements()
        {
            int[] org = { 2, 3, 5, 8, 9 };
            int[] xer = new int[org.Length];

            for (int i = 0; i < org.Length; i++)
                xer[i] = org[i];

            Console.WriteLine("Copied Array:");
            foreach (int value in xer)
                Console.Write(value + " ");
        }
        #endregion

        #region
        //Strings Assignment :

        //1.	Write a program in C# to accept a word from the user and display the length of it.
        static void str1()
        {
            Console.WriteLine("Enter a Word:");
            string word = Console.ReadLine();
            Console.WriteLine("Length of the given word: " + word.Length);
        }
        //2.	Write a program in C# to accept a word from the user and display the reverse of it. 
        static void str2()
        {
            Console.WriteLine("Enter a Word :");
            string word = Console.ReadLine();
            string reversed = "";

            for (int i = word.Length - 1; i >= 0; i--)
                reversed += word[i];
            Console.WriteLine("The Given Word is Reversed: " + reversed);
        }
        //3.	Write a program in C# to accept two words from user and find out if they are same. 
        static void str3()
        {
            Console.WriteLine("Enter the First Word :");
            string word1 = Console.ReadLine();

            Console.WriteLine("Enter the Second Word :");
            string word2 = Console.ReadLine();

            string res = (word1 == word2)
                ? "The Entered Words are Same."
                : "The Entered Words are Not Same!";
            Console.WriteLine(res);
        }

        //Hint: Use functions of the string class

        #endregion

    }
}
