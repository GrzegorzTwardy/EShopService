using System.Diagnostics;
using System.Security.Cryptography;

namespace testy;

internal class Program
{
    static void Main(string[] args)
    {
        int[] lenghts = [1000000, 10000000, 100000000];

        foreach (int l in lenghts)
        {
            int[] parent_arr = new int[l];
            int[] normal_arr = new int[l];
            int[] boxed_arr = new int[l];
            var rand = new Random();
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine($"Array size: {l}");

            for (int i = 0; i < parent_arr.Length; i++)
            {
                parent_arr[i] = rand.Next();
            }

            stopWatch.Start();

            for (int i = 0; i < parent_arr.Length; i++)
            {
                normal_arr[i] = parent_arr[i];
            }

            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;

            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts1.Hours, ts1.Minutes, ts1.Seconds,
                ts1.Milliseconds / 10);
            Console.WriteLine("Normal Cast: " + elapsedTime1);


            stopWatch.Start();

            for (int i = 0; i < parent_arr.Length; i++)
            {
                object o = parent_arr[i];
                boxed_arr[i] = (int)o;
            }

            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;

            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts2.Hours, ts2.Minutes, ts2.Seconds,
                ts2.Milliseconds / 10);
            Console.WriteLine("Cast with boxing: " + elapsedTime2 + "\n");
        }
    }
}
