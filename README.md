``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.15406, CoreFX 6.0.21.15406), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.15406, CoreFX 6.0.21.15406), X64 RyuJIT


```
|                             Method |       Mean |      Error |     StdDev |     Median |
|----------------------------------- |-----------:|-----------:|-----------:|-----------:|
|             &#39;Insert 1 Product Ado&#39; |   3.213 ms |  0.1356 ms |  0.3890 ms |   3.157 ms |
| &#39;Insert 1 Product Ado SqlBulkCopy&#39; |   4.326 ms |  0.1488 ms |  0.4022 ms |   4.255 ms |
|          &#39;Insert 1 Product Dapper&#39; |   2.943 ms |  0.4603 ms |  1.1965 ms |   2.511 ms |
|       &#39;Insert 1 Product Ef Core 6&#39; |   3.184 ms |  0.0994 ms |  0.2786 ms |   3.128 ms |
|           &#39;Insert 20 Products Ado&#39; |  15.486 ms |  0.6307 ms |  1.7686 ms |  15.309 ms |
|   &#39;Insert 20 Products SqlBulkCopy&#39; |  14.513 ms |  1.3133 ms |  3.7043 ms |  14.828 ms |
|        &#39;Insert 20 Products Dapper&#39; |  14.134 ms |  0.8979 ms |  2.5762 ms |  13.632 ms |
|     &#39;Insert 20 Products Ef Core 6&#39; |  15.002 ms |  0.9830 ms |  2.8983 ms |  14.151 ms |
|          &#39;Insert 200 Products Ado&#39; | 109.838 ms | 11.2693 ms | 30.0802 ms | 101.336 ms |
|  &#39;Insert 200 Products SqlBulkCopy&#39; | 103.583 ms |  3.8758 ms | 10.8043 ms | 101.081 ms |
|       &#39;Insert 200 Products Dapper&#39; | 132.520 ms | 16.0635 ms | 46.6030 ms | 108.481 ms |
|    &#39;Insert 200 Products Ef Core 6&#39; | 131.096 ms | 14.7930 ms | 41.7240 ms | 117.293 ms |

