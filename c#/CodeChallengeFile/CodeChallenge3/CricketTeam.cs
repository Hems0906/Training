using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class CricketTeam
    {
        public int Pointscalculation(int numberOfMatches)
        {
            int sum = 0;

            for (int i = 1; i <= numberOfMatches; i++)
            {
                Console.Write("Enter Score for Match " + i + ": ");
                int score = Convert.ToInt32(Console.ReadLine());
                sum = sum + score;
            }

            int average = sum / numberOfMatches;
            Console.WriteLine("_______________________________");
            Console.WriteLine("Total Matches Played: " + numberOfMatches);
            Console.WriteLine("Total Score: " + sum);
            Console.WriteLine("Average Score: " + average);
            Console.Read();

            return 0;
        }

        static void Main()
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter How Many Matches Played: ");
            int matches = Convert.ToInt32(Console.ReadLine());

            team.Pointscalculation(matches);

        }
    }

}
