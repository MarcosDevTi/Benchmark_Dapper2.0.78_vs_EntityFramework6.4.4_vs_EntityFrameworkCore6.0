``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.15406, CoreFX 6.0.21.15406), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.15406, CoreFX 6.0.21.15406), X64 RyuJIT


```
|                             Method |     Mean |     Error |    StdDev |
|----------------------------------- |---------:|----------:|----------:|
|             &#39;Insert 1 Product Ado&#39; | 2.936 ms | 0.0576 ms | 0.1517 ms |
| &#39;Insert 1 Product Ado SqlBulkCopy&#39; | 7.750 ms | 0.6424 ms | 1.8841 ms |
|          &#39;Insert 1 Product Dapper&#39; | 2.346 ms | 0.1238 ms | 0.3632 ms |
|       &#39;Insert 1 Product Ef Core 6&#39; | 3.000 ms | 0.1006 ms | 0.2598 ms |
|            &#39;Insert 1 Product Ef 6&#39; | 3.373 ms | 0.1089 ms | 0.3175 ms |


|                             Method |     Mean |     Error |    StdDev |   Median |
|----------------------------------- |---------:|----------:|----------:|---------:|
|             &#39;Insert 5 Product Ado&#39; | 5.260 ms | 0.1854 ms | 0.5198 ms | 5.002 ms |
| &#39;Insert 5 Product Ado SqlBulkCopy&#39; | 7.950 ms | 0.8396 ms | 2.4623 ms | 7.639 ms |
|          &#39;Insert 5 Product Dapper&#39; | 5.881 ms | 0.3838 ms | 1.1317 ms | 5.623 ms |
|       &#39;Insert 5 Product Ef Core 6&#39; | 5.543 ms | 0.3048 ms | 0.7813 ms | 5.516 ms |
|            &#39;Insert 5 Product Ef 6&#39; | 6.206 ms | 0.2454 ms | 0.7119 ms | 6.215 ms |


|                           Method |     Mean |    Error |   StdDev |   Median |
|--------------------------------- |---------:|---------:|---------:|---------:|
|         &#39;Insert 20 Products Ado&#39; | 20.98 ms | 1.408 ms | 4.108 ms | 21.20 ms |
| &#39;Insert 20 Products SqlBulkCopy&#39; | 16.22 ms | 0.775 ms | 2.210 ms | 16.58 ms |
|      &#39;Insert 20 Products Dapper&#39; | 15.37 ms | 0.942 ms | 2.688 ms | 14.97 ms |
|   &#39;Insert 20 Products Ef Core 6&#39; | 15.81 ms | 1.335 ms | 3.633 ms | 14.74 ms |
|        &#39;Insert 20 Products Ef 6&#39; | 25.18 ms | 1.164 ms | 3.433 ms | 24.53 ms |
