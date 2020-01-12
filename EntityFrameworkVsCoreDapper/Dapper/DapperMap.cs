using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.Dapper
{
    public class DapperMap: DommelEntityMap<Customer>
    {
        public DapperMap()
        {
            ToTable("Customers");
            Map(_ => _.Id).IsKey();
        }
    }
}
