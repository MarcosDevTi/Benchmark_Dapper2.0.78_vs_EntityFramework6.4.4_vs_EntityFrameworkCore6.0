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


|                            Method |      Mean |     Error |   StdDev |    Median |
|---------------------------------- |----------:|----------:|---------:|----------:|
|         &#39;Insert 200 Products Ado&#39; | 115.66 ms |  9.798 ms | 28.11 ms | 103.54 ms |
| &#39;Insert 200 Products SqlBulkCopy&#39; |  80.60 ms |  9.330 ms | 27.36 ms |  65.58 ms |
|      &#39;Insert 200 Products Dapper&#39; | 160.93 ms | 14.577 ms | 42.06 ms | 152.06 ms |
|   &#39;Insert 200 Products Ef Core 6&#39; | 148.79 ms | 18.131 ms | 48.08 ms | 143.86 ms |
|        &#39;Insert 200 Products Ef 6&#39; | 230.36 ms | 27.114 ms | 78.66 ms | 219.55 ms |


|                       Method |     Mean |    Error |   StdDev |
|----------------------------- |---------:|---------:|---------:|
|       &#39;Select 1 Product Ado&#39; | 150.1 μs |  0.97 μs |  0.91 μs |
|    &#39;Select 1 Product Dapper&#39; | 120.4 μs |  0.66 μs |  0.62 μs |
| &#39;Select 1 Product Ef Core 6&#39; | 648.4 μs | 18.81 μs | 54.27 μs |
|      &#39;Select 1 Product Ef 6&#39; | 818.6 μs | 21.73 μs | 62.69 μs |

|                       Method |     Mean |    Error |   StdDev |
|----------------------------- |---------:|---------:|---------:|
|       &#39;Select 5 Product Ado&#39; | 172.1 μs |  2.10 μs |  1.86 μs |
|    &#39;Select 5 Product Dapper&#39; | 141.7 μs |  0.79 μs |  0.62 μs |
| &#39;Select 5 Product Ef Core 6&#39; | 715.5 μs | 21.23 μs | 60.22 μs |
|      &#39;Select 5 Product Ef 6&#39; | 868.5 μs | 24.91 μs | 72.67 μs |


|                        Method |       Mean |    Error |    StdDev |
|------------------------------ |-----------:|---------:|----------:|
|       &#39;Select 50 Product Ado&#39; |   281.5 μs |  0.97 μs |   0.86 μs |
|    &#39;Select 50 Product Dapper&#39; |   253.7 μs |  1.81 μs |   1.61 μs |
| &#39;Select 50 Product Ef Core 6&#39; | 1,247.9 μs | 35.12 μs | 103.01 μs |
|      &#39;Select 50 Product Ef 6&#39; | 1,328.2 μs | 49.19 μs | 143.49 μs |


|                         Method |     Mean |     Error |    StdDev |   Median |
|------------------------------- |---------:|----------:|----------:|---------:|
|       &#39;Select 500 Product Ado&#39; | 2.513 ms | 0.0747 ms | 0.2142 ms | 2.468 ms |
|    &#39;Select 500 Product Dapper&#39; | 2.276 ms | 0.1001 ms | 0.2871 ms | 2.231 ms |
| &#39;Select 500 Product Ef Core 6&#39; | 4.519 ms | 0.4314 ms | 1.2721 ms | 3.787 ms |
|      &#39;Select 500 Product Ef 6&#39; | 4.260 ms | 0.2179 ms | 0.6322 ms | 4.157 ms |


|                          Method |     Mean |    Error |   StdDev |
|-------------------------------- |---------:|---------:|---------:|
|       &#39;Select 5000 Product Ado&#39; | 16.91 ms | 0.318 ms | 0.340 ms |
|    &#39;Select 5000 Product Dapper&#39; | 16.90 ms | 0.435 ms | 1.268 ms |
| &#39;Select 5000 Product Ef Core 6&#39; | 28.25 ms | 0.554 ms | 0.955 ms |
|      &#39;Select 5000 Product Ef 6&#39; | 31.44 ms | 0.841 ms | 2.441 ms |
