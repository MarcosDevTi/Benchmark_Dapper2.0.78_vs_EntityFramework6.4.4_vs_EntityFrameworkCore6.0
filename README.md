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
