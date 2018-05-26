using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class Store
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<long> Size { get; set; }
        public Nullable<long> Counter { get; set; }




        
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<Utilities> Utilities { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoresProduct> StoresProducts { get; set; }



    }
}