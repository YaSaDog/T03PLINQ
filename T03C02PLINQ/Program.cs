using System.Diagnostics;

namespace T03C02PLINQ
{
    class Program
    {
        static void Print(List<int> perfectNumbers)
        {
            if (perfectNumbers == null)
            {
                Console.WriteLine("List is null");
                return;
            }

            Console.WriteLine("Amount of perfect numbers: " + perfectNumbers.Count);

            foreach (int x in perfectNumbers)
                Console.WriteLine(x);
        }
        
        static void PerfectNumbers(int last)
        {
            var perfectNumbers = 
                (from n in Enumerable.Range(2, last - 1)
                where 
                    (from x in Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                    where n % x == 0
                    select (x + n / x)).Sum() + 1 == n    
                select n).ToList();

            Print(perfectNumbers);
        }

        static void PerfectNumbersPLINQ(int last)
        {
            var PerfectNumbers = 
                (from n in Enumerable.Range(2, last - 1).AsParallel()
                where 
                    (from x in Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                    where n % x == 0
                    select (x + n / x)).Sum() + 1 == n
                select n).ToList();

                Print(PerfectNumbers);
        }
        
        static void Main(string[] args)
        {
            int lastNum = 1_000_000;
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Find all perfect numbers from 1 to " + lastNum + ":");
            stopwatch.Start();
            PerfectNumbers(lastNum);
            stopwatch.Stop();
            long timeLINQ = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("\nNow with PLINQ:");
            stopwatch.Restart();
            PerfectNumbersPLINQ(lastNum);
            stopwatch.Stop();
            long timePLINQ = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("\nTime elapsed w/o PLINQ: " + timeLINQ + "ms");
            Console.WriteLine("Time elapsed w/ PLINQ: " + timePLINQ + "ms");
        }
    }
}