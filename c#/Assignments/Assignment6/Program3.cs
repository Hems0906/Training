using System;
using System.IO;

// Mam, for the result 
// I Have attached the same file Path in the Program2 class. To find the Number of Lines.

//3. Write a program in C# Sharp to count the number of lines in a file.

class Program3
{
    static void Main()
    {
        string filePath = "C:\\Users\\hemac\\Documents\\TrainingJune2025\\CSharp.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("Total number of lines in file: " + lines.Length);
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
        Console.Read();
    }
}
