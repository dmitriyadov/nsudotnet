using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class Product
    {
        public long ProductID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProvidersPrice> ProvidersPrices { get; set; }
        public virtual ICollection<StoresProduct> StoresProducts { get; set; }


    }
}