using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoreAlgorithm algorithm;
            Console.WriteLine("Mans");
            algorithm = new menscore();
            Console.WriteLine(algorithm.GenerateScore(8,new TimeSpan(0,0,10)));
            Console.WriteLine("Womans");
            algorithm = new womenscore();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 0, 10)));
            Console.WriteLine("Children");
            algorithm = new childscore();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 0, 10)));

            Console.ReadLine();
        }
    }

    abstract class ScoreAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateScore(hits);
            int reduction = CalculateReduction(time);

            return CalculateOverAllScore(score, reduction);

        }
        public abstract int CalculateOverAllScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateScore(int hits);     
    }

    class menscore : ScoreAlgorithm
    {
        public override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateScore(int hits)
        {
            return hits * 100;
        }
    }
    class womenscore : ScoreAlgorithm
    {
        public override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateScore(int hits)
        {
            return hits * 100;
        }
    }
    class childscore : ScoreAlgorithm
    {
        public override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds/2;
        }

        public override int CalculateScore(int hits)
        {
            return hits * 80;
        }
    }
}
