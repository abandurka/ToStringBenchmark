using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace ToStringBenchmark
{
    public class FooBoxing
    {
        public int Value { get; }

        public FooBoxing(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{{{nameof(Value)}={Value}}}";
        }
    }

    public class FooNoBoxing
    {
        public int Value { get; }

        public FooNoBoxing(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{{{nameof(Value)}={Value.ToString()}}}";
        }
    }

    [RankColumn]
    [ClrJob, CoreJob]
    public class ToStringBenchmark
    {
        private List<FooBoxing> FooBoxingList = new List<FooBoxing>();
        private List<FooNoBoxing> FooNoBoxingList = new List<FooNoBoxing>();

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();

            for (int i = 0; i < 10000; i++)
            {
                var value = random.Next();

                FooBoxingList.Add(new FooBoxing(value));
                FooNoBoxingList.Add(new FooNoBoxing(value));
            }
        }

        [Benchmark]
        public void ToStringWithBoxing() => FooBoxingList.ForEach(p => p.ToString());

        [Benchmark]
        public void ToStringWithoutBoxing() => FooNoBoxingList.ForEach(p => p.ToString());
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ToStringBenchmark>();
        }
    }
}
