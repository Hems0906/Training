using System;
using System.IO;


//2.Write a program in C# Sharp to create a file and write an array of strings to the file.
class Program2
{
    static void Main()
    {
        Console.Write("Enter the number of lines you want to write: ");
        int n = Convert.ToInt32(Console.ReadLine());

        string[] lines = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter line {i + 1}: ");
            lines[i] = Console.ReadLine();
        }

        string filePath = "C:\\Users\\hemac\\Documents\\TrainingJune2025\\CSharp.txt";

        File.WriteAllLines(filePath, lines);

        Console.WriteLine("File written successfully at: " + Path.GetFullPath(filePath));
        Console.Read();
    }
}
