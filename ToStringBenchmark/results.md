# Results of run

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19043.1165/21H1/May2021Update)
Intel Core i7-10510U CPU 1.80GHz, 1 CPU, 8 logical and 4 physical cores
  [Host]                      : .NET Framework 4.8 (4.8.4515.0), X64 RyuJIT VectorSize=256
  ShortRun-.NET 5.0           : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
  ShortRun-.NET 6.0           : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  ShortRun-.NET 7.0           : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  ShortRun-.NET Core 3.1      : .NET Core 3.1.31 (CoreCLR 4.700.22.51102, CoreFX 4.700.22.51303), X64 RyuJIT AVX2
  ShortRun-.NET Framework 4.7 : .NET Framework 4.8 (4.8.4515.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3

|                Method |                         Job |            Runtime |   N |      Mean |      Error |    StdDev |       Rank |   Gen0 | Allocated |
|---------------------- |---------------------------- |------------------- |---- |----------:|-----------:|----------:|-----------:|-------:|----------:|
|    ToStringWithBoxing |           ShortRun-.NET 5.0 |           .NET 5.0 | 100 | 18.257 us |  4.1766 us | 0.2289 us |   ******** | 1.9836 |   8.19 KB |
| ToStringWithoutBoxing |           ShortRun-.NET 5.0 |           .NET 5.0 | 100 |  8.499 us |  8.6948 us | 0.4766 us |          * | 2.5024 |  10.25 KB |
|    ToStringWithBoxing |           ShortRun-.NET 6.0 |           .NET 6.0 | 100 | 10.514 us | 10.0587 us | 0.5514 us |       **** | 1.4343 |   5.91 KB |
| ToStringWithoutBoxing |           ShortRun-.NET 6.0 |           .NET 6.0 | 100 | 11.516 us |  6.5178 us | 0.3573 us |     ****** | 2.4872 |  10.19 KB |
|    ToStringWithBoxing |           ShortRun-.NET 7.0 |           .NET 7.0 | 100 | 10.052 us |  7.2381 us | 0.3967 us |        *** | 1.4343 |   5.88 KB |
| ToStringWithoutBoxing |           ShortRun-.NET 7.0 |           .NET 7.0 | 100 | 10.950 us | 14.2467 us | 0.7809 us |      ***** | 2.4872 |  10.22 KB |
|    ToStringWithBoxing |      ShortRun-.NET Core 3.1 |      .NET Core 3.1 | 100 | 21.794 us | 16.4384 us | 0.9010 us |  ********* | 2.0142 |   8.26 KB |
| ToStringWithoutBoxing |      ShortRun-.NET Core 3.1 |      .NET Core 3.1 | 100 |  9.914 us |  5.3795 us | 0.2949 us |         ** | 2.5024 |  10.23 KB |
|    ToStringWithBoxing | ShortRun-.NET Framework 4.7 | .NET Framework 4.7 | 100 | 30.108 us | 14.1489 us | 0.7755 us | ********** | 3.2349 |   13.3 KB |
| ToStringWithoutBoxing | ShortRun-.NET Framework 4.7 | .NET Framework 4.7 | 100 | 15.655 us |  0.7381 us | 0.0405 us |    ******* | 2.6703 |  10.97 KB |
