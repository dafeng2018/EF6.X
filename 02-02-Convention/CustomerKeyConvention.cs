using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_02_Convention
{
  public  class CustomerKeyConvention:Convention
    {
        public CustomerKeyConvention()
        {
            Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());
            Properties<decimal>().Configure(c => c.HasPrecision(10, 2));
            Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
