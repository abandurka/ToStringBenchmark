# Results of run

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)

Intel Core i7-10510U CPU 1.80GHz, 1 CPU, 8 logical and 4 physical cores

| [Host]                      | .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT                                  |
|-----------------------------|------------------------------------------------------------------------------|
| ShortRun-.NET 5.0           | .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT                                     |
| ShortRun-.NET 6.0           | .NET 6.0.5 (6.0.522.21309), X64 RyuJIT                                       |
| ShortRun-.NET Core 3.1      | .NET Core 3.1.25 (CoreCLR 4.700.22.21202, CoreFX 4.700.22.21303), X64 RyuJIT |
| ShortRun-.NET Framework 4.7 | .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT                                  |

|                Method |                         Job |            Runtime |   N |      Mean |     Error |    StdDev | Rank |  Gen 0 | Allocated |
|---------------------- |---------------------------- |------------------- |---- |----------:|----------:|----------:|-----:|-------:|----------:|
|    ToStringWithBoxing |           ShortRun-.NET 5.0 |           .NET 5.0 | 100 | 12.423 us |  2.807 us | 0.1539 us |    6 | 2.0142 |      8 KB |
| ToStringWithoutBoxing |           ShortRun-.NET 5.0 |           .NET 5.0 | 100 |  5.963 us |  8.328 us | 0.4565 us |    1 | 2.5101 |     10 KB |
|    ToStringWithBoxing |           ShortRun-.NET 6.0 |           .NET 6.0 | 100 |  7.618 us | 11.720 us | 0.6424 us |    3 | 1.4191 |      6 KB |
| ToStringWithoutBoxing |           ShortRun-.NET 6.0 |           .NET 6.0 | 100 |  8.071 us |  4.851 us | 0.2659 us |    4 | 2.4872 |     10 KB |
|    ToStringWithBoxing |      ShortRun-.NET Core 3.1 |      .NET Core 3.1 | 100 | 13.917 us |  4.630 us | 0.2538 us |    7 | 1.9989 |      8 KB |
| ToStringWithoutBoxing |      ShortRun-.NET Core 3.1 |      .NET Core 3.1 | 100 |  6.895 us |  1.851 us | 0.1015 us |    2 | 2.4796 |     10 KB |
|    ToStringWithBoxing | ShortRun-.NET Framework 4.7 | .NET Framework 4.7 | 100 | 22.395 us | 39.841 us | 2.1838 us |    8 | 3.2349 |     13 KB |
| ToStringWithoutBoxing | ShortRun-.NET Framework 4.7 | .NET Framework 4.7 | 100 | 11.894 us |  1.187 us | 0.0651 us |    5 | 2.6703 |     11 KB |
