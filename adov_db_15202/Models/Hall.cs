using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adov_db_15202.Models
{
    public class Hall
    {
        public long ID { get; set; }
        public long StoreID { get; set; }
        public long SellerID { get; set; } //manager
        public long NumberHall { get; set; }
        public long CountWorker { get; set; }
        public long Floor { get; set; }

        public virtual Store Store { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
