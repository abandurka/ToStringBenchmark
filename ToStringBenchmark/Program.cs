using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;

namespace ToStringBenchmark
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<ToStringBenchmarkJob>();
        }
    }

    [RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Stars)]
    [ShortRunJob(RuntimeMoniker.Net47)]
    [ShortRunJob(RuntimeMoniker.Net50)]
    [ShortRunJob(RuntimeMoniker.Net60)]
    [ShortRunJob(RuntimeMoniker.Net70)]
    [ShortRunJob(RuntimeMoniker.NetCoreApp31)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ToStringBenchmarkJob
    {
        private readonly List<FooBoxing> _fooBoxingList = new();
        private readonly List<FooNoBoxing> _fooNoBoxingList = new();

        [Params(100)]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnassignedField.Global
        public int N { get; set; }
        
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

        private class FooBoxing
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

        private class FooNoBoxing
        {
            public int Value { get; }

            public FooNoBoxing(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
#pragma warning disable CA1305 // Specify IFormatProvider
                return $"{{{nameof(Value)}={Value.ToString()}}}";
#pragma warning restore CA1305 // Specify IFormatProvider
            }
        }
    }

}