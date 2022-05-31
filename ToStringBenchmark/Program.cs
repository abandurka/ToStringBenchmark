using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

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
    [ShortRunJob(RuntimeMoniker.Net47)]
    [ShortRunJob(RuntimeMoniker.Net50)]
    [ShortRunJob(RuntimeMoniker.Net60)]
    [ShortRunJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    [MarkdownExporter]
    [MarkdownExporterAttribute.GitHub]
    public class ToStringBenchmark
    {
        private readonly List<FooBoxing> _fooBoxingList = new();
        private readonly List<FooNoBoxing> _fooNoBoxingList = new();

        [Params(100)]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnassignedField.Global
        public int N;
        
        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();

            for (var i = 0; i < N; i++)
            {
                var value = random.Next();

                _fooBoxingList.Add(new FooBoxing(value));
                _fooNoBoxingList.Add(new FooNoBoxing(value));
            }
        }

        [Benchmark]
        public void ToStringWithBoxing() => _fooBoxingList.ForEach(p => p.ToString());

        [Benchmark]
        public void ToStringWithoutBoxing() => _fooNoBoxingList.ForEach(p => p.ToString());
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ToStringBenchmark>();
        }
    }
}