using System;
using System.IO;

namespace CodeChallenge3
{
    class FileCreation
    {
        static void Main()
        {
            string filePath = "C:\\Hemachandra\\DotNetTraining\\c#\\CodeChallengeFile\\CodeChallenge3 Output\\AppendFile.txt";

            Console.Write("Enter Some Text to Save in File: ");
            string inputText = Console.ReadLine();

            using (StreamWriter streamwriter = File.AppendText(filePath))
            {
                streamwriter.WriteLine(inputText);
            }
            Console.WriteLine("Text Written to File Successfully.");
            Console.Read();
        }
    }

}
