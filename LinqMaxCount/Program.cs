using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMaxCount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<LinqMaxCountBenchmark>();
        }
    }

    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [IterationCount(10)]
    [RankColumn]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class LinqMaxCountBenchmark
    {
        static readonly int[] list = { 1, 5, 8, 3, 6, 1, 2, 5, 4, 1, 1, 4, 8, 1 };

        [Benchmark]
        public int MaxCount1()
        {
            return list.MaxCount1();
        }

        [Benchmark]
        public int MaxCount2()
        {
            return list.MaxCount2();
        }

        [Benchmark]
        public int MaxCount3()
        {
            return list.MaxCount3();
        }
        [Benchmark]
        public int CountBy()
        {
            return list.CountBy(i => i).OrderByDescending(n => n.Value).First().Key;
        }

    }
}
