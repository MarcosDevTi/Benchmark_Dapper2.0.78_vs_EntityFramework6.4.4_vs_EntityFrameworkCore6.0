<h3>Insert complex objects</h3>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/insert complex graph.PNG"> </img>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/insert conplex.PNG"> </img>

<h3>Insert single objects</h3>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/insert ingle graph.PNG"> </img>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/insert single graph 2.PNG"> </img>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/insert single.PNG"> </img>

<h3>Select complex objects</h3>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/select complex graph.PNG"> </img>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/select complex.PNG"> </img>

<h3>Select single objects</h3>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/select single graph.PNG"> </img>
<img src="https://raw.githubusercontent.com/MarcosDevTi/Benchmark_Dapper2.0.30_vs_EntityFramework6.4_vs_EntityFrameworkCore3.1/master/EfVsDapper.Mvc/wwwroot/images/select single.PNG"> </img>

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.15406, CoreFX 6.0.21.15406), X64 RyuJIT
  DefaultJob : .NET Core 6.0.0 (CoreCLR 6.0.21.15406, CoreFX 6.0.21.15406), X64 RyuJIT


```
|                          Method |       Mean |      Error |     StdDev |     Median |
|-------------------------------- |-----------:|-----------:|-----------:|-----------:|
|              InsertProductsAdo1 |   3.107 ms |  0.1717 ms |  0.4926 ms |   3.025 ms |
|   InsertProductsAdoSqlBulkCopy1 |   4.459 ms |  0.2370 ms |  0.6408 ms |   4.294 ms |
|           InsertProductsDapper1 |   2.355 ms |  0.0987 ms |  0.2833 ms |   2.313 ms |
|           InsertProductsEfCore1 |   3.500 ms |  0.1899 ms |  0.5480 ms |   3.321 ms |
|             InsertProductsAdo20 |   8.363 ms |  0.3987 ms |  1.0847 ms |   8.178 ms |
|  InsertProductsAdoSqlBulkCopy20 |  12.442 ms |  1.3327 ms |  3.8663 ms |  13.054 ms |
|          InsertProductsDapper20 |  11.936 ms |  0.5755 ms |  1.6233 ms |  11.808 ms |
|          InsertProductsEfCore20 |  18.128 ms |  1.0233 ms |  3.0013 ms |  17.979 ms |
|            InsertProductsAdo200 | 116.066 ms | 12.5700 ms | 33.5519 ms | 105.651 ms |
| InsertProductsAdoSqlBulkCopy200 |  91.139 ms |  5.9899 ms | 16.6974 ms |  95.650 ms |
|         InsertProductsDapper200 | 131.735 ms | 19.2877 ms | 55.6494 ms | 135.175 ms |
|         InsertProductsEfCore200 | 131.087 ms | 13.9288 ms | 37.1789 ms | 124.958 ms |

<div>Dapper 2.0.30</div>
<div>EntityFramework 6.4</div>
<div>EntityFrameworkCore 3.1</div>
<br />
<div>Framework version: DonetCore 3.1</div>
<div>Database: SQL Server 2016</div>

<h4>select count (*) from customers = 4 326 100
<br />
SELECT Name,Email,Street,Number,City,Country FROM Customers
</h4>

<h2>Inserts</h2>

<div>
<h5>With 10 000 Items</h5>
<ul>
<li>Dapper ---------------: 00:00:02.1937825</li>
<li>EF 6 -------------------: 00:00:16.0704060</li>
<li>EF Core ----------------: 00:00:02.4896326</li>
<li><strong>EFCore AsNoTracking: 00:00:01.8780940</strong></li>
</ul>
</div>

<div>
<h5>With 500 Items</h5>
<ul>
<li><strong>Dapper ----------------: 00:00:00.0765094</strong></li>
<li>EF 6 -------------------: 00:00:00.1943946</li>
<li>EF Core ---------------: 00:00:00.0990530</li>
<li>EFCore AsNoTracking: 00:00:00.0867977</li>
</ul>
</div>



<div>
<h5>With 20 Items</h5>
<ul>
<li>Dapper ----------------: 00:00:00.0044685</li>
<li>EF 6 -------------------: 00:00:00.0101838</li>
<li><strong>EF Core ---------------: 00:00:00.0032743</strong></li>
<li>EFCore AsNoTracking: 00:00:00.0033132</li>
</ul>
</div>


<div><h2>Selects</h2></div>


<div>
<h5>With 5 Items</h5>
<ul>
<li>Dapper ----------------: 00:00:00.0265447</li>
<li>EF 6 -------------------: 00:00:00.0258215</li>
<li>EF Core ---------------: 00:00:00.1224790</li>
<li><strong>EFCore AsNoTracking: 00:00:00.0032688</strong></li>
</ul>
</div>


<div>
<h5>With 10 Items</h5>
<ul>
<li>Dapper ----------------: 00:00:00.0021278</li>
<li>EF 6 -------------------: 00:00:00.0015343</li>
<li>EF Core ---------------: 00:00:00.0011850</li>
<li><strong>EFCore AsNoTracking: 00:00:00.0002648</strong></li>
</ul>
</div>


<div>
<h5>With 30 Items</h5>
<ul>
<li>Dapper ----------------: 00:00:00.0003714</li>
<li>EF 6 -------------------: 00:00:00.0013086</li>
<li>EF Core ---------------: 00:00:00.0006102</li>
<li><strong>EFCore AsNoTracking: 00:00:00.0003618</strong></li>
</ul>
</div>




<div>
<h5>With 100 Items</h5>
<ul>
<li><strong>Dapper ----------------: 00:00:00.0005051</strong></li>
<li>EF 6 -------------------: 00:00:00.0015608</li>
<li>EF Core ---------------: 00:00:00.0009898</li>
<li>EFCore AsNoTracking: 00:00:00.0005561</li>
</ul>
</div>


<div>
<h5>With 200 Items</h5>
<ul>
<li><strong>Dapper ----------------: 00:00:00.0007486</strong></li>
<li>EF 6 ------------------: 00:00:00.0020365</li>
<li>EF Core ---------------: 00:00:00.0016754</li>
<li>EFCore AsNoTracking: 00:00:00.0008617</li>
</ul>
</div>


<div>
<h5>With 500 Items</h5>
<ul>
<li><strong>Dapper ----------------: 00:00:00.0015478</strong></li>
<li>EF 6 -------------------: 00:00:00.0057808</li>
<li>EF Core ---------------: 00:00:00.0074901</li>
<li>EFCore AsNoTracking: 00:00:00.0036823</li>
</ul>
</div>


<div>
<h5>With 10 000 Items</h5>
<ul>
<li>Dapper ----------------: 00:00:00.0474821</li>
<li>EF 6 --------------------: 00:00:00.0685237</li>
<li>EF Core -----------------: 00:00:00.0711007</li>
<li><strong>EFCore AsNoTracking: 00:00:00.0440667</strong></li>
</ul>

</div>

<div>
<h5>With 100 000 Items</h5>
<ul>
<li><strong>Dapper ---------------: 00:00:00.3126536</strong></li>
<li>EF 6 ------------------: 00:00:00.8190117</li>
<li>EF Core --------------: 00:00:00.6912632</li>
<li>EFCore AsNoTracking: 00:00:00.3639308</li>
</ul>
</div>


<div>
<h5>With 1 000 000 Items</h5>
<ul>
<li><strong>Dapper ------------: 00:00:03.0104293</strong></li>
<li>EFCore AsNoTracking: 00:00:03.5660426</li>
</ul>
</div>

