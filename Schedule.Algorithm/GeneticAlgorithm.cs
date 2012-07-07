using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace Schedule.Algorithm
{
    public class GeneticAlgorithm
    {
        //float - fitness
        private List<Schedule> pool;
        
        public GeneticAlgorithm(float aMutationChance, float aCrossoverChance, int poolSize, int selectionSize, int aDayCount, int aClassPerDayCount)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            Random rand = new Random(DateTime.Now.Millisecond);
            var comp = new ScheduleComparer();
            pool = new List<Schedule>();
            int gen = 0;
            float max = 0;
            int coreCount = System.Environment.ProcessorCount;


            for (int i = 0; i < poolSize; i++)
            {
                Schedule temp = Schedule.CreateRandom(aDayCount, aClassPerDayCount);
                temp.EvaluateFitness();
                pool.Add(temp);
            }
            List<Thread> threads = new List<Thread>();
            while(max < 1)
            {
                gen++;
                
                var tempPool = new List<Schedule>();
                pool.Sort(comp);

                for (int i = 0; i < poolSize; i++)
                {
                    int other = rand.Next(poolSize);
                    Schedule temp = pool[i].Crossover(pool[other], aCrossoverChance);
                    temp.Mutation(aMutationChance);
                    temp.EvaluateFitness();
                    tempPool.Add(temp);
                }

                foreach (Thread t in threads) t.Join();
                pool.AddRange(tempPool);
                pool.Sort(comp);
                pool.RemoveRange(poolSize-1, tempPool.Count);
                max = pool.Max(s => s.Fitness);
                if(gen%10==0) Debug.WriteLine("Generation {0}, max fitness {1}", gen, max);
            }
            sw.Stop();
            Debug.WriteLine("Done in: {0} generations, {1}ms.", gen, sw.ElapsedMilliseconds);
        }
    }
    public class ScheduleComparer : IComparer<Schedule>
    {
        public int Compare(Schedule x, Schedule y)
        {
            return y.Fitness.CompareTo(x.Fitness);
        }
    }
}
