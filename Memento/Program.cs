using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class CheckPointMemento
    {
        public int level { get; set; }
        public int score { get; set; }
        public DateTime checkPointTime { get; set; }
        public CheckPointMemento(int level, int score, DateTime checkPointTime)
        {
            this.level = level;
            this.score = score;
            this.checkPointTime = checkPointTime;
        }
    }

    public class CareTaker
    {
        public CheckPointMemento checkpoint { get; set; }
    }

    class PlayerStatistics
    {
        public int level { get; set; }
        public int score { get; set; }
        public DateTime checkPointTime { get; set; }
        public CheckPointMemento CreateCheckPoint(PlayerStatistics statistics)
        {
            return new CheckPointMemento(statistics.level, statistics.score, statistics.checkPointTime);
        }

        public void RestoreCheckPoint(CheckPointMemento checkPoint)
        {
            this.level = checkPoint.level;
            this.score = checkPoint.score;
            this.checkPointTime = checkPoint.checkPointTime;
        }

        public void PrintStatistics()
        {
            Console.WriteLine("Level:" + this.level);
            Console.WriteLine("Score:" + this.score);
            Console.WriteLine("CheckPoint Time:" + this.checkPointTime);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            PlayerStatistics p1 = new PlayerStatistics();
            p1.level = 4;
            p1.score = 34;
            p1.checkPointTime = DateTime.Now;
            Console.WriteLine("Initial:");
            p1.PrintStatistics();

            CareTaker ct = new CareTaker();
            ct.checkpoint = p1.CreateCheckPoint(p1);
            Console.WriteLine();

            p1.level = 8;
            p1.score = 96;
            p1.checkPointTime = DateTime.Now.AddHours(10);
            Console.WriteLine("Updated:");
            p1.PrintStatistics();
            Console.WriteLine();

            p1.RestoreCheckPoint(ct.checkpoint);
            Console.WriteLine("Restored:");
            p1.PrintStatistics();
        }
    }
}
