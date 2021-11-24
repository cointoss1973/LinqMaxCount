# LinqMaxCount
Some C# implementations to get the element with the highest number of occurrences in a list, implemented as extended methods of LINQ.

## Benchmark
### Results
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1348 (21H2)
AMD Ryzen 7 PRO 5850U with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-QVMKUB : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

Runtime=.NET 6.0  IterationCount=10  

```
|    Method |       Mean |   Error |  StdDev | Rank |  Gen 0 | Allocated |
|---------- |-----------:|--------:|--------:|-----:|-------:|----------:|
| MaxCount1 |   566.7 ns | 5.07 ns | 3.35 ns |    2 | 0.1678 |   1,408 B |
| MaxCount2 | 1,017.3 ns | 8.40 ns | 4.39 ns |    3 | 0.2270 |   1,904 B |
| MaxCount3 |   569.9 ns | 5.18 ns | 3.42 ns |    2 | 0.1631 |   1,368 B |
|   CountBy |   415.7 ns | 3.94 ns | 2.34 ns |    1 | 0.1040 |     872 B |

## NOTICE
* MoreLinq 
  * https://github.com/morelinq/MoreLINQ
  * Apache License 2.0
