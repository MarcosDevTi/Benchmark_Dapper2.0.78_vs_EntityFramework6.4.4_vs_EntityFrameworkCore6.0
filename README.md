<h1>ORMs benchmark</h1>

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


<div>
<h2>AutoMapper</h2>
<h3>Count: 300 000</h3>
<ul>
<li>_mapper.Map<IEnumerable<CustomerViewModel>>(customers): 00:00:00.0793546</li>
</ul>
</div>
