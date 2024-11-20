using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT3
{
    class CricketTeam
    {
        
        public void PointsCalculation(int no_of_matches)
        {
            int totalPoints = 0;

            Console.WriteLine($"Enter the scores for {no_of_matches} matches:");

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Match {i + 1} score: ");
                int score = int.Parse(Console.ReadLine());
                totalPoints += score;
            }

            double averagePoints = (double)totalPoints / no_of_matches;

            Console.WriteLine($"\nCount of  Matches Played: {no_of_matches}");
            Console.WriteLine($"Average of the scores: {averagePoints}");
            Console.WriteLine($"Sum of Total Points Scored: {totalPoints}");
            
        }
    }

    class Cricket
    {
        static void Main()
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter the number of matches: ");
            int no_of_matches = int.Parse(Console.ReadLine());

            team.PointsCalculation(no_of_matches);
            Console.Read();
        }
    }
}
